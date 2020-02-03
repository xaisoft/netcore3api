using System;
using System.Collections.Generic;
using CaseWebsites.Service.Domain;

namespace CaseWebsites.Service.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects();

        Project GetProjectById(Guid projectId);

        bool UpdateProject(Project projectToUpdate);

        bool DeleteProject(Guid projectId);
    }
}
