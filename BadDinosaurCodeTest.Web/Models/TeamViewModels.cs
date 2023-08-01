using System.Collections.Generic;

namespace BadDinosaurCodeTest.Web.Models;

public class ListTeamsViewModel
{ 
    public List<DinosaurListItemModel> Teams { get; set; }
}

public class TeamItemModel
{
    public int Id { get; set; }
    public string Name { get; set; }        
    public string Motto { get; set; }
    public List<TeamDinosaurModel> Dinosaurs { get; set; }
}

public class TeamDinosaurModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}