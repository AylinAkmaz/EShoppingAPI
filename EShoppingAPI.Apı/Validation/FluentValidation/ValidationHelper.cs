﻿using EShoppingAPI.Helper.CustomException;
using FluentValidation;

namespace EShoppingAPI.Apı.Validation.FluentValidation
{
    public static class ValidationHelper
    {
        public static void Validate(Type type, object[] items)
        {
            if (typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Hata oluştu. Verilen Tip Validator Tipi Değildir.");
            }

            var validator = (IValidator)Activator.CreateInstance(type);

            foreach (var item in items)
            {
                if (validator.CanValidateInstancesOfType(item.GetType()))
                {
                    var result = validator.Validate(new ValidationContext<object>(item));
                    List<string> validationMessages = new List<string>();
                    foreach (var error in result.Errors)
                    {
                        validationMessages.Add(error.ErrorMessage);
                    }

                    if (!result.IsValid)
                    {
                        throw new FieldValidationException(validationMessages);
                    }


                }
            }

        }


    }
}
