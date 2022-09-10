﻿using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Find
{
    public class Command : IRequest<Collections.WorkingTimeInterval>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
