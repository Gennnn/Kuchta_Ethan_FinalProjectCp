using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kuchta_Ethan_FinalProjectCP.Models;
using Kuchta_Ethan_FinalProjectCp.Models;

namespace Kuchta_Ethan_FinalProjectCp.Data
{
    public class Kuchta_Ethan_FinalProjectCpContext : DbContext
    {
        public Kuchta_Ethan_FinalProjectCpContext (DbContextOptions<Kuchta_Ethan_FinalProjectCpContext> options)
            : base(options)
        {
        }

        public DbSet<Kuchta_Ethan_FinalProjectCP.Models.MemberItem> MemberItem { get; set; } = default!;

        public DbSet<Kuchta_Ethan_FinalProjectCp.Models.FoodItem>? FoodItem { get; set; }

        public DbSet<Kuchta_Ethan_FinalProjectCp.Models.ScheduleItem>? ScheduleItem { get; set; }

        public DbSet<Kuchta_Ethan_FinalProjectCp.Models.WorkoutItem>? WorkoutItem { get; set; }
    }
}
