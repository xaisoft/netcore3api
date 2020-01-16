using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Contracts.V1.Requests
{
    public class GetProjectRequest
    {
        public Guid ProjectId { get; set; }
    }
}
