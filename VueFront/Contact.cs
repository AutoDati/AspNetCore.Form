using AspNetCore.Form;
using System.ComponentModel.DataAnnotations;

namespace AspCoreVue
{
    [FormGroup]
    public class Contact
    {
        [Form("My Integer")]
        public int Integer { get; set; }

        [Required]
        [Form(PlaceHolder = "type your email here")]
        public string Mail { get; set; }

        public string Name { get; set; }
    }
}
