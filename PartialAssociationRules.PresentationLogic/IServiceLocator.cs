/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace PartialAssociationRules
{
    /// <summary>
    /// Interface for service locator.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Returns specific service.
        /// </summary>
        /// <typeparam name="T">Service to resolve.</typeparam>
        /// <returns>Resolved service.</returns>
        T GetService<T>();

        /// <summary>
        /// Returns specific service with contains key metadata.
        /// </summary>
        /// <typeparam name="T">Service to resolve.</typeparam>
        /// <param name="key">The metadata key .</param>
        /// <returns>Resolved service.</returns>
        T GetService<T>(Enum key);

        /// <summary>
        /// Returns specific service which contains key metadata and have exactly one argument in default constructor.
        /// </summary>
        /// <typeparam name="T">Service to resolve.</typeparam>
        /// <param name="key">The metadata key .</param>
        /// <param name="propertyName">Constructor argument name.</param>
        /// <param name="value">Constructor argument value.</param>
        /// <returns>Resolved service.</returns>
        T GetService<T>(Enum key, string propertyName, object value);
    }
}
