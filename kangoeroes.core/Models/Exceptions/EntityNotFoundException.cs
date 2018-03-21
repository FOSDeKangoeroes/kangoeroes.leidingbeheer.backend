using System;

namespace kangoeroes.core.Models.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
            
        }
    }
}