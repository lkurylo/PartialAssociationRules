/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using Ninject;

namespace PartialAssociationRules
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            if (ServiceLocator == null)
            {
                var kernel = new StandardKernel(new ApplicationAndNinjectConfig());
                Bootstrapper.ServiceLocator = kernel.Get<IServiceLocator>();
            }
        }

        public static IServiceLocator ServiceLocator { get; set; }
    }
}
