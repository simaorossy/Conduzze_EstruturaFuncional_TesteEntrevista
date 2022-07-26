using Conduzze.SimaoRossy.Data.Contextt;
using Conduzze.SimaoRossy.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduzze.SimaoRossy.Data.Repository
{
    public class DivisaoRepository
    {
        private readonly Context _Context;

        public DivisaoRepository(Context context)
        {
            _Context = context;
        }

        public IEnumerable<Divisao> Listar() =>
            _Context.Divisoes.ToList();

        public Divisao Pesquisar(int id)
        {
            var divisao = _Context.Divisoes.Include(x=>x.Departamento).FirstOrDefault(x => x.Id == id);

            if (divisao == null)
                throw new InvalidOperationException($"Divisao id '{id}' não encontrado!");

            return divisao;
        }

        public void Salvar(Divisao obj)
        {
            _Context.Add(obj);
            _Context.SaveChanges();
        }

        public void Atualizar(Divisao obj)
        {
            var div = _Context.Divisoes.FirstOrDefault(x => x.Id == obj.Id);
            if (div != null)
            {
                div.Descricao = obj.Descricao;
                div.Funcionarios = obj.Funcionarios;
                div.DepartamentoId = obj.DepartamentoId;
                div.Departamento = obj.Departamento;
                div.Setores = obj.Setores;
                
                _Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var divisao = Pesquisar(id);
                _Context.Remove(divisao);
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException($"A divisão não pode ser excluido, pois contem Vinculo!");
            }
        }
    }
}
