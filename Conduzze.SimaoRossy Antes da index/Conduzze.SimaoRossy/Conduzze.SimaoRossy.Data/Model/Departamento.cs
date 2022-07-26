using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Model
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public IEnumerable<Divisao> Divisoes { get; set; }

    }
}
