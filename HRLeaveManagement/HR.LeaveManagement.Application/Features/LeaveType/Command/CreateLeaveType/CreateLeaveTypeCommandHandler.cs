using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
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
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
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
            var leaveType = _mapper.Map<Domain.LeaveType>(request.leaveType);

             await _leaveTypeRepository.AddAsync(leaveType);

            return new CreateLeaveTypeCommandResponse { IsSuccess = leaveType.Id != 0 };
        }
    }
}
