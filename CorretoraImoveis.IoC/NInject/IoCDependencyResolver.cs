using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CorretoraImoveis.Util.NInject
{
    public class IoCDependencyResolver: IDependencyResolver
    {

        public object GetService(Type serviceType)
        {
            return IoC.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return IoC.GetAll(serviceType);
        }
    }
}
