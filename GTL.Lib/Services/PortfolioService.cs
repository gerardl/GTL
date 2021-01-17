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
        
        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _portfolioRepository.GetProjects();
        }

        public async Task<Project> AddProject(Project project)
        {
            return await _portfolioRepository.AddProject(project);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            return await _portfolioRepository.UpdateProject(project);
        }

        public async Task DeleteProject(int Id)
        {
            await _portfolioRepository.DeleteProject(Id);
        }

        public async Task<ProjectTag> AddProjectTag(ProjectTag projectTag)
        {
            return await _portfolioRepository.AddProjectTag(projectTag);
        }

        public async Task DeleteProjectTag(int Id)
        {
            await _portfolioRepository.DeleteProjectTag(Id);
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _portfolioRepository.GetTags();
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            return await _portfolioRepository.AddTag(tag);
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            return await _portfolioRepository.UpdateTag(tag);
        }

        public async Task DeleteTag(int Id)
        {
            await _portfolioRepository.DeleteTag(Id);
        }
    }
}
