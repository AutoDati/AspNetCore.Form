using AspNetCore.Form;
using System.ComponentModel.DataAnnotations;

namespace VueFront
{
    [FormGroup]
    public class Customer
    {
        public Customer(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(3,10)]
        [Required]
        [Form( PlaceHolder = "type your age" )]
        public int Age { get; set; }
        [EmailAddress] 
        public string Email { get; set; }
    }
}
