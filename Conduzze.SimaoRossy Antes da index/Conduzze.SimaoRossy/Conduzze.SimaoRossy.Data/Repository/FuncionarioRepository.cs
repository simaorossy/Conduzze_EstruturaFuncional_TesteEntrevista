using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conduzze.SimaoRossy.Data.Contextt;
using Conduzze.SimaoRossy.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Conduzze.SimaoRossy.Data.Repository
{
    public class FuncionarioRepository
    {
        private readonly Context _Context;

        public FuncionarioRepository(Context context)
        {
            _Context = context;
        }

        public IEnumerable<Funcionario> Listar()
        {
            var funcionario = _Context.Funcionarios.Include(x=>x.Departamento).Include(x => x.Divisao).Include(x => x.Setor).ToList();

            return funcionario;

        }
            

        public Funcionario Pesquisar(int id)
        {
            var funcionario = _Context.Funcionarios.Where(x => x.Id == id).Include(x => x.Departamento).Include(x => x.Divisao).Include(x => x.Setor).FirstOrDefault();

            if (funcionario == null)
                throw new InvalidOperationException($"Funcionário id '{id}' não encontrado!");

            return funcionario;
        }

        public void Salvar(Funcionario obj)
        {
            _Context.Add(obj);
            _Context.SaveChanges();
        }

        public void Atualizar(Funcionario obj)
        {
            var funcionario = _Context.Funcionarios.FirstOrDefault(x => x.Id == obj.Id);
            if (funcionario != null)
            {
                funcionario.Nome = obj.Nome;
                funcionario.Setor = obj.Setor;
                funcionario.SetorId = obj.SetorId;
                funcionario.DivisaoId = obj.DivisaoId;
                funcionario.Divisao = obj.Divisao;
                funcionario.Departamento = obj.Departamento;
                funcionario.DepartamentoId = obj.DepartamentoId;
                _Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var funcionario = Pesquisar(id);
                _Context.Remove(funcionario);
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException($"O funcionário não pode ser excluido, pois contem Vinculo!");
            }
        }
    }
}
