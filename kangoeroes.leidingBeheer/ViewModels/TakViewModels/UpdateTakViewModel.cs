namespace kangoeroes.leidingBeheer.ViewModels.TakViewModels
{
  public class UpdateTakViewModel : AddTakViewModel
  {
    public UpdateTakViewModel(string naam, int volgorde) : base(naam, volgorde)
    {
    }

    public int Id { get; set; }
  }
}
