using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    [Table("Hero")]
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
