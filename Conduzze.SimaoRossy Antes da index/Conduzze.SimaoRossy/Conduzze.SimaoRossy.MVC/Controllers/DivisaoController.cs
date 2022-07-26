using Microsoft.AspNetCore.Mvc;
using Conduzze.SimaoRossy.Data.Repository;
using Conduzze.SimaoRossy.MVC.Models.Dto.DivisaoDtoo;
using Conduzze.SimaoRossy.MVC.Models.Dto;
using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Controllers
{
    public class DivisaoController : Controller
    {
        public readonly DivisaoRepository _divisaoRepository;
        public readonly DepartamentoRepository _departamentoRepository;

        public DivisaoController(DivisaoRepository divisaoRepository, DepartamentoRepository departamentoRepository)
        {
            _divisaoRepository = divisaoRepository;
            _departamentoRepository = departamentoRepository;
        }

        public IActionResult Index()
        {
            var divisaoDto = new DivisaoDto();

            divisaoDto.Divisoes = _divisaoRepository.Listar();
            divisaoDto.Departamentos = _departamentoRepository.Listar();

            return View(divisaoDto);
        }

        [HttpPost("/Divisao/Salvar")]
        public ResponseJsonDto Salvar(string Descricao, int DepartamentoId)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            var divisao = new Divisao();

            var departamento = _departamentoRepository.Pesquisar(DepartamentoId);

            divisao.Descricao = Descricao;
            divisao.Departamento = departamento;            
            divisao.DepartamentoId = DepartamentoId;

            _divisaoRepository.Salvar(divisao);            

            return response;
        }

        [HttpPost("/Divisao/Delete")]
        public ResponseJsonDto Delete(int id)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            _divisaoRepository.Excluir(id);

            return response;
        }
    }
}
