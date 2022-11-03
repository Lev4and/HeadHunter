﻿using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class BillingTypeIndexKeysDefinition : IDefiningIndexKeys<BillingType>
    {
        public IEnumerable<CreateIndexModel<BillingType>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<BillingType, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
