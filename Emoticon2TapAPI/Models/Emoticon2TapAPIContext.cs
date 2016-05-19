using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emoticon2TapAPI.Models
{
    public class Emoticon2TapAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Emoticon2TapAPIContext() : base("name=Emoticon2TapAPIContext")
        {
        }

        public System.Data.Entity.DbSet<Emoticon2TapAPI.Models.Score> Scores { get; set; }
    }
}
