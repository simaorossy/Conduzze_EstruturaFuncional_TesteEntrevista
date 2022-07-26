using Conduzze.SimaoRossy.Data.Model;
using Conduzze.SimaoRossy.Data.Repository;
using Conduzze.SimaoRossy.MVC.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Conduzze.SimaoRossy.MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        public DepartamentoRepository _departamentoRepository;

        public DepartamentoController(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public IActionResult Index()
        {
            return View(_departamentoRepository.Listar());
        }

        [HttpPost("/Departamento/Salvar")]
        public ResponseJsonDto Salvar(string Descricao)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            var departamento = new Departamento();
            departamento.Descricao = Descricao;
            _departamentoRepository.Salvar(departamento);

            return response;
        }

        [HttpPost("/Departamento/Delete")]
        public ResponseJsonDto Delete(int id)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            _departamentoRepository.Excluir(id);

            return response;
        }


    }
}
