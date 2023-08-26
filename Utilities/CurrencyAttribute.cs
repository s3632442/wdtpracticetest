using System;
using System.ComponentModel.DataAnnotations;

public class CurrencyAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return false;

        decimal result;
        return decimal.TryParse(value.ToString(), out result);
    }
}
