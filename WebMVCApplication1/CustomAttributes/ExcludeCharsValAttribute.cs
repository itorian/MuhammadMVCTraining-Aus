using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCApplication1.CustomAttributes
{
    public class ExcludeCharsValAttribute: ValidationAttribute, IClientValidatable
    {
        private readonly string _str;
        public ExcludeCharsValAttribute(string str) : base("{0} contains invalid character.")
        {
            this._str = str;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                for (int i = 0; i < _str.Length; i++)
                {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(_str[i].ToString()))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("str", _str);
            rule.ValidationType = "exclude";
            yield return rule;
        }
    }
}