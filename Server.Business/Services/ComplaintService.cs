﻿using Server.Data.Enums;
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
    public class ComplaintService : BaseService<Complaint>
    {
        private DataManager _dataManager;

        public ComplaintService()
        {
            _dataManager = DataManager.GetDataManager();
        }

        public IList<Complaint> Get(int skipCount, int takeCount, string publishCode)
        {
            if (base.IsAdminPublishCode(publishCode)){
                var repo = (ComplaintRepository)_dataManager.CreateInstance<Complaint>();
                return repo.Get(skipCount, takeCount, null, SortingOrder.ASC);
            }
            else
                throw new UnauthorizedAccessException("Only admin can retrieve list of complaints");
        }

        public Complaint Add(Complaint entity)
        {
            return _dataManager.CreateInstance<Complaint>().Add(entity);
        }
    }
}
