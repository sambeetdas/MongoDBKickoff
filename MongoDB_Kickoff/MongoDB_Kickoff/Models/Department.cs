using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDB_Kickoff.Models
{
    public class Department
    {
        //public ObjectId DeptId { get; set; }

       [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string DeptId { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentLead { get; set; }
    }
}