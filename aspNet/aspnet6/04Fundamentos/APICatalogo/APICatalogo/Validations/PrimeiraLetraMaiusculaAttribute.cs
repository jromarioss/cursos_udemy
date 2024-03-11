using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validations;

public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
{
    //1 o valor, 2 trás informações do contexto onde aplica a validação
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var primeiraLetra = value.ToString()[0].ToString();

        if (primeiraLetra != primeiraLetra.ToUpper())
        {
            return new ValidationResult("A primeira letra do nome do produto dever ser maiuscula.");
        }

        return ValidationResult.Success;
    }
}
