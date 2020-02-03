using System;

namespace CaseWebsites.Service.Contracts.V1.Requests
{
    public class UpdateProjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
