using System.Collections.Generic;
using static AspNetCore.Form.FormDataBuilder;

namespace AspNetCore.Form
{
    public class FormGroup
    {
        public FormGroup()
        {
            Controls = new List<InputControl>();
        }

        public string Name { get; set; }

        public List<InputControl> Controls { get; set; }
    }
}
