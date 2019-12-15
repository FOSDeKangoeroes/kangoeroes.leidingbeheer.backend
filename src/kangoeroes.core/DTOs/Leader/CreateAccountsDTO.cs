using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Leader
{
    public class CreateAccountsDTO {
        public decimal TabStartBalance {get;set;} = 0;

        public decimal DebtStartBalance {get; set;} = 0;
    }
}