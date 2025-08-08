using HR.LeaveManagement.Application.Contracts.Persistence;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestsDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            this._leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<List<LeaveRequestsDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
        {

            var leaveRequests = new List<Domain.LeaveRequest>();
            var requests = new List<LeaveRequestsDto>();

            // Check if it is logged in employee
            if (request.IsLoggedInUser)
            {
                var userId = _userService.UserId;
                leaveRequests =  _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                requests = leaveRequests.Adapt<List<LeaveRequestsDto>>();
                foreach (var req in requests)
                {
                    req.Employee = employee;
                }
            }
            else
            {
                leaveRequests =  _leaveRequestRepository.GetLeaveRequestsWithDetails();
                requests = leaveRequests.Adapt<List<LeaveRequestsDto>>();
                foreach (var req in requests)
                {
                    req.Employee = await _userService.GetEmployee(req.RequestingEmployeeId);
                }
            }

            return requests;
        }
    }
}
