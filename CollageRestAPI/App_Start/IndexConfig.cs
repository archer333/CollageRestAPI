﻿using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;

namespace CollageRestAPI
{
    [CollectionName("indexconfig")]
    public class IndexConfig : IEntity<Guid>
    {
        private static readonly Lazy<IndexConfig> lazy =
        new Lazy<IndexConfig>(() => new IndexConfig());
        public static IndexConfig Instance { get { return lazy.Value; } }
        private IndexConfig(){}

        [BsonId]
        public Guid Id { get; set; }
        public int CurrentIndex { get; set; }
    }
}