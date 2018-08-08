using System;

namespace kangoeroes.core.Models.Exceptions
{
    /// <summary>
    /// Representeert de fout wanneer een gevraagde entiteit niet gevonden werd.
    /// </summary>
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
            
        }
    }
}