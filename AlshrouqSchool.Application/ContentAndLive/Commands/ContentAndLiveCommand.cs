using AlshrouqSchool.Application.ContentAndLive.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.ContentAndLive.Commands
{
    public record CreateLiveSessionCommand(CreateLiveSessionDto Dto) : IRequest<LiveSessionDto>; 
    public record CreateAttendanceSessionCommand(CreateAttendanceSessionDto Dto) : IRequest<AttendanceSessionDto>;
    public record SaveAttendanceRecordsCommand(SaveAttendanceRecordListDto Dto) : IRequest<bool>; 
    public record UploadMediaCommand(CreateMediaDto Dto) : IRequest<MediaDto>;
}
