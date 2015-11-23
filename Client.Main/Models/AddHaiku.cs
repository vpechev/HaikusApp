using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Main.Models
{
    public class AddHaiku
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string PublishCode { get; set; }
    }
}