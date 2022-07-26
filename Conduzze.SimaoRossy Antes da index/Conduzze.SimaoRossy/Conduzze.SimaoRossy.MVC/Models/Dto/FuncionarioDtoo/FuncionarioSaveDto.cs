namespace Conduzze.SimaoRossy.MVC.Models.Dto.FuncionarioDtoo
{
    public class FuncionarioSaveDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DepartamentoId { get; set; }
        public int DivisaoId { get; set; }
        public int SetorId { get; set; }
    }
}
