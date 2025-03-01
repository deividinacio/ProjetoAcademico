using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using System.Reflection;
namespace ProjetoAcademico.Infra.Data.Context
{
    public class ProjetoAcademicoContext : DbContext
    {
        public ProjetoAcademicoContext(DbContextOptions<ProjetoAcademicoContext> options):base(options)
        {
         
        }
        public DbSet<Curso> CursoSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            //modelBuilder.ApplyConfiguration(new CursoConfiguration()); mapeamento 1 a 1
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
