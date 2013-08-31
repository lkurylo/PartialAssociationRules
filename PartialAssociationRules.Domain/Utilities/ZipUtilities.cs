/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.IO;
using System.Linq;
using Ionic.Zip;
using PartialAssociationRules.Domain.Exceptions;

namespace PartialAssociationRules.Domain.Utilities
{
    public static class ZipUtilities
    {
        public static bool IsCorrectZipArchive(Stream archive)
        {
            bool result = false;
            if (ZipFile.IsZipFile(archive, false))
            {
                archive.Seek(0, SeekOrigin.Begin);
                var filesInArchive = ZipFile.Read(archive).EntryFileNames;

                if (filesInArchive.Count != 2)
                {
                    throw new PartialAssociationRulesException(ExceptionsList.IncorrectNumberOfFilesInArchive);
                }

                string[] extensions = new string[2]{
                        Path.GetExtension(filesInArchive.ToArray()[0]).TrimStart('.'),
                        Path.GetExtension(filesInArchive.ToArray()[1]).TrimStart('.')
                };

                if (extensions.Contains("data") && extensions.Contains("names"))
                {
                    result = true;
                }
            }

            return result;
        }

        public static StreamReader ExtractFileWithData(Stream archive)
        {
            Stream result = new MemoryStream();
            archive.Seek(0, SeekOrigin.Begin);
            ZipEntry entry = ZipFile.Read(archive).SelectEntries("*.data").First();

            entry.Extract(result);
            return new StreamReader(result);
        }

        public static StreamReader ExtractFileWithColumnNames(Stream archive)
        {
            Stream result = new MemoryStream();
            archive.Seek(0, SeekOrigin.Begin);
            ZipEntry entry = ZipFile.Read(archive).SelectEntries("*.names").First();

            entry.Extract(result);
            return new StreamReader(result);
        }
    }
}
