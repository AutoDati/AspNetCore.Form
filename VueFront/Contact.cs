using AspNetCore.Form;
using Models;
using System.ComponentModel.DataAnnotations;

namespace AspCoreVue
{
    [FormGroup]
    public class Contact : Base
    {
        [FormInput("My Integer")]

        public int Integer { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [FormInput(PlaceHolder = "type your email here")]
        public string Mail { get; set; }

        [FromProperty(typeof(Customer), nameof(Customer.Name))]
        public string Name { get; set; }
    }
}
