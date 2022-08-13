using System;
using System.ComponentModel.DataAnnotations;

namespace Fitema.Utils.ValidationAttributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;
        private readonly string _maxFileSizeString;
        public MaxFileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize * 1024 * 1024;
            _maxFileSizeString = maxFileSize.ToString() + " MB";
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            try
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    if (file.Length > _maxFileSize)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {_maxFileSizeString}.";
        }
    }
}

