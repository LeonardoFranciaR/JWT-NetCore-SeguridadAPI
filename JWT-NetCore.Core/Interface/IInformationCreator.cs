using JWT_NetCore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT_NetCore.Core.Interface
{
    public interface IInformationCreator
    {
        //Interfaces del servicio InformationCreatorServices
        List<InformationCreator> GetInformationCreator();
    }
}
