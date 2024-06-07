using System.ComponentModel.DataAnnotations;

namespace ConsultaFacilWeb.Models
{
    public class MedicoModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome invalido")]
        public string Nome {  get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome invalido")]
        public string Crm { get; set; }
        public string Status { get; set; }

    }
}
