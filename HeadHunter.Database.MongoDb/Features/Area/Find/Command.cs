﻿using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Area.Find
{
    public class Command : IRequest<Collections.Area>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
