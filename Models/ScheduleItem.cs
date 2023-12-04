using System.ComponentModel.DataAnnotations;

namespace Kuchta_Ethan_FinalProjectCp.Models
{
    public class ScheduleItem
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public SessionDays SessionDays { get; set; }
        public int SessionHours { get; set; }
        public int SessionMins { get; set; }
        public String Proffesor { get; set; }

    }

    public enum SessionDays
    {
        MWF, TTh
    }
}
