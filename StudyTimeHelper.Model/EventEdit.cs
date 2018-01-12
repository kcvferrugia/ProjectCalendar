using System;
using System.ComponentModel.DataAnnotations;

namespace StudyCalendar.Model
{
    public class EventEdit
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        public string Title { get; set; }
        
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string Description { get; set; }

        public bool? IsAllDay { get; set; }

        public bool? EventRepeat { get; set; }

        public string ThemeColor { get; set; }

        
    }
}
