/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Collections.Generic;
using System.ComponentModel;
using PartialAssociationRules.Domain.DataFileParsers;
using PartialAssociationRules.Domain.DataGenerators;
using PartialAssociationRules.Domain.Gui.Upload;

namespace PartialAssociationRules.Domain.Entities
{
    /// <summary>
    /// Represents data table.
    /// </summary>
    public class InformationSystem
    {
        /// <summary>
        /// Information system name.
        /// </summary>
        public string Name { get; set; }

        private IList<Row> rows;
        /// <summary>
        /// List of rows.
        /// </summary>
        public IList<Row> Rows
        {
            set
            {
                rows = value;
                NotifyPropertyChanged("Rows");
            }
            get
            {
                return rows;
            }
        }

        /// <summary>
        /// Sets or gets minimal support.
        /// </summary>
        public decimal Support { set; get; }

        /// <summary>
        /// Sets or gets minimal confidence.
        /// </summary>
        public decimal Confidence { set; get; }

        /// <summary>
        /// Sets or gets alpha parametr.
        /// </summary>
        public decimal Alpha { set; get; }

        /// <summary>
        /// Sets or gets gamma parametr.
        /// </summary>
        public decimal Gamma { set; get; }

        /// <summary>
        /// Contains list of all attributes. Determines which attributes are decisions attributes.
        /// </summary>
        public Dictionary<string, bool> DecisionAttributes
        {
            set;
            get;
        }

        /// <summary>
        /// Creates information system from selected file.
        /// </summary>
        /// <returns>Information system.</returns>
        public static InformationSystem CreateFromFile(IDataFileParser parser, FileManager fileManager)
        {
            InformationSystem result = new InformationSystem()
            {
                Rows = parser.Parse(fileManager.FileStream),
                Confidence = 0.0m,
                Support = 0.0m,
                Name = fileManager.FileName
            };

            return result;
        }

        /// <summary>
        /// Creates information system using specific generator type.
        /// </summary>
        /// <param name="type">Type of generator. </param>
        /// <param name="numberOfAttributes">Number of arguments to generate for each row.</param>
        /// <param name="numberOfObjects">Number of rows to generate.</param>
        /// <returns>Information system.</returns>
        public static InformationSystem CreateFromGenerator(IDataGenerator generator, int numberOfAttributes,
             int numberOfObjects)
        {
            IDataGenerator gen = generator;

            gen.NumberOfAttributes = numberOfAttributes;
            gen.NumberOfObjects = numberOfObjects;

            InformationSystem result = new InformationSystem()
            {
                Confidence = 0.0m,
                Support = 0.0m,
                Rows = generator.Generate()
            };

            return result;
        }

        public static event PropertyChangedEventHandler PropertyChanged;

        private static void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(property));
            }
        }
    }
}
