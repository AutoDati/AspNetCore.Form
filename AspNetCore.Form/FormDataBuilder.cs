using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Form
{
    public class FormDataBuilder
    {
        public const int InputTextMaxLengh = 50;

        public List<FormGroup> Build(Type type)
        {
            var formGroups = new List<FormGroup>();
            var allInputs = new List<InputControl>();
            var isFormGroupClass = type.GetCustomAttributes(typeof(FormGroupAttribute), false).Any();

            foreach (var property in type.GetProperties())
            {
                var dialogData = type.GetAttributeFrom<FormInputAttribute>(property);

                if (dialogData != null || isFormGroupClass)
                {
                    var inputData = new InputControl(property, dialogData);
                    allInputs.Add(inputData);
                }
            }

            var groups = allInputs.GroupBy(x => x.Group);

            foreach (var groupedData in groups)
            {
                var group = new FormGroup();
                group.Name = groupedData.Key;
                group.Controls.AddRange(groupedData.ToList());

                formGroups.Add(group);
            }

            return formGroups;
        }

    }
}