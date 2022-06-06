using System;

namespace AspNetCore.Form
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class FormAttribute : Attribute
    {
        public FormAttribute()
        {

        }

        public FormAttribute( string label) //OperationType operation,
        {
            //Operation = operation;
            Label = label;
            //IsVisible = true;
        }

        public string Label { get; }
        //public OperationType Operation { get; }
        public string DataSource { get; set; }
        public InputType Type { get; set; }

        // All controls
        public object DefaultValue { get; set; }
        public string Group { get; set; }
        public bool IsVisible { get; set; } = true;

        public string PlaceHolder { get; set; }

        public string Helper { get; set; }
        //public bool ExcludeFromResponse { get; set; }

        // Only for dependent controls
        public string DependsOn { get; set; }

        // Only for Text Area controls
        public int TextAreaRows { get; set; }

        // Only for Mask controls
        //public string Mask { get; set; }
        //public bool? Unmask { get; set; }
        //public string CharacterPattern { get; set; }

        // Only for Upload controls
        //public string FileAccept { get; set; }

        // Only for Dropdown / Multiselect controls
        //public bool ShowFilter { get; set; }
        //public string FilterMatchMode { get; set; }

        // Only for MultiSelect controls
        //public string DefaultLabel { get; set; } 

        // Only for controls that have Options (dropdown, multiselect, etc)
        public string SourceName { get; set; }

        // Only for Linked Dropdowns
        //public string LinkedDisplayName { get; set; }
        //public string LinkedPropertyName { get; set; }

        // Overrides
        //public string EntityLabelPropertyName { get; set; }
        //public string OverridePropertyName { get; set; }

        // Visibility
        //public string VisibleBasedOnInput { get; set; }
        //public string HiddenBasedOnInput { get; set; }

    }

    //public enum OperationType
    //{
    //    Create,
    //    Update,
    //    CreateAndUpdate
    //}
}