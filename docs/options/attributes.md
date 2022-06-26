## Existing Attributes

Those existing attributes are used to create schemas

```c#
[Required]
[MinLength(3)]
[MaxLength(30)]
[StringLength(50, MinimumLength = 3)]
[Range(3, 10)]
[EmailAddress]
[ReadOnly(true)]
[DataType(DataType.CreditCard)]
[Url]
```

## DataType

```c#
namespace System.ComponentModel.DataAnnotations
{
    public enum DataType
    {
        Custom = 0,
        DateTime = 1,
        Date = 2,
        Time = 3,
        Duration = 4,
        PhoneNumber = 5,
        Currency = 6,
        Text = 7,
        Html = 8,
        MultilineText = 9,
        EmailAddress = 10,
        Password = 11,
        Url = 12,
        ImageUrl = 13,
        CreditCard = 14,
        PostalCode = 15,
        Upload = 16
    }
}

```
