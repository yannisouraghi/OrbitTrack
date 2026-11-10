using Spectre.Console;
using OrbitTrack.Core;

AnsiConsole.MarkupLine("[green]Bienvenue dans OrbitTrack ![/]"); 
Console.Write("Ton prénom : ");
string? prenom = Console.ReadLine();
Console.WriteLine($"Salut {prenom}, l'ISS fait le tour de la Terre en 92 minutes environ.");
double show = Orbitographie.PeriodeEnMinutes(420);
AnsiConsole.MarkupLine($"[red] La periode en minutes est : { show }![/]");


static void LireAltitude()
{ 
    do
    {
        Console.WriteLine("Saisir une altitude correcte : ");
    }
    while (double.TryParse(Console.ReadLine(), out double value));
}

LireAltitude();