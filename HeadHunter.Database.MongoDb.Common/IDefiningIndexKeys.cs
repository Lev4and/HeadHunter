﻿using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Common
{
    public interface IDefiningIndexKeys<TCollection> where TCollection : ICollection
    {
        IEnumerable<CreateIndexModel<TCollection>> GetIndexKeys();
    }
}
