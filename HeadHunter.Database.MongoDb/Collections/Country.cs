﻿using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("countries")]
    public class Country : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public Country(Models.Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            HeadHunterId = country.Id;
            Url = country.Url;
            Name = country.Name;
        }
    }
}
