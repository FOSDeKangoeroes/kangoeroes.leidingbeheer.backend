using System.Collections.Generic;
using kangoeroes.webUI.ViewModels.AuthViewModels;

namespace kangoeroes.webUI.Helpers
{
  public class RoleComparer : IEqualityComparer<RoleViewModel>
  {
    public bool Equals(RoleViewModel x, RoleViewModel y)
    {
      if (ReferenceEquals(x, y)) return true;

      return x.Id == y.Id;
    }

    public int GetHashCode(RoleViewModel obj)
    {
      //Get hash code for the Name field if it is not null.
      var hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();

      //Get hash code for the Code field.
      var hashProductCode = obj.Id.GetHashCode();

      //Calculate the hash code for the product.
      return hashProductName ^ hashProductCode;
    }
  }
}
