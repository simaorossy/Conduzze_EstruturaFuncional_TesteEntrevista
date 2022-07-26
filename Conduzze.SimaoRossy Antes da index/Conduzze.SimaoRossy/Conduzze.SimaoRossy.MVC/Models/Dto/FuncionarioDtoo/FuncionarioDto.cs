using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Models.Dto.FuncionarioDto
{
    public class FuncionarioDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? DepartamentoId { get; set; }
        public int? DivisaoId { get; set; }
        public int? SetorId { get; set; }
        public Alocacao Alocacao { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }
        public IEnumerable<Divisao> Divisoes { get; set; }
        public IEnumerable<Setor> setores { get; set; }
    }
}
