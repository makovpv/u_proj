using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{

    //static object Dictionary

    //enum IdeaState { }
    
    [Table(Name = "idea")]
    public class Idea
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column]
        public string Resume { get; set; }

        [Column]
        public int idOwnerSubject { get; set; }
        public Subject OwnerSubject { get; set; }
        
        [Column]
        public byte idState {get; set;}
    }
}
