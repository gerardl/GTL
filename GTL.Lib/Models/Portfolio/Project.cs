using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GTL.Lib.Models.Portfolio
{
    [Table("Project", Schema = "Portfolio")]
    public class Project
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
        [MaxLength(2000)]
        public string RepositoryUrl { get; set; }
        [MaxLength(2000)]
        public string DemoUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public List<ProjectTag> ProjectTags { get; set; }
    }
}
