﻿using Server.Data.Models.Interfaces;
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

namespace Server.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : IIdentifiable
    {
        #region Fields
        private IDbConnection _dbConnection;
        private long _userId;
        #endregion

        #region Constructors
        protected BaseRepository()
        {
            _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        }

        protected BaseRepository(long userId) : this()
        {
            this._userId = userId;
        }

        protected BaseRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        protected BaseRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        #endregion

        #region CRUD Operations
        //public virtual T GetProjection(long id)
        //{
        //    T res = _dbConnection.Query<T>(SelectByIdQuery, new { Id = id }).FirstOrDefault<T>();
        //    if (res == null)
        //        throw new KeyNotFoundException();

        //    return res;
        //}

        //public virtual T GetFull(long id)
        //{
        //    return this.GetProjection(id);
        //}

        //public virtual IList<T> Get()
        //{
        //    IList<T> res = _dbConnection.Query<T>(SelectAllQuery).ToList();

        //    return res;
        //}

        //public virtual IList<T> GetFull()
        //{
        //    return this.Get();
        //}

        //public virtual IList<T> GetFull(int offsetCount, int entitiesCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC)
        //{
        //    return this.GetProjection(offsetCount, entitiesCount, orderType);
        //}

        //public virtual IList<T> GetProjection(int offsetCount, int entitiesCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC)
        //{
        //    string orderValue;
        //    try
        //    {
        //        orderValue = FindProperty(typeof(T), orderType);
        //    }
        //    catch (ArgumentNullException)
        //    {
        //        orderValue = "Id";
        //        //throw new ArgumentException("The property does not exist", e);
        //    }

        //    return DBConnection.Query<T>(SelectAllWithPaging(orderValue, sortingOrder.ToString()), new { UserId = this.UserId, OffsetCount = offsetCount, FetchedElements = entitiesCount }).ToList();
        //}

        public abstract T Add(T entity);

        public abstract T Update(T entity);

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

        //public string SelectAllFullWithPaging(string orderType, string sortingOrder)
        //{
        //    return SelectAllFullQuery.ReplaceOrderTypeValue(orderType).ReplaceSortingOrder(sortingOrder);
        //}

        //public string SelectAllWithPaging(string orderType, string sortingOrder)
        //{
        //    return SelectAllQuery.ReplaceOrderTypeValue(orderType).ReplaceSortingOrder(sortingOrder);
        //}

        #region Query properties
        public abstract string InsertQuery { get; }
        public virtual string SelectAllFullQuery { get { return this.SelectAllQuery; } }
        public virtual string SelectByIdFullQuery { get { return this.SelectByIdQuery; } }
        public virtual string SelectAllQuery { get { return Sql.SelectStatements.SelectAllQuery.ReplaceTableName(TableName).ReplaceStarWithConcreteColumns(TableColumns); } }
        public virtual string SelectByIdQuery { get { return Sql.SelectStatements.SelectByIdQuery.ReplaceTableName(TableName).ReplaceStarWithConcreteColumns(TableColumns); } }
        ////private static string GetPagingSubQuery { get { return Constants.PagingQuery; } }
        public abstract string UpdateByIdQuery { get; }
        public virtual string DeleteByIdQuery { get { return Sql.DeleteStatements.DeleteByIdQuery.ReplaceTableName(TableName); } }
        public abstract string TableName { get; }
        public abstract string TableColumns { get; }
        public long UserId { get { return _userId; } private set { _userId = value; } }
        public IDbConnection DBConnection { get { return _dbConnection; } }
        #endregion
    }
}
