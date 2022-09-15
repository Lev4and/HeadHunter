﻿using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("workingtimemodes")]
    public class WorkingTimeMode : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public WorkingTimeMode(Models.WorkingTimeMode workingTimeMode)
        {
            if (workingTimeMode == null)
            {
                throw new ArgumentNullException(nameof(workingTimeMode));
            }

            HeadHunterId = workingTimeMode.Id;
            Name = workingTimeMode.Name;
        }
    }
}
