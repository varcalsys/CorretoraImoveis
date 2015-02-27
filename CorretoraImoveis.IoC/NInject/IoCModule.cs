using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.App;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Data.Repositories;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Contracts.Services;
using CorretoraImoveis.Domain.Services;
using Ninject.Modules;

namespace CorretoraImoveis.Util.NInject
{
    public class IoCModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IImovelApp>().To<ImovelApp>();

            Bind<IImovelService>().To<ImovelService>();

            Bind<IImovelRepository>().To<ImovelRepository>();
        }
    }
}
