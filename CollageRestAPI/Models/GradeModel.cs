﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CollageRestAPI.Hypermedia;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository;

namespace CollageRestAPI.Models
{
    //[DataContract(IsReference = true)]
    [CollectionName(DatabaseConfig.GradesCollectionName)]
    public class GradeModel : IEntity<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public double Value { get; set; }
        public DateTime IssueDateTime { get; set; }
        public List<Link> Links { get; set; }
        [IgnoreDataMember]
        [BsonIgnore]
        public StudentModel Student { get; set; }
        public MongoDBRef StudentReference { get; set; }
        //[IgnoreDataMember]
        //[BsonIgnore]
        //public StudentModel Student { get; set; } = new StudentModel();
        //[IgnoreDataMember]
        //[BsonIgnore]
        //public CourseModel Course { get; set; } = new CourseModel();
    }
}