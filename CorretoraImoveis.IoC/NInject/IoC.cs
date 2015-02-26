using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace CorretoraImoveis.Util.NInject
{
    public class IoC
    {
        private static StandardKernel _kernel;

        public static void Init()
        {
            _kernel = new StandardKernel(new IoCModule());
            ServiceLocator.SetLocatorProvider(()=> new NinjectServiceLocator(_kernel));
        }

        public static object Get(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public static IEnumerable<object> GetAll(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

    }
}
