using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Utils;
using System.Security.Cryptography;

namespace Server.Data.Constants
{
    public class Constants
    {
        public static IList<string> AdminKeys = new List<string>(){
             PublishCodeEncrypter.GenerateSHA256Hash("some admin key")
             //"some admin key"
        };
    }
}
