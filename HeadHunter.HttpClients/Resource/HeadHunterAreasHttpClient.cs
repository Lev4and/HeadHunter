﻿using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterAreasHttpClient : ResourceHttpClient, IGetAll<Area>
    {
        public HeadHunterAreasHttpClient() : base(ResourceRoutes.HeadHunterAreasPath)
        {

        }

        public async Task<ResponseModel<Area[]>> GetAllAsync()
        {
            return await Get<Area[]>(ResourceRoutes.HeadHunterAreasAllQuery);
        }

        public async Task<ResponseModel<Area>> GetAreaAsync(int id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Area>($"{id}");
        }
    }
}
