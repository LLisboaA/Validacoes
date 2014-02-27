using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validacoes.Helpers
{
    public class CpfValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && Validacoes.Helpers.ValidarCPF.Validar(value.ToString());
        }
    }
}