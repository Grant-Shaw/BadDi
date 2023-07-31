using System.Collections.Generic;
using System;

namespace BadDinosaurCodeTest.Web.Models
{
    public class DinosaurListViewModel
    { 
        public List<DinosaurListItemModel> Dinosaurs { get; set; }
    }

    public class DinosaurListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class EditDinosaurViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}