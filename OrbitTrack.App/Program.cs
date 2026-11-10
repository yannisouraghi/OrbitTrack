using System.Globalization;
using Spectre.Console;
using OrbitTrack.Core;

AnsiConsole.MarkupLine("[green]Bienvenue dans OrbitTrack ![/]");
Console.Write("Ton prénom : ");
string? prenom = Console.ReadLine();
Console.WriteLine($"Salut {prenom}, l'ISS fait le tour de la Terre en 92 minutes environ.");

// Exercices 2, 3 et 4 : période et type d'orbite pour l'altitude saisie
double altitude = LireAltitude();
double periode = Orbitographie.PeriodeEnMinutes(altitude);
AnsiConsole.MarkupLine($"[red]La période à {altitude} km est de {periode:F1} min.[/]");
Console.WriteLine($"Type d'orbite : {Orbitographie.TypeOrbite(altitude)}");

// Exercice 5 : tableau des orbites de 200 à 2 000 km
Console.WriteLine();
Console.WriteLine($"{"Altitude",10} | {"Période",9} | {"Tours/jour",10} | Type");
Console.WriteLine(new string('-', 60));
for (int alt = 200; alt <= 2000; alt += 200)
{
    Console.WriteLine($"{alt,7} km | {Orbitographie.PeriodeEnMinutes(alt),5:F1} min | " +
                      $"{Orbitographie.OrbitesParJour(alt),10:F1} | {Orbitographie.TypeOrbite(alt)}");
}

// Exercice 6 : lire une ligne de données brute
Console.WriteLine();
string ligne = "  iss (zarya) ; leo ;420.5 ";
string[] morceaux = ligne.Split(';');
string nom = morceaux[0].Trim().ToUpper();
string type = morceaux[1].Trim().ToUpper();

// Les fichiers de données utilisent le point décimal : on lit en culture invariante
if (double.TryParse(morceaux[2].Trim(), CultureInfo.InvariantCulture, out double altitudeLue))
{
    Console.WriteLine($"{nom} | {type} | {altitudeLue} km | {Orbitographie.PeriodeEnMinutes(altitudeLue):F1} min");
}
else
{
    Console.WriteLine($"Altitude illisible pour {nom}");
}

// Exercice 3 : redemande tant que la saisie n'est pas un nombre positif
static double LireAltitude()
{
    double altitude;
    bool valide;
    do
    {
        Console.Write("Altitude du satellite en km : ");
        valide = double.TryParse(Console.ReadLine(), out altitude) && altitude >= 0;
        if (!valide)
        {
            Console.WriteLine("Saisie invalide : entre un nombre positif (ex. 420 ou 420,5).");
        }
    } while (!valide);

    return altitude;
}
