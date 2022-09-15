﻿using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("areas")]
    public class Area : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("parentId")]
        public ObjectId? ParentId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("headHunterParentId")]
        public string? HeadHunterParentId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("text")]
        public string? Text { get; set; }

        public Area(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            HeadHunterId = area.Id;
            HeadHunterParentId = area.ParentId;
            Name = area.Name;
            Url = area.Url;
            Text = area.Text;
        }
    }
}
