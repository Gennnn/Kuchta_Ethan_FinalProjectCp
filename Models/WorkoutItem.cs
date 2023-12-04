using System.ComponentModel.DataAnnotations;

namespace Kuchta_Ethan_FinalProjectCp.Models
{
    public class WorkoutItem
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public String TargetMuscle { get; set; }

    }
}
