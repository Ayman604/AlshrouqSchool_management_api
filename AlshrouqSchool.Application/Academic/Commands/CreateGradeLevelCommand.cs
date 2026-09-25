using AlshrouqSchool.Application.Academic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Academic.Commands
{
    public record CreateGradeLevelCommand(CreateGradeLevelDto Dto) : IRequest<GradeLevelDto>;
}
