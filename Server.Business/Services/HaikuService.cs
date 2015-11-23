using Server.Business.DAOs;
using Server.Business.Enums;
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
            entity.Date = DateTime.Now;
            var repo = (HaikuRepository)_dataManager.CreateInstance<Haiku>(publishCode);
            long userId = base.GetUserIdByPublishCode(publishCode);       //simple level of security just checks whether there exists user with such publishCode 
            return repo.Add(entity, userId);
        }

        public void Remove(long id, string publishCode)
        {
            var repo = (HaikuRepository)_dataManager.CreateInstance<Haiku>(publishCode);
            base.GetUserIdByPublishCode(publishCode);       //simple level of security just checks whether there exists user with such publishCode 
            repo.Remove(id);
        }

        public HaikuDTO Get(long id)
        {
            var repo = _dataManager.CreateInstance<Haiku>();
            return new HaikuDTO(repo.Get(id));
        }

        public IList<HaikuDTO> Get(int skipCount, int takeCount, HaikuSortBy orderType = HaikuSortBy.RatingValue, SortingOrder sortingOrder = SortingOrder.ASC)
        {
            var repo = _dataManager.CreateInstance<Haiku>();
            return HaikuDTO.CovertToHaikuDTO(repo.Get(skipCount, takeCount, orderType.ToString(), sortingOrder));
        }


        public void Update(Haiku entity, string publishCode)
        {
            var repo = (HaikuRepository)_dataManager.CreateInstance<Haiku>(publishCode);
            long userId = base.GetUserIdByPublishCode(publishCode);
            repo.Update(entity, userId);
        }
        
        public HaikuDTO RateHaiku(long haikuId, int ratingValue)
        {
            if (ratingValue < 0 || ratingValue > 5)
                throw new InvalidRatingValueException();
            var repo = _dataManager.CreateInstance<Haiku>();
            return new HaikuDTO(((HaikuRepository)repo).UpdateHaikuRating(haikuId, ratingValue));

        }

        public void DeleteAllHaikusPerUser(string publishCode)
        {
            var repo = (HaikuRepository)_dataManager.CreateInstance<Haiku>(publishCode);
            long userId = base.GetUserIdByPublishCode(publishCode);
            ((HaikuRepository)repo).DeleteAllHaikusByUserId(userId);
        }

        public void Delete(long id, string publishCode)
        {
            var repo = (HaikuRepository)_dataManager.CreateInstance<Haiku>(publishCode);
            base.GetUserIdByPublishCode(publishCode);
            ((HaikuRepository)repo).Remove(id);
        }

        //public void AddComplaint(long haikuId)
        //{
        //    if (haikuId > 0)
        //    {
        //        var repo = _dataManager.CreateInstance<Haiku>();
        //        ((HaikuRepository)repo).AddHaikuCompliant(new Complaint(){
        //            HaikuId = haikuId,
        //            Date = DateTime.Now
        //        });
        //    }
        //    else
        //        throw new MissingInputDataException();
        //}

    }
}
