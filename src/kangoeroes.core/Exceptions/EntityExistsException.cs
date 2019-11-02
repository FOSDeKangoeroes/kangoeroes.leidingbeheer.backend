using System;

namespace kangoeroes.core.Exceptions
{
    /// <summary>
    ///     Representeert de fout wanneer een entiteit reeds bestaat.
    /// </summary>
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string message) : base(message)
        {
        }
    }
}