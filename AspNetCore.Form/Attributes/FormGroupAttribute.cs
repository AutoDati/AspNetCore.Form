using System;

namespace AspNetCore.Form
{

    /// <summary>
    /// Makes every property in a class an input form field
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class FormGroupAttribute : Attribute
    {

    }
}
