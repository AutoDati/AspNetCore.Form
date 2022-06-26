using AspNetCore.Form;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
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

        public bool? BooleanProp { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name2 { get; set; }

        [FormInput(Type = InputType.Range)]
        public int Years { get; set; }

        [Range(3, 10)]
        [Required]
        [FormInput(PlaceHolder = "type your age")]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public System.DateTime? HireDate { get; set; }

        [ReadOnly(true)]
        public string Name3 { get; private set; }

        [DataType(DataType.CreditCard)]
        public string Cred { get; set; }

        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        public string NameRE { get; set; }

        [Url]
        [Required]
        public string URL { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string HiddenName { get; set; }
    }
}
