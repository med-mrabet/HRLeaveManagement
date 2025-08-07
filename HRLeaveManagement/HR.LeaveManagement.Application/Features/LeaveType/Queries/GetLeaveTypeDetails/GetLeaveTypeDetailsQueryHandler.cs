using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypesDetailsDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository)
        {
        
            _leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<GetLeaveTypesDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = _leaveTypeRepository.GetByIdAsync(request.id);
            if(leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType),request.id);
            }
            var mappedRequest = leaveType.Adapt<GetLeaveTypesDetailsDto>();

            return  mappedRequest;
        }
    }
}
