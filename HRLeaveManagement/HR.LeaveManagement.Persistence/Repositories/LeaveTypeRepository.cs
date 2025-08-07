using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrDatabaseContext context;

        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> ExistByName(string name)
        {
            return await context.LeaveTypes.AnyAsync(x => x.Name == name);
        }

    }



}
