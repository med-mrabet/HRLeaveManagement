using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrDatabaseContext context;

        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests.Include(p=>p.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(p=>p.LeaveType)
                .FirstOrDefaultAsync(p=>p.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(p=>p.RequestingEmployeeId  == userId)
                .Include(p=>p.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }



}
