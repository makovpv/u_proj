using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{
    [Table (Name="test_question")]
    public class Block
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column]
        public Int16? number { get; set; }
        [Column]
        public string text { get; set; }
        [Column]
        public string comment { get; set; }
        [Column]
        public string instruction { get; set; }
        [Column]
        public bool isShuffledItem { get; set; }
        [Column]
        public bool isShuffledAns { get; set; }
        [Column]
        public bool isTimeRestricted { get; set; }
        [Column]
        public int test_id { get; set; }

        //public Test test { get; set; }

        
    }
}
