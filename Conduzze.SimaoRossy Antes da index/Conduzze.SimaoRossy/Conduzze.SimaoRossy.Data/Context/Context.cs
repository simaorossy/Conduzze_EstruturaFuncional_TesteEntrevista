using Conduzze.SimaoRossy.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Contextt
{
    public class Context : DbContext
    {       
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; } = default!;
        public DbSet<Divisao> Divisoes { get; set; } = default!;
        public DbSet<Setor> Setores { get; set; } = default!;
        public DbSet<Funcionario> Funcionarios { get; set; } = default!;
        //public DbSet<Associacao> Associacoes { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }        
    }
}
