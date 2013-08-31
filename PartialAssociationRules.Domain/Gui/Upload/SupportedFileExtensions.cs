/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Gui.Upload
{
    /// <summary>
    /// Contains the supported files list.
    /// </summary>
    public enum SupportedFileExtensions
    {
        /// <summary>
        /// File contains a comma separated values.
        /// </summary>
        CSV,

        /// <summary>
        /// File contains the plain text.
        /// </summary>
        TXT,

        /// <summary>
        /// The Weka default files - Attribute-Relation File Format.
        /// </summary>
        ARFF,

        /// <summary>
        /// Contains the packed *.names and *.data files from UCI Learning Repository.
        /// </summary>
        ZIP
    }
}
