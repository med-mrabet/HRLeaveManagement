using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, UpdateLeaveTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<UpdateLeaveTypeCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.request.Id);
            if(leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.request.Id);
            }
            var mappedData = _mapper.Map<Domain.LeaveType>(request.request);

            mappedData.LastModifiedDate = DateTime.Now;
            await _leaveTypeRepository.UpdateAsync(mappedData);
            return new UpdateLeaveTypeCommandResponse
            {
                isSuccess = true,
            };
        }
    }
}
