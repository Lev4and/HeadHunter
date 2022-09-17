﻿using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterLanguagesHttpClient : ResourceHttpClient, IGetAll<Language>
    {
        public HeadHunterLanguagesHttpClient() : base(ResourceRoutes.HeadHunterLanguagesPath)
        {

        }

        public async Task<ResponseModel<Language[]>> GetAllAsync()
        {
            return await Get<Language[]>(ResourceRoutes.HeadHunterLanguagesAllQuery);
        }
    }
}
