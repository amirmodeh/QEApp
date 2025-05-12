using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QEApp.Domain.Entities.Courses
{
    // محتوا (فیلم، پادکست، PDF و غیره)
    public class Content
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(20)]
        public string ContentType { get; set; } // "Video", "Audio", "PDF", etc.

        [Required]
        [MaxLength(500)]
        public string FileUrl { get; set; }

        public bool IsDownloadable { get; set; }

        public int SectionId { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }

        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}
