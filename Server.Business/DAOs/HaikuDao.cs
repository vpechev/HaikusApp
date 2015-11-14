using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DAOs
{
    public class HaikuDAO : DAOEntity
    {
        public string Text { get; set; }
        public long UserId { get; set; }
        public IList<Rating> Ratings { get; set; }
        public long ActualRating { get; set; }

        public HaikuDAO (Haiku h)
	    {
            this.Id = h.Id;
            this.IsDeleted = h.IsDeleted;
            this.Text = h.Text;
            this.UserId = h.UserId;
            this.ActualRating = h.ActualRating;
                
	    }

        public static IList<HaikuDAO> CovertToHaikuDAO(IList<Haiku> list)
        {
            List<HaikuDAO> daos = new List<HaikuDAO>(list.Count);
            foreach (var dao in list)
            {
                daos.Add(new HaikuDAO(dao));
            }
            return daos;
        }
    }
}
