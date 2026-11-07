using Spectre.Console;

AnsiConsole.MarkupLine("[green]Bienvenue dans OrbitTrack ![/]"); 
Console.Write("Ton prénom : ");
string? prenom = Console.ReadLine();
Console.WriteLine($"Salut {prenom}, l'ISS fait le tour de la Terre en 92 minutes environ.");