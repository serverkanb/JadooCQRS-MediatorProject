﻿using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Commands.DestinationCommands;
using JadooProject.Features.Mediator.Commands.ServiceCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Features.Mediator.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly JadooContext _context;

        public RemoveServiceCommandHandler(JadooContext context)
        {
            _context = context;
        }

      

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Services.FindAsync(request.Id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
