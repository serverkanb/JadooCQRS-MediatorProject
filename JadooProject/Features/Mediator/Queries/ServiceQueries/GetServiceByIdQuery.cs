﻿using JadooProject.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace JadooProject.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
