using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void CreateProvinceNodes()
        {
            //data from http://en.wikibooks.org/wiki/Diplomacy/Geography
            var NorthAfrica = new Province("North Africa", "NAF", "Africa", SpaceType.Land);
            var Tunis = new Province("Tunis", "TUN", "Africa", SpaceType.Land);
            var Bohemia = new Province("Bohemia", "BOH", "Austria", SpaceType.Land);
            var Budapest = new Province("Budapest", "BUD", "Austria", SpaceType.Land);
            var Galacia = new Province("Galacia", "GAL", "Austria", SpaceType.Land);
            var Trieste = new Province("Trieste", "TRI", "Austria", SpaceType.Land);
            var Tyrolia = new Province("Tyrolia", "TYR", "Austria", SpaceType.Land);
            var Vienna = new Province("Vienna", "VIE", "Austria", SpaceType.Land);
            var Bulgaria = new Province("Bulgaria", "BUL", "Balkans", SpaceType.Land);
            var Greece = new Province("Greece", "GRE", "Balkans", SpaceType.Land);
            var Rumania = new Province("Rumania", "RUM", "Balkans", SpaceType.Land);
            var Serbia = new Province("Serbia", "SER", "Balkans", SpaceType.Land);
            var Clyde = new Province("Clyde", "CLY", "England", SpaceType.Land);
            var Edinburgh = new Province("Edinburgh", "EDI", "England", SpaceType.Land);
            var Liverpool = new Province("Liverpool", "LVP", "England", SpaceType.Land);
            var London = new Province("London", "LON", "England", SpaceType.Land);
            var Wales = new Province("Wales", "WAL", "England", SpaceType.Land);
            var Yorkshire = new Province("Yorkshire", "YOR", "England", SpaceType.Land);
            var Brest = new Province("Brest", "BRE", "France", SpaceType.Land);
            var Burgundy = new Province("Burgundy", "BUR", "France", SpaceType.Land);
            var Gascony = new Province("Gascony", "GAS", "France", SpaceType.Land);
            var Marseilles = new Province("Marseilles", "MAR", "France", SpaceType.Land);
            var Paris = new Province("Paris", "PAR", "France", SpaceType.Land);
            var Picardy = new Province("Picardy", "PIC", "France", SpaceType.Land);
            var Berlin = new Province("Berlin", "BER", "Germany", SpaceType.Land);
            var Kiel = new Province("Kiel", "KIE", "Germany", SpaceType.Land);
            var Munich = new Province("Munich", "MUN", "Germany", SpaceType.Land);
            var Prussia = new Province("Prussia", "PRU", "Germany", SpaceType.Land);
            var Ruhr = new Province("Ruhr", "RUH", "Germany", SpaceType.Land);
            var Silesia = new Province("Silesia", "SIL", "Germany", SpaceType.Land);
            var Spain = new Province("Spain", "SPA", "Iberia", SpaceType.Land);
            var Portugal = new Province("Portugal", "POR", "Iberia", SpaceType.Land);
            var Apulia = new Province("Apulia", "APU", "Italy", SpaceType.Land);
            var Naples = new Province("Naples", "NAP", "Italy", SpaceType.Land);
            var Piedmont = new Province("Piedmont", "PIE", "Italy", SpaceType.Land);
            var Rome = new Province("Rome", "ROM", "Italy", SpaceType.Land);
            var Tuscany = new Province("Tuscany", "TUS", "Italy", SpaceType.Land);
            var Venice = new Province("Venice", "VEN", "Italy", SpaceType.Land);
            var Belgium = new Province("Belgium", "BEL", "Low Countries", SpaceType.Land);
            var Holland = new Province("Holland", "HOL", "Low Countries", SpaceType.Land);
            var Finland = new Province("Finland", "FIN", "Russia", SpaceType.Land);
            var Livonia = new Province("Livonia", "LVN", "Russia", SpaceType.Land);
            var Moscow = new Province("Moscow", "MOS", "Russia", SpaceType.Land);
            var Sevastopol = new Province("Sevastopol", "SEV", "Russia", SpaceType.Land);
            var SaintPetersburg = new Province("Saint Petersburg", "STP", "Russia", SpaceType.Land);
            var Ukraine = new Province("Ukraine", "UKR", "Russia", SpaceType.Land);
            var Warsaw = new Province("Warsaw", "WAR", "Russia", SpaceType.Land);
            var Denmark = new Province("Denmark", "DEN", "Scandinavia", SpaceType.Land);
            var Norway = new Province("Norway", "NWY", "Scandinavia", SpaceType.Land);
            var Sweden = new Province("Sweden", "SWE", "Scandinavia", SpaceType.Land);
            var Ankara = new Province("Ankara", "ANK", "Turkey", SpaceType.Land);
            var Armenia = new Province("Armenia", "ARM", "Turkey", SpaceType.Land);
            var Constantinople = new Province("Constantinople", "CON", "Turkey", SpaceType.Land);
            var Smyrna = new Province("Smyrna", "SMY", "Turkey", SpaceType.Land);
            var Syria = new Province("Syria", "SYR", "Turkey", SpaceType.Land);
            var BarentsSea = new Province("Barents Sea", "BAR", "Atlantic", SpaceType.Sea);
            var EnglishChannel = new Province("English Channel", "ENC", "Atlantic", SpaceType.Sea);
            var HeligolandBight = new Province("Heligoland Bight", "HEL", "Atlantic", SpaceType.Sea);
            var IrishSea = new Province("Irish Sea", "IRS", "Atlantic", SpaceType.Sea);
            var MidAtlanticOcean = new Province("Mid-Atlantic Ocean", "MAO", "Atlantic", SpaceType.Sea);
            var NorthAtlanticOcean = new Province("North Atlantic Ocean", "NAO", "Atlantic", SpaceType.Sea);
            var NorwegianSea = new Province("Norwegian Sea", "NWS", "Atlantic", SpaceType.Sea);
            var Skagerrak = new Province("Skagerrak", "SKA", "Atlantic", SpaceType.Sea);
            var BalticSea = new Province("Baltic Sea", "BAL", "Baltic", SpaceType.Sea);
            var GulfOfBothnia = new Province("Gulf of Bothnia", "GOB", "Baltic", SpaceType.Sea);
            var AdriaticSea = new Province("Adriatic Sea", "ADS", "Mediterranean", SpaceType.Sea);
            var BlackSea = new Province("Black Sea", "BLA", "Mediterranean", SpaceType.Sea);
            var EasternMediterraneanSea = new Province("Eastern Mediterranean Sea", "EMS", "Mediterranean", SpaceType.Sea);
            var GulfOfLyons = new Province("Gulf of Lyons", "GOL", "Mediterranean", SpaceType.Sea);
            var IonianSea = new Province("Ionian Sea", "IOS", "Mediterranean", SpaceType.Sea);
            var TyrrhenianSea = new Province("Tyrrhenian Sea", "TYS", "Mediterranean", SpaceType.Sea);
            var WesternMediterraneanSea = new Province("Western Mediterranean Sea", "WMS", "Mediterranean", SpaceType.Sea);

            //impassable areas
            //Caspian Sea CAS or CSS Impassable areas 
            //Iceland ICE or ICL or ILN Impassable areas 
            //Siberia SIB Impassable areas 
            //Switzerland SWI Impassable areas 
        }
    }
}
