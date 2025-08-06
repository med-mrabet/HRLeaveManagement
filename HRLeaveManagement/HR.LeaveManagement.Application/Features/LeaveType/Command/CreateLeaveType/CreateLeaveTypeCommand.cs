using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public record CreateLeaveTypeCommand(CreateLeaveTypeDto leaveType) : IRequest<CreateLeaveTypeCommandResponse>;

}
