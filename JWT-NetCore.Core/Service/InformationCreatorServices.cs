using JWT_NetCore.Core.Entities;
using JWT_NetCore.Core.Interface;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NetCore.Core.Service
{
    public class InformationCreatorServices : IInformationCreator
    {
        //Lista de ejemplo para mostrar en el ControlController
        List<InformationCreator> informationCreators = new List<InformationCreator>();
        public InformationCreatorServices(){}

        public List<InformationCreator> GetInformationCreator()
        {            
            informationCreators.Add(new InformationCreator()
            {
                Name = "Leonardo",
                FullLastName = "Francia Rios",
                Mail1 = "leonardo.franciar@gmail.com",
                Mail2 = "leonardo.franciarios@outlook.com",
                NumberPhone = "+51 941765735"
            });
            return informationCreators;
        }
    }
}

