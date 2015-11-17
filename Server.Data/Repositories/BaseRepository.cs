using Server.Data.Models.Interfaces;
using Server.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Data.Extensions;
using System.Configuration;
using Server.Data.Enums;
using Server.Data.Utils;
using Server.Data.Models.BaseClasses;

namespace Server.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : Identifiable
    {
        #region Fields
        private static IDbConnection _dbConnection;
       
        #endregion

        #region Constructors
        protected BaseRepository()
        {
            _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        }

        protected BaseRepository(string publishKey = null) : this()
        {
        }
        
        protected BaseRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        #endregion

        #region CRUD Operations
        public virtual T Get(long id)
        {
            T res = _dbConnection.Query<T>(SelectByIdQuery, new { Id = id }).FirstOrDefault<T>();
            if (res == null)
                throw new KeyNotFoundException();

            return res;
        }

        public virtual IList<T> Get(int skipCount, int takeCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC)
        {
            string orderValue;
            try
            {
                orderValue = FindProperty(typeof(T), orderType);
            }
            catch (ArgumentNullException)
            {
                orderValue = "Id";
                //throw new ArgumentException("The property does not exist", e);
            }

            return DBConnection.Query<T>(SelectAllWithPaging(orderValue, sortingOrder.ToString()), new { OffsetCount = skipCount, FetchedElements = takeCount }).ToList();
        }

        public abstract T Add(T entity, long userId = 0);

        public abstract T Update(T entity, long userId = 0);

        public virtual void Remove(long id)
        {
            if (_dbConnection.Query<int>(DeleteByIdQuery, new { Id = id }).FirstOrDefault() == 0)
                throw new KeyNotFoundException();
        }
        #endregion


        protected static void ValidateEntity(T entity)
        {
            if (entity == null)
                throw new KeyNotFoundException();
        }

        protected Exception CheckSqlException(SqlException sqlException)
        {
            switch (sqlException.Number)
            {
                case Sql.ErrorCodesConstants.SqlNotAuthorizedErrorCode: throw new UnauthorizedAccessException(sqlException.Message);                //100_004
                default: throw new Exception(sqlException.Message, sqlException);
            }
        }

        public static long? GetUserIdByPublishCode(string hashedCode)
        {
            long userId = DBConnection.Query<long>(SelectUserIdByPublishCodeQuery, new { PublishCode = hashedCode }).First();
            return userId;
        }

        public static bool IsAdminPublishCode(string code)
        {
            return code != null && Server.Data.Constants.Constants.AdminKeys.Contains(PublishCodeEncrypter.GenerateSHA256Hash(code));
        }

        //private static string GetQueryWithPaging(string orderType)
        //{
        //    return GetPagingSubQuery.ReplaceOrderTypeValue(orderType);
        //}

        //protected string GetDefinedCountQuery(string orderType)
        //{
        //    return SelectAllQuery + this.GetQueryWithPaging(orderType);
        //}

        protected static string FindProperty(Type type, string value)
        {
            // Get the PropertyInfo object by passing the property name.
            PropertyInfo myPropInfo = type.GetProperty(value);
            // Display the property name.
            return myPropInfo.Name;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbConnection != null)
                    _dbConnection.Dispose();
            }
        }

        public string SelectAllWithPaging(string orderType, string sortingOrder)
        {
            return SelectAllQuery.ReplaceOrderTypeValue(orderType).ReplaceSortingOrder(sortingOrder);
        }

        #region Query properties
        public abstract string InsertQuery { get; }
        //public virtual string SelectAllFullQuery { get { return this.SelectAllQuery; } }
        //public virtual string SelectByIdFullQuery { get { return this.SelectByIdQuery; } }
        public virtual string SelectAllQuery { get { return Sql.SelectStatements.SelectAllQuery.ReplaceTableName(TableName).ReplaceStarWithConcreteColumns(TableColumns); } }
        public virtual string SelectByIdQuery { get { return Sql.SelectStatements.SelectByIdQuery.ReplaceTableName(TableName).ReplaceStarWithConcreteColumns(TableColumns); } }
        ////private static string GetPagingSubQuery { get { return Constants.PagingQuery; } }
        public abstract string UpdateByIdQuery { get; }
        public virtual string DeleteByIdQuery { get { return Sql.DeleteStatements.DeleteByIdQuery.ReplaceTableName(TableName); } }
        public abstract string TableName { get; }
        public abstract string TableColumns { get; }
        private static string SelectUserIdByPublishCodeQuery { get { return Sql.SelectStatements.SelectUserIdByPublishCode; } }
        public static IDbConnection DBConnection { get { return _dbConnection; } }
        //public string PublishCode { get { return this._publishKey; } set { this._publishKey = value; } }
        #endregion
    }
}
