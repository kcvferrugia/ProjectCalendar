using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeHelper.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
       
        public DateTime? Start{ get; set; }

        public DateTime? End { get; set; }

        public bool? EventRepeat { get; set; }

        public bool? IsAllDay { get; set; }

        public  string ThemeColor { get; set; }

       
    }
}