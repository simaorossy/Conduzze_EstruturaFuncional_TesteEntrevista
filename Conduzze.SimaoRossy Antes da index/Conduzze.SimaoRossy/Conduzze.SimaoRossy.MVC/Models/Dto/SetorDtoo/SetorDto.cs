using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Models.Dto.SetorDtoo
{
    public class SetorDto
    {
        public IEnumerable<Departamento> Departamentos { get; set; }
        public IEnumerable<Divisao> Divisoes { get; set; }
        public IEnumerable<Setor> Setores { get; set; }

    }
}
