/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.IO;
using PartialAssociationRules.Domain.DataFileParsers;
using PartialAssociationRules.Domain.Exceptions;

namespace PartialAssociationRules.Domain.Gui.Upload
{
    /// <summary>
    /// Class designed to facilitate work with the uploaded file.
    /// </summary>
    public class FileManager
    {
        private StreamReader reader;
        private string fileName;

        /// <summary>
        /// Default constructor.
        /// Throws PartialAssociationRulesException(ExceptionsList.UnsuportedFileSelected).
        /// </summary>
        /// <param name="file">Stream containing file.</param>
        /// <param name="fileName">File name with path.</param>
        public FileManager(Stream file, string fileName)
        {
            this.fileName = fileName;
            try
            {
                Extension = FileHelpers.CheckFileExtension(fileName);
            }
            catch (System.Exception) //occurs only when file is provided by drag&drop functionality
            {
                throw new PartialAssociationRulesException(ExceptionsList.UnsuportedFileSelected);
            }

            reader = new StreamReader(file);
        }

        /// <summary>
        /// Gets extension for current file.
        /// </summary>
        public SupportedFileExtensions Extension
        {
            private set;
            get;
        }

        /// <summary>
        /// Gets type of the current file.
        /// </summary>
        public FileType Type
        {
            get
            {
                switch (Extension)
                {
                    case SupportedFileExtensions.ARFF:
                        return FileType.ARFF;
                    case SupportedFileExtensions.CSV:
                    case SupportedFileExtensions.TXT:
                        return FileType.CSV;
                    case SupportedFileExtensions.ZIP:
                        return FileType.DataAndNames;
                    default:
                        return FileType.Undefined;
                }
            }
        }

        /// <summary>
        /// Gets the current file content.
        /// </summary>
        public StreamReader FileStream
        {
            get
            {
                return reader;
            }
        }

        /// <summary>
        /// Gets the current file name with extension.
        /// </summary>
        public string FileName
        {
            get
            {
                return Path.GetFileName(fileName);
            }
        }
    }
}
