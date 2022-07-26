using Microsoft.AspNetCore.Mvc;
using Conduzze.SimaoRossy.Data.Repository;
using Conduzze.SimaoRossy.MVC.Models.Dto.FuncionarioDto;
using Conduzze.SimaoRossy.MVC.Models.Dto;
using Conduzze.SimaoRossy.MVC.Models.Dto.FuncionarioDtoo;
using Conduzze.SimaoRossy.Data.Model;

namespace Conduzze.SimaoRossy.MVC.Controllers
{
    public class FuncionarioController : Controller
    {
        public readonly FuncionarioRepository _funcionarioRepository;
        public readonly DepartamentoRepository _departamentoRepository;
        public readonly DivisaoRepository _divisaoRepository;
        public readonly SetorRepository _setorRepository;

        public FuncionarioController(FuncionarioRepository funcionarioRepository, 
            DepartamentoRepository departamentoRepository,
            DivisaoRepository divisaoRepository,
            SetorRepository setorRepository)
        {
            this._funcionarioRepository = funcionarioRepository;
            this._departamentoRepository = departamentoRepository;
            this._divisaoRepository = divisaoRepository;
            this._setorRepository = setorRepository;
        }

        public IActionResult Index()
        {
            var funcionarioDto = new FuncionarioDto();
            funcionarioDto.Funcionarios = _funcionarioRepository.Listar();          
            funcionarioDto.Departamentos = _departamentoRepository.Listar();
            funcionarioDto.Divisoes = _divisaoRepository.Listar();
            funcionarioDto.setores = _setorRepository.Listar();

            return View(funcionarioDto);
        }

        [HttpPost("/Funcionario/Salvar")]
        public ResponseJsonDto Salvar(FuncionarioSaveDto request)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";            

            if(request.Id == 0)
            {
                var funcionario = new Funcionario();
                funcionario.Nome = request.Nome;
                if (request.SetorId != 0)
                    funcionario.Setor = _setorRepository.Pesquisar(request.SetorId);
                if (request.DivisaoId != 0)
                    funcionario.Divisao = _divisaoRepository.Pesquisar(request.DivisaoId);
                funcionario.Departamento = _departamentoRepository.Pesquisar(request.DepartamentoId);

                _funcionarioRepository.Salvar(funcionario);
            }
            else
            {
                var funcionario = new Funcionario();
                funcionario.Id = request.Id;
                funcionario.Nome = request.Nome;
                if (request.SetorId != 0)
                {
                    funcionario.Setor = _setorRepository.Pesquisar(request.SetorId);
                    funcionario.SetorId = request.SetorId;
                }
                    
                if (request.DivisaoId != 0)
                {
                    funcionario.Divisao = _divisaoRepository.Pesquisar(request.DivisaoId);
                    funcionario.DivisaoId = request.DivisaoId;
                }               

                funcionario.DepartamentoId = request.DepartamentoId;
                funcionario.Departamento = _departamentoRepository.Pesquisar(request.DepartamentoId);

                _funcionarioRepository.Atualizar(funcionario);
            }            

            return response;
        }

        [HttpPost("/Funcionario/Funcionario")]
        public FuncionarioDto Funcionario(int idFuncionario)
        {
            var funcionario = _funcionarioRepository.Pesquisar(idFuncionario);

            var response = new FuncionarioDto(){
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                DepartamentoId = funcionario.DepartamentoId,
                DivisaoId = funcionario.DivisaoId == null ? 0 : funcionario.DivisaoId,
                SetorId = funcionario.SetorId == null ? 0 : funcionario.SetorId
            };

            return response;
        }





        [HttpPost("/Funcionario/Delete")]
        public ResponseJsonDto Delete(int idFuncionario)
        {
            var response = new ResponseJsonDto();
            response.Status = true;
            response.Mensagem = "Ok";

            _funcionarioRepository.Excluir(idFuncionario);

            return response;
        }


    }
}
