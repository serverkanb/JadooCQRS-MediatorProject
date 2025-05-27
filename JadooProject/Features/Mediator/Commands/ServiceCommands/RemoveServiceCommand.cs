﻿using MediatR;

namespace JadooProject.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveServiceCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
