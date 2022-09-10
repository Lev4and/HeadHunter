﻿using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Department.Find
{
    public class Command : IRequest<Collections.Department>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
