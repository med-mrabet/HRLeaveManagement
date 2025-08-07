using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveType,GetLeaveTypeDetailsQuery>()
                .ReverseMap();

            CreateMap<LeaveType, GetLeaveTypesDetailsDto>();
            CreateMap<LeaveType, CreateLeaveTypeDto>();
            CreateMap<LeaveType, UpdateLeaveTypeDto>();
        }
    }
}
