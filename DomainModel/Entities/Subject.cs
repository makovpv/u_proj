using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{
    [Table(Name = "Test_Subject")]
    public class Subject
    {
        [Column]
        public int id { get; set; }
    }
}
