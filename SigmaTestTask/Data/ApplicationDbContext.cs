using Microsoft.EntityFrameworkCore;
using SigmaTestTask.Models.Entities;

namespace SigmaTestTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
