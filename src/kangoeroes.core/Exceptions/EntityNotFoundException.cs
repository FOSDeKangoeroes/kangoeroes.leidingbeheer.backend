using System;
using System.Net;

namespace kangoeroes.core.Exceptions
{
    /// <summary>
    ///     Representeert de fout wanneer een gevraagde entiteit niet gevonden werd.
    /// </summary>
    public class EntityNotFoundException : HttpStatusCodeException
    {
        public EntityNotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}