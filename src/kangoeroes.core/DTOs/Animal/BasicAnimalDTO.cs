using System;

namespace kangoeroes.core.DTOs.Animal
{
  public class BasicAnimalDTO
  {
    public int Id { get; set; }

    public string Naam { get; set; }

    public DateTime CreatedOn { get; set; }
    public int EntryCount { get; set; }
    
    public DateTime? ReuseDate { get; set; }
  }
}
