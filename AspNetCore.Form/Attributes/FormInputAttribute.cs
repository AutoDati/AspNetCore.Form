using System;

namespace AspNetCore.Form
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class FormInputAttribute : Attribute
    {
        public FormInputAttribute()
        {

        }

        public FormInputAttribute(string label)
        {
            Label = label;
        }

        public string Label { get; }
        //public OperationType Operation { get; }
        public string DataSource { get; set; }
        public InputType Type { get; set; }

        // All controls
        public object DefaultValue { get; set; }
        public string Group { get; set; }
        public bool? IsVisible { get; set; } = true;

        public string PlaceHolder { get; set; }

        public string Helper { get; set; }

        // Only for dependent controls
        public string DependsOn { get; set; }

        // Only for Text Area controls
        public int TextAreaRows { get; set; }

        public string SourceName { get; set; }

       
    }
}