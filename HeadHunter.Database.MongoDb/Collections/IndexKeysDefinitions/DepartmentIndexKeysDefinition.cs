﻿using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class DepartmentIndexKeysDefinition : IDefiningIndexKeys<Department>
    {
        public IEnumerable<CreateIndexModel<Department>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Department, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
