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
    public class DepartamentoRepository
    {
        private readonly Context _Context;

        public DepartamentoRepository(Context context)
        {
            _Context = context;
        }


        public IEnumerable<Departamento> Listar() =>
            _Context.Departamentos.ToList();

        public Departamento Pesquisar(int id)
        {
            var departamento = _Context.Departamentos.FirstOrDefault(x => x.Id == id);

            if (departamento == null)
                throw new InvalidOperationException($"Departamento id '{id}' não encontrado!");

            return departamento;
        }

        public void Salvar(Departamento obj)
        {
            _Context.Add(obj);
            _Context.SaveChanges();
        }

        public void Atualizar(Departamento obj)
        {
            var departament = _Context.Departamentos.FirstOrDefault(x => x.Id == obj.Id);
            if (departament != null)
            {
                departament.Descricao = obj.Descricao;
                departament.Divisoes = obj.Divisoes;
                departament.Funcionarios = obj.Funcionarios;
                _Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var departamento = Pesquisar(id);
                _Context.Remove(departamento);
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException($"O departamento não pode ser excluido, pois contem Vinculo!");
            }
        }

    }
}
