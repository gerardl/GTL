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
    }
}
