using AspNetCore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Classes
{
    /// <summary>
    /// Para criar minha classe Personalizada de validação devo herdar a ValidationAttribute a minha classe e criar override o método IsValid
    /// A validação é feita em Client-Server-CLient
    /// Depois é só colocar o NomePersonaliada sem a necessidade de escreve o nome da classe completo pois o nome Attribute é padrão e desconsiderado nas chamadas do atribute. 
    /// </summary>
    public class NomePersonalizadaAttribute : ValidationAttribute
    {
        //Se eu quiser colocar um parametro de chamada ao contratutor da classe para o atributo chamado pelo ViewModel
        // private int _year;

        // public NomePersonalizadaAttribute(int year)
        public NomePersonalizadaAttribute()
        {
            //_year = year;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

              // posso escrever assim a validação para uma ViewModel neste caso a NovoUsuariomodel
            NovoUsuariomodel usuario = (NovoUsuariomodel)validationContext.ObjectInstance;
            // ou assim
            //var usuario = validationContext.ObjectInstance as NovoUsuariomodel;

            if (usuario == null)
            {
                throw new ArgumentException("Attribute não é aplicado para nome");
            }
    
            if (usuario.Nome == "Teste")
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        // Aqui implemento qual o erro que aparecerá na validação do Model NovoUsuariomodel caso não esteja dentro dos 
        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }
            else
            {
                // Use generic message: i.e. The field {0} is invalid
                //return this.FormatErrorMessage(validationContext.DisplayName);

                // Custom message
                return $"{validationContext.DisplayName}: Este nome já foi usado";
            }

        }
    }
}
