using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAPI.Domain;

namespace NetCoreAPI.Services
{
    public class ProjectService : IProjectService
    {
        private List<Project> projects;
        public ProjectService()
        {
            projects = new List<Project>();

            for (int i = 0; i < 5; i++)
            {
                projects.Add(new Project
                {
                    Id = Guid.NewGuid(),
                    Name = $"Project Name {i}",
                    Description = $"Project Description{i}",
                    IsDone = (i % 2 != 0)
                });
            }
        }
        public List<Project> GetProjects()
        {
            return projects;
        }

        public Project GetProjectById(Guid projectId)
        {
            return projects.FirstOrDefault(x => x.Id == projectId);
        }

        public bool UpdateProject(Project projectToUpdate)
        {
            var exists = GetProjectById(projectToUpdate.Id) != null;

            if (!exists)
                return false;

            var index = projects.FindIndex(x => x.Id == projectToUpdate.Id);

            projects[index] = projectToUpdate;

            return true;
        }

        public bool DeleteProject(Guid projectId)
        {
            var project = GetProjectById(projectId);

            if (project == null)
                return false;
            projects.Remove(project);
            return true;
        }
    }
}
