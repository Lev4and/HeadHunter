﻿using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("employers")]
    public class Employer : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("trusted")]
        public bool? Trusted { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("blacklisted")]
        public bool? Blacklisted { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public long HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("siteUrl")]
        public string? SiteUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("alternateUrl")]
        public string? AlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("vacanciesUrl")]
        public string? VacanciesUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("brandedDescription")]
        public string? BrandedDescription { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("area")]
        public Area? Area { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("logoUrls")]
        public LogoUrls? LogoUrls { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("industries")]
        public List<Industry> Industries { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("insiderInterviews")]
        public List<InsiderInterview> InsiderInterviews { get; set; }

        public Employer(Models.Employer employer)
        {
            if (employer == null)
            {
                throw new ArgumentNullException(nameof(employer));
            }

            Trusted = employer.Trusted;
            Blacklisted = employer.Blacklisted;
            HeadHunterId = Convert.ToInt64(employer.Id);
            Name = employer.Name;
            Url = employer.Url;
            Type = employer.Type;
            SiteUrl = employer.SiteUrl;
            Description = employer.Description;
            AlternateUrl = employer.AlternateUrl;
            VacanciesUrl = employer.VacanciesUrl;
            BrandedDescription = employer.BrandedDescription;
            Area = employer.Area != null ? new Area(employer.Area) : null;
            LogoUrls = employer.LogoUrls != null ? new LogoUrls(employer.LogoUrls) : null;
            Industries = employer.Industries.Select(industry => new Industry(industry)).ToList();
            InsiderInterviews = employer.InsiderInterviews.Select(insiderInterview => new InsiderInterview(insiderInterview)).ToList();
        }
    }
}
