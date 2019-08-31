using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OCTM.Application.ViewModels
{
    public class ContainerShipViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Capacity is Required")]
        [DisplayName("Capacity")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DataType(DataType.Date, ErrorMessage = "The Color is Required")]
        [DisplayName("Color")]
        public string Color { get; set; }
    }
}
