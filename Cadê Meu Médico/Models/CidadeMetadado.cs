using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadeMetadado))]
    public partial class cidades
    {

    }
    public class CidadeMetadado
    {
        [Required(ErrorMessage = "Obrigatório Informar o nome da cidade")]
        [StringLength(100,ErrorMessage = "O nome da cidade deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}