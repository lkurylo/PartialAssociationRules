/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;

namespace PartialAssociationRules.Domain.Gui.Upload
{
    /// <summary>
    /// Helper class containg useful methods to work with files.
    /// </summary>
    public class FileHelpers
    {
        /// <summary>
        /// Gets file name extension.
        /// </summary>
        /// <param name="fileName">The name of the file with full path.</param>
        /// <returns>the extension of the file.</returns>
        public static SupportedFileExtensions CheckFileExtension(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName).TrimStart('.').ToUpper();
            var result = (SupportedFileExtensions)Enum.Parse(typeof(SupportedFileExtensions), extension);

            return result;
        }
    }
}
