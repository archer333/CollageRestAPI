﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CollageRestAPI.Hypermedia;
using CollageRestAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository;

namespace CollageRestAPI.Models
{
    //[DataContract(IsReference = true)]
    [CollectionName(DatabaseConfig.GradesCollectionName)]
    public class GradeModel : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Value { get; set; }
        public DateTime IssueDateTime { get; set; }       
        [IgnoreDataMember]
        public MongoDBRef StudentReference { get; set; } = new MongoDBRef("", "");
        //[IgnoreDataMember]
        public MongoDBRef CourseReference { get; set; } = new MongoDBRef("", "");
        //[BsonIgnore]
        public List<Link> Links { get; set; } = new List<Link>();

        //[IgnoreDataMember]
        //[BsonIgnore]
        //public StudentModel Student { get; set; }
        //public MongoDBRef StudentReference { get; set; }
        //[IgnoreDataMember]
        //[BsonIgnore]
        //public StudentModel Student { get; set; } = new StudentModel();
        //[IgnoreDataMember]
        //[BsonIgnore]
        //public CourseModel Course { get; set; } = new CourseModel();
        //public void BeginInit()
        //{

        //}

        //public void EndInit()
        //{
        //    var db = BaseRepository.Instance.StudentsCollection.Collection.Database;
        //    Student = db.FetchDBRefAs<StudentModel>(StudentReference);
        //}
    }
}