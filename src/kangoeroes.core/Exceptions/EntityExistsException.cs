using System;
using System.Net;

namespace kangoeroes.core.Exceptions
{
    /// <summary>
    ///     Representeert de fout wanneer een entiteit reeds bestaat.
    /// </summary>
    public class EntityExistsException : HttpStatusCodeException
    {
        public EntityExistsException(string message) : base(HttpStatusCode.BadRequest,message)
        {
        }
    }
}