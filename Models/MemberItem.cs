using System.ComponentModel.DataAnnotations;

namespace Kuchta_Ethan_FinalProjectCP.Models
{
    public class MemberItem
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String Program { get; set; }
        public Year Year { get; set; }

    }

    public enum Year
    {
        Freshman, Sophmore, Junior, Senior, Other
    }
}