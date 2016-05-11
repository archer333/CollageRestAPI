﻿using System;
using System.Collections.Generic;
using CollageRestAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository;

namespace CollageRestAPI.Repositories
{
    public sealed class BaseRepository
    {
        //public MongoClient DbClient { get; set; }
        //public IMongoDatabase Db { get; set; }
        private readonly MongoDatabase _db = Instance.StudentsCollection.Collection.Database;

        private static readonly Lazy<BaseRepository> lazy =
        new Lazy<BaseRepository>(() => new BaseRepository());
        public static BaseRepository Instance { get { return lazy.Value; } }
        private BaseRepository(){}

        public T Fetch<T>(MongoDBRef reference)
        {
            return _db.FetchDBRefAs<T>(reference);
        }

        //public List<StudentModel> StudentsCollection { get; set; } = new List<StudentModel>();
        //public List<CourseModel> CoursesCollection { get; set; } = new List<CourseModel>();

        public MongoRepository<StudentModel, int> StudentsCollection { get; set; } = new MongoRepository<StudentModel, int>();
        public MongoRepository<CourseModel, ObjectId> CoursesCollection { get; set; } = new MongoRepository<CourseModel, ObjectId>();
        public MongoRepository<GradeModel, ObjectId> GradesCollection { get; set; } = new MongoRepository<GradeModel, ObjectId>();
        public MongoRepository<IndexConfig, ObjectId> CurrentIndexConfig { get; set; } = new MongoRepository<IndexConfig, ObjectId>();
    }
}