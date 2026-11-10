using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitTrack.Core
{
    public static class Orbitographie
    {
        const int rayonTerre = 6371;
        const double mu = 398600.4418;

        public static double PeriodeEnMinutes (double altitudeKm)
        {
            double periodeEnSecondes = 2 * Math.PI * Math.Sqrt((Math.Pow(rayonTerre, 3) / mu));
            double periodeEnMinutes = periodeEnSecondes / 60;
            return periodeEnMinutes;
        }

        public static string TypeOrbite(double altitudeKm)
        {
            string typeOrbite = altitudeKm switch
            {
                <= 160 => "Instable",
                >160 and <=2000 => "LEO (orbite basse)",
                >2000 and <=35_700 => "MEO (orbite moyenne)",
                >35_700 and <=35_900 => "GEO (géostationnaire)",
                _ => "HEO (orbite haute)"   
            };

            return typeOrbite;
        }
    }
}
