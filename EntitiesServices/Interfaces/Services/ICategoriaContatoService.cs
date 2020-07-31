using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ICategoriaContatoService : IServiceBase<CATEGORIA_CONTATO>
    {
        Int32 Create(CATEGORIA_CONTATO item, LOG log);
        Int32 Create(CATEGORIA_CONTATO item);
        Int32 Edit(CATEGORIA_CONTATO item, LOG log);
        Int32 Edit(CATEGORIA_CONTATO item);
        Int32 Delete(CATEGORIA_CONTATO item, LOG log);
        CATEGORIA_CONTATO CheckExist(CATEGORIA_CONTATO item);
        CATEGORIA_CONTATO GetItemById(Int32 id);
        List<CATEGORIA_CONTATO> GetAllItens();
        List<CATEGORIA_CONTATO> GetAllItensAdm();
    }
}
