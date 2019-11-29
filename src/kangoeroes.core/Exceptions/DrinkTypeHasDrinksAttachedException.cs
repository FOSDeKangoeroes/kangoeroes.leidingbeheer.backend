using System.Net;

namespace kangoeroes.core.Exceptions
{
    public class DrinkTypeHasDrinksAttachedException: HttpStatusCodeException
    {
        
        public DrinkTypeHasDrinksAttachedException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}