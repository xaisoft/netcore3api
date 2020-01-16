using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Contracts.V1.Requests;
using NetCoreAPI.Contracts.V1.Responses;
using NetCoreAPI.Domain;
using NetCoreAPI.Services;

namespace NetCoreAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _projectService.GetProjects();

            List<GetProjectResponse> getProjectResponses = new List<GetProjectResponse>();

            foreach (var project in projects)
            {
                getProjectResponses.Add(new GetProjectResponse{Id = project.Id,Name=project.Name,Description = project.Description,IsDone = project.IsDone});
            }

            return Ok(getProjectResponses);
        }

        // GET api/values/5
        [HttpGet("{projectId}")]
        public IActionResult Get([FromRoute]Guid projectId)
        {
            var project = _projectService.GetProjectById(projectId);

            if (project == null)
                return NotFound("Project not found");

            var getProjectResponse = new GetProjectResponse
                {Id = project.Id, Name = project.Name, Description = project.Description, IsDone = project.IsDone};

            return Ok(getProjectResponse);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectRequest createProjectRequest)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = createProjectRequest.Name,
                Description = createProjectRequest.Description
            };

            var response = new CreateProjectResponse {Id = project.Id};


            return Created($"{HttpContext.Request.Scheme}://" +
                           $"{HttpContext.Request.Host.ToUriComponent()}" +
                           $"/api/v1/projects/${response.Id}", response);

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateProjectRequest updateProjectRequest)
        {
            var project = new Project
            {
                Id = updateProjectRequest.Id,
                Name = updateProjectRequest.Name,
                Description = updateProjectRequest.Description,
                IsDone = updateProjectRequest.IsDone
            };

            var updated = _projectService.UpdateProject(project);

            if (updated)
            {
                var getProjectResponse = new GetProjectResponse
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    IsDone = project.IsDone
                };

                return Ok(getProjectResponse);
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{projectId}")]
        public IActionResult Delete([FromRoute] Guid projectId)
        {
            var deleted = _projectService.DeleteProject(projectId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
