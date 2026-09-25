using AlshrouqSchool.Application.ContentAndLive.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.ContentAndLive.Queries
{
    public record GetLiveSessionsBySectionQuery(int SectionId) : IRequest<List<LiveSessionDto>>; 
    public record GetAttendanceBySessionQuery(int AttendanceSessionId) : IRequest<List<AttendanceRecordDto>>; 
    public record GetMediaQuery(int Id) : IRequest<MediaDto?>; 
}
