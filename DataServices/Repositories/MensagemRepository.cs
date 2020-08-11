using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class MensagemRepository : RepositoryBase<MENSAGEM>, IMensagemRepository
    {
        public MENSAGEM CheckExist(MENSAGEM mensagem, Int32? idAss)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM;
            query = query.Where(p => p.MENS_NM_NOME == mensagem.MENS_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public MENSAGEM GetItemById(Int32 id)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM;
            query = query.Where(p => p.MENS_CD_ID == id);
            query = query.Include(p => p.MENSAGEM_CONTATO);
            query = query.Include(p => p.MENSAGEM_CAMPANHA);
            query = query.Include(p => p.MENSAGEM_GRUPO);
            return query.FirstOrDefault();
        }

        public List<MENSAGEM> GetAllItens(Int32? idAss)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM.Where(p => p.MENS_IN_ATIVO == 1);
            query = query.Include(p => p.MENSAGEM_CONTATO);
            query = query.Include(p => p.MENSAGEM_CAMPANHA);
            query = query.Include(p => p.MENSAGEM_GRUPO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<MENSAGEM> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM;
            query = query.Include(p => p.MENSAGEM_CONTATO);
            query = query.Include(p => p.MENSAGEM_CAMPANHA);
            query = query.Include(p => p.MENSAGEM_GRUPO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<MENSAGEM> GetAllAgendadas(Int32? idAss)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM.Where(p => p.MENS_IN_ATIVO == 1);
            query = query.Where(p => p.MENS_DT_AGENDA != null);
            query = query.Include(p => p.MENSAGEM_CONTATO);
            query = query.Include(p => p.MENSAGEM_CAMPANHA);
            query = query.Include(p => p.MENSAGEM_GRUPO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<MENSAGEM> GetAllEnviadas(Int32? idAss)
        {
            IQueryable<MENSAGEM> query = Db.MENSAGEM.Where(p => p.MENS_IN_ATIVO == 1);
            query = query.Where(p => p.MENS_IN_ENVIADA == 1);
            query = query.Include(p => p.MENSAGEM_CONTATO);
            query = query.Include(p => p.MENSAGEM_CAMPANHA);
            query = query.Include(p => p.MENSAGEM_GRUPO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<MENSAGEM> ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss)
        {
            List<MENSAGEM> lista = new List<MENSAGEM>();
            IQueryable<MENSAGEM> query = Db.MENSAGEM;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.MENS_NM_NOME.Contains(nome));
            }
            if (data != null)
            {
                query = query.Where(p => DbFunctions.TruncateTime(p.MENS_DT_ENVIO) == DbFunctions.TruncateTime(data));
            }
            if (enviada != null & enviada == 1)
            {
                query = query.Where(p => p.MENS_IN_ENVIADA == 1);
            }
            if (agendada != null & agendada == 1)
            {
                query = query.Where(p => p.MENS_DT_AGENDA != null);
            }
            if (!String.IsNullOrEmpty(conteudo))
            {
                query = query.Where(p => p.MENS_TX_TEXTO.Contains(conteudo));
            }
            if (query != null)
            {
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.Include(p => p.MENSAGEM_CONTATO);
                query = query.Include(p => p.MENSAGEM_CAMPANHA);
                query = query.Include(p => p.MENSAGEM_GRUPO);
                query = query.OrderBy(a => a.MENS_DT_DATA);
                lista = query.ToList<MENSAGEM>();
            }
            return lista;
        }
    }
}
