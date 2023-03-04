using CreateQuiz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreateQuiz.Context
{
    public class CreateQuizDBContext : IdentityDbContext<AppUser>
    {
        public CreateQuizDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
    }
}
