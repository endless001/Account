using System.ComponentModel.DataAnnotations;


namespace Account.API.Models
{
    public class AccountEntity
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public int Sex { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        [Encrypted]
        public string Password { get; set; }

    }
}
