using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                            new LeaveType
                            {
                                Id = 1,
                                Name = "Vacation",
                                DefaultDays = 10,
                                CreatedDate = new DateTime(2025, 8, 7, 15, 49, 1, 550, DateTimeKind.Local).AddTicks(290),
                                LastModifiedDate = new DateTime(2025, 8, 9, 15, 49, 1, 550, DateTimeKind.Local).AddTicks(290)
                            },
                            new LeaveType
                            {
                                Id = 2,
                                Name = "Sick Leave",
                                DefaultDays = 5,
                                CreatedDate = new DateTime(2025, 8, 7, 15, 49, 1, 550, DateTimeKind.Local).AddTicks(290),
                                LastModifiedDate = new DateTime(2025, 8, 9, 15, 49, 1, 550, DateTimeKind.Local).AddTicks(290)
                            }
                        );
        }
    }
}
