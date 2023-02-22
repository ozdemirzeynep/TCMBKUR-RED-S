using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMB.DATA.Models;

namespace TCMB.DATA.Configurations
{
    public class RequestDataConfiguration: IEntityTypeConfiguration<RequestData>
    {
        public void Configure(EntityTypeBuilder<RequestData> builder)
        {
            builder.ToTable("RequestData");
            builder.HasKey(q => q.Id);
        }
    }
}
