using AspNetCore.Form;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo
{
    public class Customer
    {
        public Customer(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
        [Required]
        [Form("Name", InputType = InputType.Text)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
