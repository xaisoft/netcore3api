using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAPI.Domain;

namespace NetCoreAPI.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects();

        Project GetProjectById(Guid projectId);

        bool UpdateProject(Project projectToUpdate);

        bool DeleteProject(Guid projectId);
    }
}
