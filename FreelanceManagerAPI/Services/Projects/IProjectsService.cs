using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.Projects;
using FreelanceManagerAPI.IO.Tarefas;

namespace FreelanceManagerAPI.Services.Projects
{
    public interface IProjectsService
    {
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetByIdAsync(Guid id);
        Task<ProjectDto> CreateAsync(ProjectModel model);
        Task<ProjectDto> UpdateAsync(Guid id, ProjectModel model);
        Task DeleteAsync(Guid id);
        Task<bool> CanDeleteAsync(Guid id);
        Task<string> GetNextCodeAsync();

        #region ProjectUsers
        Task<ProjectUserDto> GetProjectUserByIdAsync(Guid id);
        Task<ProjectUserDto> CreateProjectUserAsync(ProjectUserModel model);
        Task DeleteProjectUserAsync(ProjectUserModel model);
        Task<bool> CanSaveProjectUserAsync(ProjectUserModel model);
        #endregion
        #region Tarefas
        Task<List<TarefaDto>> GetTarefasAsync(Guid projectId);
        #endregion
    }
}