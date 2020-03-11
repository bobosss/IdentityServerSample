using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Allweb.Core.Common.Exceptions;
using Auditor.Business.Models;

namespace Auditor.Bussness.Models
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <returns></returns>
        public static ICollection<AuditorException> AddError(this ObjectWithError @object, string exceptionMessage)
        {
            if (@object.Errors == null)
                @object.Errors = new Collection<AuditorException>();

            @object.Errors.Add(ParseException(exceptionMessage));

            return @object.Errors;
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static ICollection<AuditorException> AddError(this ObjectWithError @object, Exception exception)
        {
            if (@object.Errors == null)
                @object.Errors = new Collection<AuditorException>();

            @object.Errors.Add(new AuditorException(string.Empty, exception.Message));
            return @object.Errors;
        }

        /// <summary>
        /// Parses the exception.
        /// </summary>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <returns></returns>
        public static AuditorException ParseException(string exceptionMessage)
        {
            DictionaryEntry entry = ExceptionMessages.ResourceManager
                .GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true)
                .OfType<DictionaryEntry>()
                .FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString() == exceptionMessage);

            return string.IsNullOrWhiteSpace(entry.Key?.ToString())
                ? new AuditorException(string.Empty, exceptionMessage)
                : new AuditorException(entry.Key.ToString(), exceptionMessage);
        }
    }
}
