using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Test.DataGenerators
{
    public class RandomDataGenerator
    {
        public static User GenerateUser()
        {
            Random random = new Random();

            return new User()
            {
                Username = Path.GetRandomFileName(),
                PublishCode = Path.GetRandomFileName()
            };
        }

        public static Haiku GenerateHaiku()
        {
            StringBuilder text = new StringBuilder(); 
            for (int i = 0; i < new Random().Next(100); i++)
			{
			    text.Append(Path.GetRandomFileName() + " ");
			}
            return new Haiku()
            {
                    Text = text.ToString(),
                    Date = DateTime.Now
            };
        }
    }
}
