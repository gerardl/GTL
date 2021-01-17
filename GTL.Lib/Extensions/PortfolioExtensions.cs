using GTL.Lib.Models.Portfolio;
using GTL.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTL.Lib.Extensions
{
    public static class PortfolioExtensions
    {
        #region Projects

        public static ProjectViewModel ToViewModel(this Project project)
        {
            try
            {
                if (project == null) return null;

                return new ProjectViewModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    DemoUrl = project.DemoUrl,
                    ImageUrl = project.ImageUrl,
                    RepositoryUrl = project.RepositoryUrl,
                    ProjectTags = project?.ProjectTags?.ToViewModel()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ProjectViewModel> ToViewModel(this List<Project> projects)
        {
            var list = new List<ProjectViewModel>();
            projects.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

        #endregion

        #region Project Tags

        public static ProjectTagViewModel ToViewModel(this ProjectTag projectTag)
        {
            try
            {
                if (projectTag == null) return null;

                return new ProjectTagViewModel
                {
                    Id = projectTag.Id,
                    Name = projectTag?.Tag?.Name ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ProjectTagViewModel> ToViewModel(this List<ProjectTag> projectTags)
        {
            var list = new List<ProjectTagViewModel>();
            projectTags.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

        #endregion

        #region Tags

        public static TagViewModel ToViewModel(this Tag tag)
        {
            try
            {
                if (tag == null) return null;

                return new TagViewModel
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description = tag.Description
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TagViewModel> ToViewModel(this List<Tag> tags)
        {
            var list = new List<TagViewModel>();
            tags.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

        #endregion
    }
}
