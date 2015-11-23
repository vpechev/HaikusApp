using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DAOs
{
    public class UserDTO : DAOEntity
    {
        public string Username { get; set; }
        //public string PublishCode { get; set; }
        //public IList<HaikuDAO> Haikus { get; set; }
        public double ActualRating {get; set; }

        public UserDTO(User u)
        {
            this.Id = u.Id;
            this.IsDeleted = u.IsDeleted;
            this.Username = u.Username;
            this.ActualRating = u.ActualRating;
        }

        public static IList<UserDTO> CovertToUserDTO(IList<User> list)
        {
            List<UserDTO> daos = new List<UserDTO>(list.Count);
            foreach (var dao in list)
            {
                daos.Add(new UserDTO(dao));
            }
            return daos;
        }
    }

    public class FullUserDTO : UserDTO
    {
        public FullUserDTO(User u)
            : base(u)
        {
            this.Haikus = HaikuDTO.CovertToHaikuDTO(u.Haikus);
        }
        public IList<HaikuDTO> Haikus { get; set; }
    }
}
