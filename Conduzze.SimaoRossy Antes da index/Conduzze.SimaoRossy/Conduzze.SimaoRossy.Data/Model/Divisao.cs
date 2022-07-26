using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Model
{
    public class Divisao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public IEnumerable<Setor> Setores { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
    }
}
