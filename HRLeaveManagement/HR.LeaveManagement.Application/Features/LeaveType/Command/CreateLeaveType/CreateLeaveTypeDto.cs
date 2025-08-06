namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class  CreateLeaveTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
