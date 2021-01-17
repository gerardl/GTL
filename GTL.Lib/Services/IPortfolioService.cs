using GTL.Lib.Models.Portfolio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Services
{
    public interface IPortfolioService
    {
        Task<List<Project>> GetProjects();
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task DeleteProject(int Id);
    }
}
