﻿using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingTimeModeIndexKeysDefinition : IDefiningIndexKeys<WorkingTimeMode>
    {
        public IEnumerable<CreateIndexModel<WorkingTimeMode>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<WorkingTimeMode, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
