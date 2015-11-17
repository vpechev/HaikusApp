using Server.Business.DI;
using Server.Business.DI.Interfaces;
using Server.Data.Models.BaseClasses;
using Server.Data.Models.Interfaces;
using Server.Data.Repositories;
using Server.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : IIdentifiable
    {
        private string _publishKey;

        public long GetUserIdByPublishCode(string code)
        {
            if (code != null)
            {
                string hashedCode = PublishCodeEncrypter.GenerateSHA256Hash(code);
                long? userId = BaseRepository<Identifiable>.GetUserIdByPublishCode(hashedCode);
                if (userId.HasValue & (IsAdminPublishCode(hashedCode) || userId > 0) )
                    return userId.Value;
            }
            throw new UnauthorizedAccessException("invalid publish code");
        }

        public bool IsAdminPublishCode(string code)
        {
            return BaseRepository<Identifiable>.IsAdminPublishCode(code);
        }
        
    }
}
