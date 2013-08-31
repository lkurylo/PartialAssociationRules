/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Extensions
{
    public static class DecimalExtenions
    {
        /// <summary>
        /// Round specific number to two decimal places.
        /// </summary>
        /// <param name="number">Number to round.</param>
        /// <returns>Rounded number.</returns>
        public static decimal Round(this decimal number)
        {
            return decimal.Round(number, 2, System.MidpointRounding.AwayFromZero);
        }
    }
}
