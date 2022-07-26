using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        public Setor Setor { get; set; }
        public Divisao Divisao { get; set; }
        public int? DepartamentoId { get; set; }
        public int? DivisaoId { get; set; }
        public int? SetorId { get; set; }





    }
}
