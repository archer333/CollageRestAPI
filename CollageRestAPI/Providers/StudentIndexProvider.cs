﻿using CollageRestAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollageRestAPI.Repositories;

namespace CollageRestAPI.Providers
{
    public class StudentIndexProvider
    {
        private static readonly Lazy<StudentIndexProvider> lazy =
        new Lazy<StudentIndexProvider>(() => new StudentIndexProvider());
        public static StudentIndexProvider Instance { get { return lazy.Value; } }
        private StudentIndexProvider()
        {
            SetCurrentIndex();
        }

        private int _currentIndex;

        public int currentIndex
        {
            get
            {
                _currentIndex++;
                System.Diagnostics.Debug.WriteLine("======111========= " + _currentIndex + " ========111=======");
                var collection = BaseRepository.Instance.Db.GetCollection<BsonDocument>("studentindexprovider");
                //var filter = Builders<BsonDocument>.Filter.
                var update = Builders<BsonDocument>.Update.Set("currentIndex", _currentIndex);
                collection.UpdateOne(Builders<BsonDocument>.Filter.Empty, update);
                //collection.AsQueryable().Single().
                //collection.AsQueryable().Single().Set("currentIndex", _currentIndex);
                //collection.Find(new BsonDocument()).FirstOrDefault().Set("currentIndex", currentIndex);
                return _currentIndex;
            }
            set { _currentIndex = value; }
        }
        
        //public int GetNewIndex()
        //{
        //    return ++currentIndex;
        //}
        private void SetCurrentIndex()
        {
            var collection = BaseRepository.Instance.Db.GetCollection<BsonDocument>("studentindexprovider");
            _currentIndex = collection.AsQueryable().Single().Elements.Single(x => x.Name == "currentIndex").Value.ToInt32();
            System.Diagnostics.Debug.WriteLine("================== " + _currentIndex + " ==================");
            //currentIndex = collection.Find(new BsonDocument()).FirstOrDefault().Elements.Single(x => x.Name == "currentIndex").Value.ToInt32();
            //System.Diagnostics.Debug.WriteLine(col.Find(new BsonDocument()).FirstOrDefault().ToString());
            //System.Diagnostics.Debug.WriteLine(col.Find(new BsonDocument()).FirstOrDefault().Elements.Single(x => x.Name == "currentIndex").Value);
            //currentIndex = BaseRepository.Instance.Db.GetCollection("")
        }
    }
}