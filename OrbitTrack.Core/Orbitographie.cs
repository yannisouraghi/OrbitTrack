namespace OrbitTrack.Core
{
    public static class Orbitographie
    {
        public const double RayonTerreKm = 6371.0;
        public const double Mu = 398_600.4418; // constante gravitationnelle de la Terre, en km³/s²

        public static double PeriodeEnMinutes(double altitudeKm)
        {
            double rayonOrbiteKm = RayonTerreKm + altitudeKm;
            double periodeEnSecondes = 2 * Math.PI * Math.Sqrt(Math.Pow(rayonOrbiteKm, 3) / Mu);
            return periodeEnSecondes / 60;
        }

        public static double OrbitesParJour(double altitudeKm) => 1440 / PeriodeEnMinutes(altitudeKm);

        public static string TypeOrbite(double altitudeKm)
        {
            string typeOrbite = altitudeKm switch
            {
                <= 160 => "Instable",
                > 160 and <= 2000 => "LEO (orbite basse)",
                > 2000 and <= 35_700 => "MEO (orbite moyenne)",
                > 35_700 and <= 35_900 => "GEO (géostationnaire)",
                _ => "HEO (orbite haute)"
            };

            return typeOrbite;
        }
    }
}
