using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveType,GetLeaveTypeDetailsQuery>()
            .ReverseMap();
        CreateMap<LeaveType, LeaveTypesDto>()
            .ReverseMap();
        CreateMap<LeaveType, GetLeaveTypesDetailsDto>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
    }
}
