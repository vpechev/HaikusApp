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
            string[] usernames = { "849814321", "48549651", "5456464", "454961961", "53454" };

            Random random = new Random();

            return new User()
            {
                Username = Path.GetRandomFileName().Replace(".", ""),
            };
        }

        public static Haiku GenerateHaiku()
        {
            return new Haiku()
            {

            };
        }
    }
}
