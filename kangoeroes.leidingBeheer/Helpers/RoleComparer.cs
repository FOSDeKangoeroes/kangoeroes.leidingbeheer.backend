using System.Collections.Generic;
using kangoeroes.leidingBeheer.Models.AuthViewModels;

namespace kangoeroes.leidingBeheer.Helpers
{
  public class RoleComparer: IEqualityComparer<RoleViewModel>
  {
    public bool Equals(RoleViewModel x, RoleViewModel y)
    {
      if (object.ReferenceEquals(x, y))
      {
        return true;
      }

      return x.Id == y.Id;
    }

    public int GetHashCode(RoleViewModel obj)
    {
      //Get hash code for the Name field if it is not null.
      int hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();

      //Get hash code for the Code field.
      int hashProductCode = obj.Id.GetHashCode();

      //Calculate the hash code for the product.
      return hashProductName ^ hashProductCode;
    }
  }
}
