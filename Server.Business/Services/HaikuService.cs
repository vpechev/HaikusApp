using Server.Business.DAOs;
using Server.Business.Exceptions;
using Server.Data.Enums;
using Server.Data.Managers;
using Server.Data.Models;
using Server.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Services
{
    public class HaikuService : BaseService<Haiku>
    {
        private DataManager _dataManager;

        public HaikuService()
        {
            _dataManager = DataManager.GetDataManager();
        }

        public Haiku Add(Haiku entity, string publishCode)
        {
            var repo = _dataManager.CreateInstance<Haiku>(publishCode);
            repo.GetUserIdByPublishCode(publishCode);       //simple level of security just checks whether there exists user with such publishCode 
            return repo.Add(entity);
        }

        public void Remove(long id, string publishCode)
        {
            var repo = _dataManager.CreateInstance<Haiku>(publishCode);
            repo.GetUserIdByPublishCode(publishCode);       //simple level of security just checks whether there exists user with such publishCode 
            repo.Remove(id);
        }

        public void Update(Haiku entity, string publishCode)
        {
            var repo = _dataManager.CreateInstance<Haiku>(publishCode);
            repo.GetUserIdByPublishCode(publishCode);       //simple level of security just checks whether there exists user with such publishCode 
            repo.Update(entity);
        }

        public IList<HaikuDAO> Get(int skipCount, int takeCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC)
        {
            var repo = _dataManager.CreateInstance<Haiku>();
            return HaikuDAO.CovertToHaikuDAO(repo.Get(skipCount, takeCount, orderType, sortingOrder));
        }

        public HaikuDAO RateHaiku(long haikuId, int ratingValue)
        {
            if (ratingValue < 0 || ratingValue > 5)
                throw new InvalidRatingValueException();
            var repo = _dataManager.CreateInstance<Haiku>();
            return new HaikuDAO(((HaikuRepository)repo).UpdateHaikuRating(haikuId, ratingValue));

        }

        public void DeleteAllHaikusPerUser(string publishCode)
        {
            var repo = _dataManager.CreateInstance<Haiku>(publishCode);
            long userId = repo.GetUserIdByPublishCode(publishCode);
            ((HaikuRepository)repo).DeleteAllHaikusByUserId(userId);
        }

        public void AddComplaint(long haikuId)
        {
            if (haikuId > 0)
            {
                var repo = _dataManager.CreateInstance<Haiku>();
                ((HaikuRepository)repo).AddHaikuCompliant(haikuId);
            }
            else
                throw new MissingInputDataException();
        }

    }
}
