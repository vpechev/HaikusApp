using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Managers;
using Server.Data.Enums;
using Server.Data.Repositories;
using Server.Business.DAOs;

namespace Server.Business.Services
{
    public class UserService : BaseService<User>
    {
        private DataManager _dataManager;

        public UserService()
        {
            _dataManager = DataManager.GetDataManager();
        }

        public User Add(User entity)
        {
            if (entity.Username != null && entity.PublishCode != null)
            {
                return _dataManager.CreateInstance<User>().Add(entity);
            }
            else
                throw new MissingInputDataException();
        }

        public UserDAO Get(long id)
        {
            var repo = _dataManager.CreateInstance<User>();
            return new UserDAO(repo.Get(id));
        }

        public IList<User> Get(int skipCount, int takeCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC)
        {
            var repo = _dataManager.CreateInstance<User>();
            return repo.Get(skipCount, takeCount, orderType, sortingOrder);
        }

        public void RemoveUserWithHaikus(string publishCode, long id)
        {
            var repo = (UserRepository)_dataManager.CreateInstance<User>();
            if (base.IsAdminPublishCode(publishCode))
                repo.Remove(id);
            else
                throw new UnauthorizedAccessException("Only admin has the privilege to remove another user");
        }

        public void PromoteToVip(string publishCode, long id)
        {
            if (base.IsAdminPublishCode(publishCode)){
                var repo = (UserRepository)_dataManager.CreateInstance<User>(); 
                ((UserRepository)repo).UpdateToVip(id, true);
            }
            else
                throw new UnauthorizedAccessException("Only admin has the privilege to remove another user");
        }
    }
}
