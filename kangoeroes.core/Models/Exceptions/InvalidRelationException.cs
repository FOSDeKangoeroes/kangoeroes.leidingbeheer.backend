using System;

namespace kangoeroes.core.Models.Exceptions
{
    /// <summary>
    /// Exception om aan te geven dat een relatie niet geldig is.
    /// </summary>
    public class InvalidRelationException: Exception
    {
        /// <summary>
        /// Maakt een nieuwe instantie aan van de exception met een meegegeven bericht. 
        /// </summary>
        /// <param name="message"></param>
        public InvalidRelationException(string message) : base(message)
        {
        }
    }
}