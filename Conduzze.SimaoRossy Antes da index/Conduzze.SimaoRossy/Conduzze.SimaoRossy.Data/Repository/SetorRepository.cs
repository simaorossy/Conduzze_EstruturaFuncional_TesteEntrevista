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
    public class SetorRepository
    {
        private readonly Context _Context;

        public SetorRepository(Context context)
        {
            _Context = context;
        }


        public IEnumerable<Setor> Listar() =>
            _Context.Setores.ToList();

        public Setor Pesquisar(int id)
        {
            var setor = _Context.Setores.FirstOrDefault(x => x.Id == id);

            if (setor == null)
                throw new InvalidOperationException($"Setor id '{id}' não encontrado!");

            return setor;
        }

        public void Salvar(Setor obj)
        {
            _Context.Add(obj);
            _Context.SaveChanges();
        }

        public void Atualizar(Setor obj)
        {
            var setor = _Context.Setores.FirstOrDefault(x => x.Id == obj.Id);
            if (setor != null)
            {
                setor.Descricao = obj.Descricao;
                setor.Funcionarios = obj.Funcionarios;
                setor.Divisao = obj.Divisao;
                setor.DivisaoId = obj.DivisaoId;

                _Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var setor = Pesquisar(id);
                _Context.Remove(setor);
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException($"O setor não pode ser excluido, pois contem Vinculo!");
            }
        }
    }
}
