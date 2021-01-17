using GTL.Lib.Models.Portfolio;
using GTL.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTL.Lib.Extensions
{
    public static class ProjectExtensions
    {
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
                    RepositoryUrl = project.RepositoryUrl
                    //Tags = project?.Tags?.ToGameModel() ?? null
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
    }
}
