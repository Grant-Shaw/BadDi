using BadDinosaurCodeTest.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BadDinosaurCodeTest.Data.Models
{
    public partial class Dinosaur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DinosaurType DinosaurType { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? TeamId { get; set; }
    }
}
