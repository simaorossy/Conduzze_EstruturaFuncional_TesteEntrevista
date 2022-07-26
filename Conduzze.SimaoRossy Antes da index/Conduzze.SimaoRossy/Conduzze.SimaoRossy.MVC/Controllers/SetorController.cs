using Microsoft.AspNetCore.Mvc;
using Conduzze.SimaoRossy.Data.Repository;
using Conduzze.SimaoRossy.MVC.Models.Dto.SetorDtoo;
using Conduzze.SimaoRossy.MVC.Models.Dto;
using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Controllers
{
    public class SetorController : Controller
    {
        public readonly SetorRepository _SetorRepository;
        public readonly DepartamentoRepository _departamentoRepository;
        public readonly DivisaoRepository _divisaoRepository;

        public SetorController(SetorRepository setorRepository,
            DepartamentoRepository departamentoRepository,
            DivisaoRepository divisaoRepository)
        {
            _SetorRepository = setorRepository;
            _divisaoRepository = divisaoRepository;
            _departamentoRepository = departamentoRepository;
        }

        public IActionResult Index()
        {
            var setorDto = new SetorDto();

            setorDto.Divisoes = _divisaoRepository.Listar();
            setorDto.Setores = _SetorRepository.Listar();

            return View(setorDto);
        }

        [HttpPost("/Setor/Salvar")]
        public ResponseJsonDto Salvar(string Descricao, int DivisaoId)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            var setor = new Setor();
            //setor.Divisao = new Divisao();

            var divisao = _divisaoRepository.Pesquisar(DivisaoId);
            var departamento = _departamentoRepository.Pesquisar(divisao.DepartamentoId);

            setor.Descricao = Descricao;
            setor.DivisaoId = DivisaoId;
            setor.Divisao = divisao;
            //setor.Divisao.DepartamentoId = divisao.DepartamentoId;
            //setor.Divisao.Departamento = departamento;
            

            _SetorRepository.Salvar(setor);

            return response;
        }

        [HttpPost("/Setor/Delete")]
        public ResponseJsonDto Delete(int id)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            _SetorRepository.Excluir(id);

            return response;
        }
    }
}
