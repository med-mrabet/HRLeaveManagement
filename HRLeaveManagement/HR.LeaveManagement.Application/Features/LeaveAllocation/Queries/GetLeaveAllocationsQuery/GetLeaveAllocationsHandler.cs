using HR.LeaveManagement.Application.Contracts.Persistence;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationsQuery
{
    public class GetLeaveAllocationsHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>?>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public GetLeaveAllocationsHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<List<LeaveAllocationDto>>? Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations =  _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            var allocations = leaveAllocations.Adapt<List<LeaveAllocationDto>>();

            return allocations;
        }
    }



}
