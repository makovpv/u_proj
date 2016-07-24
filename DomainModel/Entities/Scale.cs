using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{
    [Table(Name = "Scales")]
    public class Scale
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set;}

        [Column] public string name { get; set; }
        [Column] public int test_id { get; set; }
        
        [Column(CanBeNull=true)] 
        public string Description { get; set; }
        [Column(CanBeNull = true)] 
        public string Formula { get; set; }
        [Column] 
        public string abreviature { get; set; }

        [Column]
        public byte ScoreCalcType { get; set; }
        [Column]
        public bool ismain { get; set; }
        [Column(CanBeNull=true)]
        public decimal? Min_Value { get; set; }
        [Column(CanBeNull = true)]
        public decimal? Max_Value { get; set; }

        //[Column(CanBeNull = true, DbType = "smallint")]
        //public System.Nullable<int> max_value { get;set;}
    }

    [Table(Name = "ScoreCalcType")]
    public class ScoreCalcType
    {
        [Column (IsPrimaryKey = true)]
        public byte id { get; set; }
        [Column]
        public string name { get; set; }
    }
}
