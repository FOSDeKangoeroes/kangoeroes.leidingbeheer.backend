namespace kangoeroes.core.Models.Responses
{
    /// <summary>
    /// Response voor het teruggeven van een server error (500).
    /// </summary>
    public class ApiServerErrorResponse: ApiResponse
    {
        /// <summary>
        /// Gedetailleerde beschrijving van de fout.
        /// </summary>
        public string DetailedMessage { get; set; }
        
        /// <summary>
        /// StackTrace van de fout.
        /// </summary>
        public string StackTrace { get; set; }
        
        /// <summary>
        /// Maakt een nieuwe instantie aan van de respsonse met een basisbericht.
        /// </summary>
        /// <param name="message">Basisbericht voor de fout</param>
        public ApiServerErrorResponse(string message) : base(message)
        {
           
        }
    }
}