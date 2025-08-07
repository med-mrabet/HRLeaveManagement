using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public record GetLeaveAllocationDetailQuery(int id) : IRequest<LeaveAllocationDetailsDto>;

}
