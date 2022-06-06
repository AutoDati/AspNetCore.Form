using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetCore.Form
{
    public class FormDataBuilder
    {
        public const int InputTextMaxLengh = 50;

        public List<FormGroup> Build(Type type) //, OperationType operation
        {
            var results = new List<FormGroup>();
            var allInputs = new List<InputControl>();
            var isFormGroupClass = type.GetCustomAttributes(typeof(FormGroupAttribute), false).Any();

            foreach (var property in type.GetProperties())
            {
                var required = type.GetAttributeFrom<RequiredAttribute>(property);
                var minlen = type.GetAttributeFrom<MinLengthAttribute>(property);
                var maxlen = type.GetAttributeFrom<MaxLengthAttribute>(property);

                var dialogData = type.GetAttributeFrom<FormAttribute>(property);

                if (dialogData != null || isFormGroupClass)// && (operation == dialogData.Operation || dialogData.Operation == OperationType.CreateAndUpdate))
                {
                    var name = property.Name; // Char.ToLower(property.Name[0]) + property.Name.Substring(1);

                    //if (dialogData.Source == DataSource.ChildForm)
                    //{
                    //    allInputs.AddRange(Build(property.PropertyType, operation).SelectMany(x => x.Controls));
                    //}
                    //else
                    {
                        var inputData = new InputControl(name, property.PropertyType, required, minlen, maxlen, dialogData);
                        allInputs.Add(inputData);
                    }
                }
            }

            var groups = allInputs.GroupBy(x => x.Group);

            foreach (var groupedData in groups)
            {
                var group = new FormGroup();
                group.Name = groupedData.Key;
                group.Controls.AddRange(groupedData.ToList());

                results.Add(group);
            }

            return results;
        }
    
    }
}