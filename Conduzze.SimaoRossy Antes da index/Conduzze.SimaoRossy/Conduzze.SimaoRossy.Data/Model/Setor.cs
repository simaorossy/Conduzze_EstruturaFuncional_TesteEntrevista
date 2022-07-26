using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Model
{
    public class Setor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public Divisao Divisao { get; set; }
        public int DivisaoId { get; set; }
    }
}
