namespace kangoeroes.leidingBeheer.ViewModels.ViewModels.Tak
{
  public class UpdateTakViewModel : AddTakViewModel
  {
    public UpdateTakViewModel(string naam, int volgorde) : base(naam, volgorde)
    {
    }

    public int Id { get; set; }
  }
}
