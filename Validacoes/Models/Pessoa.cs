using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.Expressions;
using DataAnnotationsExtensions;
using Validacoes.Helpers;

namespace Validacoes.Models
{
    public class Pessoa
    {   
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [CpfValidation(ErrorMessage = "CPF informado não é válido.")]
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        public string Cpf { get; set; }

        // Campo validado por ModelState no HomeController!
        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório")]
        [Email(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}