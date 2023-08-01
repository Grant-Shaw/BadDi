using BadDinosaurCodeTest.Data.Models;
using System;
using System.Linq;

namespace BadDinosaurCodeTest.Data;

public static class DbInitializer
{
    public static void Initialize(DataContext context)
    {
        context.Database.EnsureCreated();

        if (context.Dinosaurs.Any())
        {
            return;
        }

        context.Dinosaurs.Add(new Dinosaur()
        {
            Name = "Diplodocus",
            CreatedOn = new DateTime(2020, 6, 1)
        });
        context.Dinosaurs.Add(new Dinosaur()
        {
            Name = "Stegosaurus",
            CreatedOn = new DateTime(2020, 6, 7)
        });
        context.Dinosaurs.Add(new Dinosaur()
        {
            Name = "Tyrannosaurus Rex",
            CreatedOn = new DateTime(2020, 6, 5)
        });
        context.Dinosaurs.Add(new Dinosaur()
        {
            Name = "Triceratops",
            CreatedOn = new DateTime(2020, 6, 20)
        });
        context.Teams.Add(new Team()
        {
            Name = "Roarsomes",
            Motto = "We'll sting your scales.",
            CreatedOn = new DateTime(2020, 2, 10)
        });
        context.Teams.Add(new Team()
        {
            Name = "Cretaceous Forever",
            Motto = "We're having the best time of our lives.",
            CreatedOn = new DateTime(2020, 2, 10)
        });
        context.SaveChanges();
    }
}
