using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ICategoriaContatoRepository : IRepositoryBase<CATEGORIA_CONTATO>
    {
        CATEGORIA_CONTATO CheckExist(CATEGORIA_CONTATO cat);
        List<CATEGORIA_CONTATO> GetAllItens();
        CATEGORIA_CONTATO GetItemById(Int32 id);
        List<CATEGORIA_CONTATO> GetAllItensAdm();
    }
}
