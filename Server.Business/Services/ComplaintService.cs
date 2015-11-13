using Server.Data.Enums;
using Server.Data.Managers;
using Server.Data.Models;
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

        public IList<Complaint> Get(int skipCount, int takeCount)
        {
            return _dataManager.CreateInstance<Complaint>().Get(skipCount, takeCount, null, SortingOrder.ASC);
        }
    }
}
