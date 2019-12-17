using System;

namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    /// A period is a range between two dates. This is used as a filter for everything tab related as most of the times, the amount of consumptions drank, .. is given for a period
    /// As it is only used as a filter, it should not be used in other entities like Order or Orderline.
    /// These items should only have the date they were created and be compared with the start and end date of a period
    /// </summary>
    public class Period
    {
        /// <summary>
        /// Unique identifier of the period.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// User friendly name for the period. E.g.: September - October 2019
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Start of the Period. Only the date should be saved, not the hour/minutes
        /// </summary>
        public DateTime Start { get; set; }
        
        /// <summary>
        /// End of the period. Only the date should be saved, not the hour/minutes
        /// </summary>
        public DateTime End { get; set; }
        
    }
}