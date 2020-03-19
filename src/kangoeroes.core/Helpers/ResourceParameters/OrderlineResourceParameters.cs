using System;

namespace kangoeroes.core.Helpers.ResourceParameters
{
    public class OrderlineResourceParameters: ResourceParameters
    {
        /// <summary>
        /// Datum vanaf wanneer de orderlines moeten opgehaald worden
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Datum tot wanneer de orderlines moeten opgehaald worden.
        /// </summary>
        public DateTime End { get; set; }
    }
}