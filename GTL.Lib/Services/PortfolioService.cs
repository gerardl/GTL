using GTL.Lib.Models.Portfolio;
using GTL.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IGenericRepository _genericRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository, IGenericRepository genericRepository)
        {
            _portfolioRepository = portfolioRepository;
            _genericRepository = genericRepository;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _portfolioRepository.GetProjects();
        }

        public async Task<Project> AddProject(Project project)
        {
            return await _genericRepository.AddEntityAsync(project);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            return await _genericRepository.UpdateEntityAsync(project);
        }

        public async Task DeleteProject(int Id)
        {
            await _portfolioRepository.DeleteProject(Id);
        }
    }
}
