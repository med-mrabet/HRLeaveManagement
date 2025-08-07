using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
    public class UpdateLeaveTypeDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int DefaultDays { get; init; }
        public DateTime LastModifiedDate { get; init; }
    }
}
