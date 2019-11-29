using System;
using System.Net;

namespace kangoeroes.core.Exceptions
{
    /// <summary>
    /// Exception om aan te geven dat een relatie niet geldig is.
    /// </summary>
    public class InvalidRelationException: HttpStatusCodeException
    {
        /// <summary>
        /// Maakt een nieuwe instantie aan van de exception met een meegegeven bericht. 
        /// </summary>
        /// <param name="message"></param>
        public InvalidRelationException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}