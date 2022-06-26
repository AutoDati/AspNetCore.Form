using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Form
{
    public class InputControl
    {
        private readonly Type _type;

        public InputControl(PropertyInfo property, FormInputAttribute formAttribute)
        {
            _type = property.PropertyType;
            PropertyName = property.Name;

            var attrs = property.GetCustomAttributes();
            var attrsFrom = property.GetCustomAttribute<FromPropertyAttribute>()?.SourceAttributes?.ToList();

            var attrList = attrs.ToList();

            if (attrsFrom != null && attrsFrom.Any())
                attrList.AddRange(attrsFrom);

            Type ??= GetControlType();

            foreach (var att in attrList)
            {
                switch (att)
                {
                    case RequiredAttribute _:
                        Required = true;
                        break;
                    case MinLengthAttribute ml:
                        MinLength = ml.Length;
                        break;
                    case MaxLengthAttribute ml:
                        MaxLength = ml.Length;
                        break;
                    case StringLengthAttribute sl:
                        MinLength = sl.MinimumLength;
                        MaxLength = sl.MaximumLength;
                        break;
                    case RangeAttribute r:
                        Min = (int?)r.Minimum;
                        Max = (int?)r.Maximum;
                        break;
                    case EmailAddressAttribute _:
                        Type = "email";
                        break;
                    case DataTypeAttribute dt:
                        Type = dt.DataType.ToString();
                        break;
                    case FormInputAttribute fi:
                        DefaultValue = fi.DefaultValue;
                        Group = fi.Group;
                        IsVisible = fi.IsVisible;
                        SourceName = fi.SourceName;
                        Label = fi.Label;
                        PlaceHolder = fi.PlaceHolder;
                        DataSource = fi.DataSource;
                        Group = fi.Group;
                        Type = fi.Type != InputType.Default ? formAttribute.Type.ToString().ToLower() : GetControlType();

                        if (formAttribute.Type is InputType.TextArea)
                        {
                            TextAreaRows = formAttribute.TextAreaRows > 0 ? formAttribute.TextAreaRows : 5;
                        }
                        break;
                    case RegularExpressionAttribute re:
                        Regex = re.Pattern;
                        break;
                    case ReadOnlyAttribute ro:
                        ReadOnly = ro.IsReadOnly;
                        break;
                }

            }

        }

        public string Type { get; set; }
        public string Regex { get; set; }
        public string DataSource { get; set; }
        public string SourceName { get; set; }
        public string PropertyName { get; set; }
        public string Label { get; set; }
        public object DefaultValue { get; set; }
        public string Group { get; set; }
        public bool? IsVisible { get; set; } = true;
        public bool? ReadOnly { get; set; }
        public bool? ExcludeFromResponse { get; set; }
        public int? TextAreaRows { get; set; }
        public bool? Required { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string PlaceHolder { get; set; }
        public string Helper { get; set; }
        public IEnumerable<(string value, string label)> Options { get; set; }
        public IEnumerable<string> OptionsLabels { get; set; }
        private string GetControlType()
        {
            var typeCode = System.Type.GetTypeCode(Nullable.GetUnderlyingType(_type));
            if (typeCode == TypeCode.Empty) typeCode = System.Type.GetTypeCode(_type);

            switch (typeCode)
            {
                case TypeCode.String when (MaxLength.HasValue && MaxLength.Value > 512):
                    return InputType.TextArea.ToString().ToLower();
                case TypeCode.String:
                    return InputType.Text.ToString().ToLower();

                case TypeCode.Boolean:
                    return InputType.CheckBox.ToString().ToLower();

                case TypeCode.Int32:
                case TypeCode.Int64:
                    return InputType.Number.ToString().ToLower();

                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return InputType.Decimal.ToString().ToLower();

                case TypeCode.DateTime:
                    return InputType.Date.ToString().ToLower();

            }

            if (_type.IsEnum || Nullable.GetUnderlyingType(_type)?.IsEnum == true)
            {
                return InputType.Select.ToString().ToLower();
            }

            if (_type is IEnumerable<string>)
            {
                return InputType.List.ToString().ToLower();
            }

            if (_type.FullName.StartsWith("System.Collections.Generic.List`1") || _type.FullName.StartsWith("System.Collections.Generic.IEnumerable`1"))
            {
                return InputType.MultiSelect.ToString().ToLower();
            }

            if (_type.FullName == typeof(Guid).FullName || _type.FullName == typeof(Guid?).FullName)
            {
                return InputType.Text.ToString().ToLower();
            }

            throw new NotSupportedException("Type not supported: " + _type.FullName);
        }

    }

}
