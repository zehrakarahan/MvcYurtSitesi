using FluentValidation;
using Ninject;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtYesilKaya.Bll.DepencyResolvers.Ninject
{
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        private IKernel _kernel;

        public NinjectValidatorFactory()
        {
            _kernel = new StandardKernel(new ValidationModule());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var bindings = (List<IBinding>)_kernel.GetBindings(validatorType);

            if (bindings.Count > 0)
                return (IValidator)_kernel.Get(validatorType);

            return null;
        }
    }
}
