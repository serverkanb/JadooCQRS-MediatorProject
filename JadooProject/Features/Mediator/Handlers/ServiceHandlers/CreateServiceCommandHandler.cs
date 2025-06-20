﻿using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.ServiceCommands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace JadooProject.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly JadooContext _context;

        public CreateServiceCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service()
            {
                Description = request.Description,
                Icon = request.Icon,
                Title = request.Title
            };
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }
    }
}
