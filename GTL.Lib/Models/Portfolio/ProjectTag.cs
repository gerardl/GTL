using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GTL.Lib.Models.Portfolio
{
    [Table("ProjectTag", Schema = "Portfolio")]
    public class ProjectTag
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
