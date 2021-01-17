using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GTL.Lib.Models.Portfolio
{
    [Table("Tag", Schema = "Portfolio")]
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public List<ProjectTag> ProjectTags { get; set; }
    }
}
