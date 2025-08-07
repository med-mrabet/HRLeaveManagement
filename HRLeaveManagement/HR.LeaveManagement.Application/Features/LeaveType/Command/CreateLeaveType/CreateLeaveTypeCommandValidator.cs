using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _repository;

        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository repository)
        {
            RuleFor( p => p.leaveType.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p=> p.leaveType.DefaultDays)
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than 0")
                .LessThanOrEqualTo(30).WithMessage("{PropertyName} must not exceed 30 days");

            RuleFor(p => p)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Name of leave type must be unique");
            this._repository = repository;
        }

        private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return await this._repository.ExistByName(command.leaveType.Name);
        }
    }
}
