using System;
using System.Collections.Generic;
using System.Text;

namespace GTL.Lib.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string RepositoryUrl { get; set; }
        public string DemoUrl { get; set; }
        public List<ProjectTagViewModel> ProjectTags { get; set; }
    }
}
