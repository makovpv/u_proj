using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{
    [Table (Name="Test")]
    public class Test
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.OnInsert)]
        public int id { get; set; }

        [Column]public string name { get; set; }
        [Column]public string author { get; set; }
        [Column]public string tags { get; set; }


        public IQueryable<Scale> Scales { get; set; }

        //public void Create()
        //{ 
        //}
    }
}
