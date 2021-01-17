using GTL.Lib.Exceptions;
using GTL.Lib.Models;
using GTL.Lib.Models.Portfolio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Lib.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly AppDbContext _context;

        public PortfolioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjects()
        {
            try
            {
                return await _context.Project
                                    .Include(i => i.ProjectTags)
                                        .ThenInclude(t => t.Tag)
                                    .Where(w => !w.IsDeleted)
                                    .OrderByDescending(o => o.DateCreated)
                                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProject(int Id)
        {
            try
            {
                var toDelete = await _context.Project.SingleOrDefaultAsync(s => s.Id == Id);
                if (toDelete == null) throw new DatabaseKeyNotFoundException($"No project found with id: {Id}");

                toDelete.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectTag> AddProjectTag(ProjectTag projectTag)
        {
            try
            {
                _context.ProjectTag.Add(projectTag);
                await _context.SaveChangesAsync();
                return projectTag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProjectTag(int Id)
        {
            try
            {
                var toDelete = await _context.ProjectTag.SingleOrDefaultAsync(s => s.Id == Id);
                if (toDelete == null) throw new DatabaseKeyNotFoundException($"No project tag found with id: {Id}");

                _context.ProjectTag.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tag>> GetTags()
        {
            try
            {
                return await _context.Tag
                                .OrderBy(o => o.Name)
                                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
