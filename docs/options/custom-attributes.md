## Custom Attributes

The following attributes are provided in this tool.

## FormGroup

Creates an schema for the class where it is used.

## FormInput

```c#
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
```

## InputType

```c#
namespace AspNetCore.Form
{
    public enum InputType
    {
        /// <summary>
        /// Sets type based on the property type
        /// </summary>
        Default = 0,
        CheckBox = 1,
        Date = 2,
        Color = 3,
        Currency = 4,
        Select = 5,
        File = 6,
        MultiSelect = 7,
        Number = 8,
        Password = 9,
        Radio = 10,
        Switch = 11,
        Text = 12,
        TextArea = 13,
        Tel = 14,
        Url = 15,
        Time = 16,
        EMail = 17,
        List = 18,
        Month = 19,
        Week = 20,
        Range = 21,
        Decimal = 22,
    }
}


```

## FromProperty

It is possible to copy attributes from other classes!

```c#
[FormGroup]
public class Contact
{
    [FromProperty(typeof(Customer), nameof(Customer.Name))]
    public string Name { get; set; }
}
```
