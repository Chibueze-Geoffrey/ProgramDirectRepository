using Microsoft.EntityFrameworkCore;
using ProgramDirect.Domain.Entities;

namespace ProgramDirect.Infrastruture.Data
{
    public class ProgramDirectDbContext : DbContext
    {
        public DbSet<OrganisationProgram> OrganisationPrograms { get; set; }
        public DbSet<ProgramApplication> ProgramApplications { get; set; }
        public DbSet<ApplicationQuestion> ApplicationQuestions { get; set; }
        public DbSet<ApplicationQuestionAnswer> ApplicationQuestionAnswers { get; set; }

        public ProgramDirectDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
