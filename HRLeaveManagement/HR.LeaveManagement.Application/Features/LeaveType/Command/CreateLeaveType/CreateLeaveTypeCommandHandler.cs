using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CreateLeaveTypeCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<CreateLeaveTypeCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var varlidator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await varlidator.ValidateAsync(request);

            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Type");
            }
            var leaveType = request.leaveType.Adapt<Domain.LeaveType>();

             await _leaveTypeRepository.AddAsync(leaveType);

            return new CreateLeaveTypeCommandResponse { IsSuccess = leaveType.Id != 0 };
        }
    }
}
