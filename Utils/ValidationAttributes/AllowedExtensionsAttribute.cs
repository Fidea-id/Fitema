using System;
using System.ComponentModel.DataAnnotations;

namespace Fitema.Utils.ValidationAttributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            string formatList = "";
            for(int i = 0; i < _extensions.Length; i++) {
                if (i == 0) formatList += _extensions[i];
                else if (i == _extensions.Length - 1 && i > 0) formatList += $" and {_extensions[i]}";
                else formatList += $", {_extensions[i]}";
	        }

            return $"The extension is not allowed. Please use format {formatList} only! ";
        }
    }
}

