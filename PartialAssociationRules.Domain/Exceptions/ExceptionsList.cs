﻿/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

namespace PartialAssociationRules.Domain.Exceptions
{
    /// <summary>
    /// Application specific exceptions list.
    /// </summary>
    public enum ExceptionsList
    {
        ArgumentCountIncorrect,
        IncorrectNumberOfFilesInArchive,
        IncorrectArchive,
        UnsuportedFileSelected,
        RowsNotParsedCorrectly
    }
}