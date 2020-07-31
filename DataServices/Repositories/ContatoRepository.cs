using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class ContatoRepository : RepositoryBase<CONTATO>, IContatoRepository
    {
        public CONTATO CheckExist(CONTATO contato, Int32? idAss)
        {
            IQueryable<CONTATO> query = Db.CONTATO;
            query = query.Where(p => p.CONT_NM_NOME == contato.CONT_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public CONTATO GetItemById(Int32 id)
        {
            IQueryable<CONTATO> query = Db.CONTATO;
            query = query.Where(p => p.CONT_CD_ID == id);
            query = query.Include(p => p.CAMPANHA_CONTATO);
            return query.FirstOrDefault();
        }

        public List<CONTATO> GetAllItens(Int32? idAss)
        {
            IQueryable<CONTATO> query = Db.CONTATO.Where(p => p.CONT_IN_ATIVO == 1);
            query = query.Include(p => p.CAMPANHA_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CONTATO> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<CONTATO> query = Db.CONTATO;
            query = query.Include(p => p.CAMPANHA_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CONTATO> ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss)
        {
            List<CONTATO> lista = new List<CONTATO>();
            IQueryable<CONTATO> query = Db.CONTATO;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.CONT_NM_NOME.Contains(nome));
            }
            if (origem != null & origem > 0)
            {
                query = query.Where(p => p.ORIG_CD_ID == origem);
            }
            if (categoria != null & origem > 0)
            {
                query = query.Where(p => p.CACO_CD_ID == categoria);
            }
            if (!String.IsNullOrEmpty(cargo))
            {
                query = query.Where(p => p.CONT_NM_CARGO.Contains(cargo));
            }
            if (profissao != null & profissao > 0)
            {
                query = query.Where(p => p.PROF_CD_ID == profissao);
            }
            if (!String.IsNullOrEmpty(cidade))
            {
                query = query.Where(p => p.CACO_NM_CIDADE.Contains(cidade));
            }
            if (uf != null & uf > 0)
            {
                query = query.Where(p => p.UF_CD_ID == uf);
            }
            if (clube != null & clube > 0)
            {
                query = query.Where(p => p.CLUB_CD_ID == clube);
            }
            if (data != null)
            {
                query = query.Where(p => DbFunctions.TruncateTime(p.CONT_DT_NASCIMENTO) == DbFunctions.TruncateTime(data));
            }
            if (query != null)
            {
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.CONT_NM_NOME);
                lista = query.ToList<CONTATO>();
            }
            return lista;
        }
    }
}
