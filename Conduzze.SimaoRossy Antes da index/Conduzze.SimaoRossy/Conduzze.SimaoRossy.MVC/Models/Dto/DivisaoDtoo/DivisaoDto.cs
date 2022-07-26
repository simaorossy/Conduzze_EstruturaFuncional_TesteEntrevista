using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Models.Dto.DivisaoDtoo
{
    public class DivisaoDto
    {

        public IEnumerable<Divisao> Divisoes { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }

    }
}
