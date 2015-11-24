using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DAOs
{
    public class HaikuDTO : DAOEntity
    {
        public string Text { get; set; }
        public long UserId { get; set; }
        public IList<Rating> Ratings { get; set; }
        public double ActualRating { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }

        public HaikuDTO (Haiku h)
	    {
            this.Id = h.Id;
            this.IsDeleted = h.IsDeleted;
            this.Text = h.Text;
            this.UserId = h.UserId;
            this.ActualRating = h.ActualRating;
            this.Date = h.Date;
            this.Username = h.Username;    
	    }

        public static IList<HaikuDTO> CovertToHaikuDTO(IList<Haiku> list)
        {
            List<HaikuDTO> daos = new List<HaikuDTO>(list.Count);
            foreach (var dao in list)
            {
                daos.Add(new HaikuDTO(dao));
            }
            return daos;
        }
    }
}
