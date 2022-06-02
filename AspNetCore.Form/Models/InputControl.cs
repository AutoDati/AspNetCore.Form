﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Form
{
    public class InputControl
    {
        private readonly Type _type;

        public InputControl(string propertyName)
        {
            Name = propertyName;
        }

        public InputControl(string propertyName, Type type, RequiredAttribute requiredAttribute, MinLengthAttribute minlengAttribute,
            MaxLengthAttribute maxlengAttribute, FormAttribute formAttribute)
        {
            _type = type;

            PropertyName = propertyName; // String.IsNullOrEmpty(formAttribute.OverridePropertyName) ? propertyName : formAttribute.OverridePropertyName;
            Required = requiredAttribute != null;
            MinLength = minlengAttribute != null ? (int?)minlengAttribute.Length : null;
            MaxLength = maxlengAttribute != null ? (int?)maxlengAttribute.Length : null;

            DataSource = formAttribute.DataSource; // != UIAnnotations.DataSource.None
                                                   //? new SimpleNamedEntity { Id = ((int)formAttribute.Source).ToString(), Name = formAttribute.Source.ToString() }
                                                   //: null;
            DefaultValue = formAttribute.DefaultValue;
            //DependsOn = formAttribute.DependsOn;
            Group = formAttribute.Group;
            //Mask = formAttribute.Mask;
            //Unmask = formAttribute.Unmask;
            //CharacterPattern = formAttribute.CharacterPattern;
            //FileAccept = formAttribute.FileAccept;
            Name = formAttribute.Name;
            IsVisible = formAttribute.IsVisible ? null : (bool?)false;
            //ExcludeFromResponse = formAttribute.ExcludeFromResponse;
            SourceName = formAttribute.SourceName;
            //EntityLabelPropertyName = formAttribute.EntityLabelPropertyName;
            //LinkedDisplayName = formAttribute.LinkedDisplayName;
            //LinkedPropertyName = formAttribute.LinkedPropertyName;
            //VisibleBasedOnInput = formAttribute.VisibleBasedOnInput;
            //HiddenBasedOnInput = formAttribute.HiddenBasedOnInput;

            //var control =  formAttribute.ForcedType != FormType.Default ? formAttribute.ForcedType : GetControlType();

            InputType = formAttribute.InputType.ToString(); // new SimpleNamedEntity { Id = ((int)control).ToString(), Name = control.ToString() };

            //if (control == FormType.DropDown || control == FormType.MultiSelect || control == FormType.LinkedDropDown)
            //{
            //    PropertyName = FixDropDownName(propertyName);
            //    ShowFilter = formAttribute.ShowFilter;
            //    FilterMatchMode = formAttribute.FilterMatchMode;
            //}

            if (formAttribute.InputType == Form.InputType.TextArea)
            {
                TextAreaRows = formAttribute.TextAreaRows > 0 ? formAttribute.TextAreaRows : 5;
            }

            // -- 

            Type enumType = null;

            if (_type.IsEnum)
            {
                Required = true;
                enumType = _type;
            }
            else if (Nullable.GetUnderlyingType(_type)?.IsEnum == true)
            {
                Required = false;
                enumType = Nullable.GetUnderlyingType(_type);
            }

            //if (enumType != null)
            //{
            //    Data = EnumToSimpleNamedList(enumType).OrderBy(x => x.Name).ToList();
            //}

            // -- 


            // --
            // The Attribute doesn't accept nullable properties, so this is handled
            // here to doesn't send default values to the front
            if (ExcludeFromResponse == false)
            {
                ExcludeFromResponse = null;
            }

            if (TextAreaRows == 0)
            {
                TextAreaRows = null;
            }
            // --
        }

        public string InputType { get; set; }
        public string DataSource { get; set; }
        public string SourceName { get; set; }
        public string PropertyName { get; set; }

        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public string Group { get; set; }
        public bool? IsVisible { get; set; } = true;
        public bool? ExcludeFromResponse { get; set; }

        //public string DependsOn { get; set; }

        public int? TextAreaRows { get; set; }

        //public string Mask { get; set; }
        //public bool? Unmask { get; set; }
        //public string CharacterPattern { get; set; }

        //public string FileAccept { get; set; }

        //public bool? ShowFilter { get; set; }
        //public string FilterMatchMode { get; set; }

        public bool Required { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        //public List<SimpleNamedEntity<object>> Data { get; set; }

        //public string EntityLabelPropertyName { get; set; }

        //public string LinkedDisplayName { get; set; }
        //public string LinkedPropertyName { get; set; }
        //public string VisibleBasedOnInput { get; set; }
        //public string HiddenBasedOnInput { get; set; }

        private string GetControlType()
        {
            if (_type.FullName == typeof(String).FullName)
            {
                if (MaxLength.HasValue && MaxLength.Value <= 512)
                {
                    return Form.InputType.Text.ToString();
                }
                else if (MaxLength.HasValue && MaxLength.Value > 512)
                {
                    return Form.InputType.TextArea.ToString();
                }
                else
                {
                    return Form.InputType.Text.ToString();
                }
            }
            else if (_type.FullName == typeof(Boolean).FullName || _type.FullName == typeof(Boolean?).FullName)
            {
                return Form.InputType.CheckBox.ToString();
            }
            else if (_type.FullName == typeof(Int32).FullName || _type.FullName == typeof(Int64).FullName ||
                     _type.FullName == typeof(Int32?).FullName || _type.FullName == typeof(Int64?).FullName)
            {
                return Form.InputType.Number.ToString();
            }
            else if (_type.FullName == typeof(Single).FullName || _type.FullName == typeof(Single?).FullName ||
                     _type.FullName == typeof(Double).FullName || _type.FullName == typeof(Double?).FullName ||
                     _type.FullName == typeof(Decimal).FullName || _type.FullName == typeof(Decimal?).FullName)
            {
                return Form.InputType.Decimal.ToString();
            }
            else if (_type.FullName == typeof(DateTime).FullName || _type.FullName == typeof(DateTime?).FullName)
            {
                return Form.InputType.Calendar.ToString();
            }
            //else if (typeof(BaseEntity).IsAssignableFrom(_type))
            //{
            //    PropertyName = FixDropDownName(PropertyName);
            //    return FormType.DropDown;
            //}
            else if (_type.IsEnum)
            {
                return Form.InputType.DropDown.ToString();
            }
            else if (Nullable.GetUnderlyingType(_type)?.IsEnum == true)
            {
                return Form.InputType.DropDown.ToString();
            }
            else if (_type.FullName == typeof(string[]).FullName || _type.FullName == typeof(List<string>).FullName)
            {
                return Form.InputType.List.ToString();
            }
            else if (_type.FullName.StartsWith("System.Collections.Generic.List`1") || _type.FullName.StartsWith("System.Collections.Generic.IEnumerable`1"))
            {
                return Form.InputType.MultiSelect.ToString();
            }
            else if (_type.FullName == typeof(Guid).FullName || _type.FullName == typeof(Guid?).FullName)
            {
                return Form.InputType.Text.ToString();
            }
            else
            {
                throw new NotSupportedException("Type not supported: " + _type.FullName);
            }
        }

        //private string FixDropDownName(string propertyName)
        //{
        //    return propertyName.EndsWith("Id") ? propertyName.Substring(0, propertyName.Length - 2) : propertyName;
        //}

        //private List<SimpleNamedEntity<object>> EnumToSimpleNamedList(Type type)
        //{
        //    var results = new List<SimpleNamedEntity<object>>();
        //    var names = Enum.GetNames(type);
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        var name = names[i];
        //        var field = type.GetField(name);
        //        var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();
        //        var id = (int)Enum.Parse(type, name);

        //        if (fds != null)
        //        {
        //            results.Add(new SimpleNamedEntity<object> { Id = id, Name = (fds as DescriptionAttribute).Description });
        //        }
        //        else
        //        {
        //            results.Add(new SimpleNamedEntity<object> { Id = id, Name = field.Name });
        //        }
        //    }

        //    return results;
        //}
    }

}