using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ControleBO.Application.ViewModels
{
    public class ProcedimentoTipoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Sigla é obrigatório.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "A Sigla deve ter no mínimo 1 e no máximo 10 caracteres.")]
        [JsonProperty(PropertyName = "sigla")]
        public string Sigla { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "A Descrição deve ter no mínimo 1 e no máximo 150 caracteres.")]
        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}
