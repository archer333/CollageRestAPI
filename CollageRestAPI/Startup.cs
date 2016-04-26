﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using MongoDB.Driver;
using CollageRestAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using CollageRestAPI.Providers;
using System.Collections;
using CollageRestAPI.Repositories;

[assembly: OwinStartup(typeof(CollageRestAPI.Startup))]

namespace CollageRestAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DbInit();
            DbTest();
            ConfigureAuth(app);
        }

        private void DbInit()
        {
            BsonClassMap.RegisterClassMap<BaseRepository>(x => x.AutoMap());
            BsonClassMap.RegisterClassMap<StudentModel>(x => x.AutoMap());
            BsonClassMap.RegisterClassMap<CourseModel>(x => x.AutoMap());
            BsonClassMap.RegisterClassMap<GradeModel>(x => x.AutoMap());
            BsonClassMap.RegisterClassMap<StudentIndexProvider>(x => x.AutoMap());

            var dbClient = BaseRepository.Instance.DbClient;
            //var db = BaseRepository.Instance.Db;
            dbClient = new MongoClient("mongodb://localhost");
            BaseRepository.Instance.Db = dbClient.GetDatabase("collagerestapi");
            BaseRepository.Instance.Db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
            System.Diagnostics.Debug.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        }

        private void DbTest()
        {
            System.Diagnostics.Debug.WriteLine("XXXXXXXXXXXXXXXXX    DB TEST  IN  XXXXXXXXXXXXXXXXXXXXX");
            //StudentIndexProvider.Instance.SetCurrentIndex();
            List<StudentModel> students = new List<StudentModel>();
            for (int i = 0; i < 5; i++)
            {
                var student = new StudentModel();
                student.FirstName = "imie" + i;
                student.LastName = "nazwisko" + i;
                student.Id = StudentIndexProvider.Instance.currentIndex;
                students.Add(student);
            }
            BaseRepository.Instance.Students.AddRange(students);
            var db = BaseRepository.Instance.Db;
            //if(db.ListCollections().ForEachAsync(x => x.))
            //var list = db.ListCollections();
            //if(db.GetCollection("students").)
            var collection = db.GetCollection<StudentModel>("students");//.InsertMany(BaseRepository.Instance.Students);
            collection.InsertMany(students);
            System.Diagnostics.Debug.WriteLine("XXXXXXXXXXXXXXXXX    DB TEST  OUT XXXXXXXXXXXXXXXXXXXXX");
        }
    }
}
