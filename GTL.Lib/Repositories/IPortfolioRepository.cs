using GTL.Lib.Models.Portfolio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Repositories
{
    public interface IPortfolioRepository
    {
        Task<List<Project>> GetProjects();
        Task DeleteProject(int Id);
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task<ProjectTag> AddProjectTag(ProjectTag projectTag);
        Task DeleteProjectTag(int Id);
        Task<List<Tag>> GetTags();
        Task<Tag> AddTag(Tag tag);
        Task<Tag> UpdateTag(Tag tag);
        Task DeleteTag(int Id);
    }
}
