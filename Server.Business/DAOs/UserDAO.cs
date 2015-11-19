using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DAOs
{
    public class UserDAO : DAOEntity
    {
        public string Username { get; set; }
        //public string PublishCode { get; set; }
        //public IList<HaikuDAO> Haikus { get; set; }
        public long ActualRating {get; set; }

        public UserDAO(User u)
        {
            this.Id = u.Id;
            this.IsDeleted = u.IsDeleted;
            this.Username = u.Username;
            this.ActualRating = u.ActualRating;
        }

        public static IList<UserDAO> CovertToUserDAO(IList<User> list)
        {
            List<UserDAO> daos = new List<UserDAO>(list.Count);
            foreach (var dao in list)
            {
                daos.Add(new UserDAO(dao));
            }
            return daos;
        }
    }
}
