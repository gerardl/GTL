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

        public async Task<Project> AddProject(Project project)
        {
            try
            {
                project.DateCreated = Utility.GetServerTime();
                _context.Project.Add(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Project> UpdateProject(Project project)
        {
            try
            {
                var toUpdate = await _context.Project.FindAsync(project.Id);
                if (toUpdate == null) throw new DatabaseKeyNotFoundException($"No project found with id: {project.Id}");

                _context.Entry(toUpdate).CurrentValues.SetValues(project);
                await _context.SaveChangesAsync();
                return project;
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
                var toDelete = await _context.Project.FindAsync(Id);
                if (toDelete == null) throw new DatabaseKeyNotFoundException($"No project found with id: {Id}");

                toDelete.IsDeleted = true;
                toDelete.DateDeleted = Utility.GetServerTime();
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
                var toDelete = await _context.ProjectTag.FindAsync(Id);
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

        public async Task<Tag> AddTag(Tag tag)
        {
            try
            {
                tag.DateCreated = Utility.GetServerTime();
                _context.Tag.Add(tag);
                await _context.SaveChangesAsync();
                return tag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            try
            {
                var toUpdate = await _context.Tag.FindAsync(tag.Id);
                if (toUpdate == null) throw new DatabaseKeyNotFoundException($"No tag found with id: {tag.Id}");

                _context.Entry(toUpdate).CurrentValues.SetValues(tag);
                await _context.SaveChangesAsync();
                return tag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteTag(int Id)
        {
            try
            {
                var toDelete = await _context.Tag.FindAsync(Id);
                if (toDelete == null) throw new DatabaseKeyNotFoundException($"No tag found with id: {Id}");

                toDelete.IsDeleted = true;
                toDelete.DateDeleted = Utility.GetServerTime();
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
