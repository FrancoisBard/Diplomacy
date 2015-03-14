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

        static void CreateEuropeBoard()
        {
            //create province nodes. Data from http://en.wikibooks.org/wiki/Diplomacy/Geography + a few missing.
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
            var Albania = new Province("Albania", "ALB", "Balkans", SpaceType.Land);
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
            var NorthSea = new Province("North Sea", "NTH", "Atlantic", SpaceType.Sea);
            var NorwegianSea = new Province("Norwegian Sea", "NWS", "Atlantic", SpaceType.Sea);
            var Skagerrak = new Province("Skagerrak", "SKA", "Atlantic", SpaceType.Sea);
            var BalticSea = new Province("Baltic Sea", "BAL", "Baltic", SpaceType.Sea);
            var GulfOfBothnia = new Province("Gulf of Bothnia", "GOB", "Baltic", SpaceType.Sea);
            var AdriaticSea = new Province("Adriatic Sea", "ADS", "Mediterranean", SpaceType.Sea);
            var BlackSea = new Province("Black Sea", "BLA", "Mediterranean", SpaceType.Sea);
            var EasternMediterraneanSea = new Province("Eastern Mediterranean Sea", "EMS", "Mediterranean", SpaceType.Sea);
            var AeganSea = new Province("Aegan Sea", "AEG", "Mediterranean", SpaceType.Sea);
            var GulfOfLyons = new Province("Gulf of Lyons", "GOL", "Mediterranean", SpaceType.Sea);
            var IonianSea = new Province("Ionian Sea", "IOS", "Mediterranean", SpaceType.Sea);
            var TyrrhenianSea = new Province("Tyrrhenian Sea", "TYS", "Mediterranean", SpaceType.Sea);
            var WesternMediterraneanSea = new Province("Western Mediterranean Sea", "WMS", "Mediterranean", SpaceType.Sea);

            //impassable areas
            //Caspian Sea CAS or CSS Impassable areas 
            //Iceland ICE or ICL or ILN Impassable areas 
            //Siberia SIB Impassable areas 
            //Switzerland SWI Impassable areas 

            //coastlines
            var SaintPetersburgNorthCoast = new CoastLine("Saint Petersburg North Coast", "STP NC", "Russia");
            var SaintPetersburgSouthCoast = new CoastLine("Saint Petersburg South Coast", "STP SC", "Russia");
            var SpainNorthCoast = new CoastLine("Spain North Coast", "SPA NC", "Iberia");
            var SpainSouthCoast = new CoastLine("Spain South Coast", "SPA SC", "Iberia");
            var BulgariaEastCoast = new CoastLine("Bulgaria East Coast", "BUL EC", "Balkans");
            var BulgariaSouthCoast = new CoastLine("Bulgaria South Coast", "BUL SC", "Balkans");

            //attach coastlines
            SaintPetersburg.CoastLines.Add(SaintPetersburgNorthCoast);
            SaintPetersburg.CoastLines.Add(SaintPetersburgSouthCoast);
            Spain.CoastLines.Add(SpainNorthCoast);
            Spain.CoastLines.Add(SpainNorthCoast);
            Bulgaria.CoastLines.Add(BulgariaEastCoast);
            Bulgaria.CoastLines.Add(BulgariaSouthCoast);

            //attach neighbors (both ways)

            //top north seas
            NorthAtlanticOcean.AddNeighbor(NorwegianSea, Clyde, Liverpool, IrishSea, MidAtlanticOcean);
            NorwegianSea.AddNeighbor(BarentsSea, Norway, NorthSea, Edinburgh, Clyde, NorthAtlanticOcean);
            BarentsSea.AddNeighbor(SaintPetersburg, Norway, NorwegianSea);
            
            
            //scandinavian lands
            Finland.AddNeighbor(Norway, Sweden, GulfOfBothnia, SaintPetersburg);
            Norway.AddNeighbor(NorwegianSea, NorthSea, Skagerrak, Sweden, Finland, SaintPetersburg, BarentsSea);
            Sweden.AddNeighbor(Norway, Skagerrak, Denmark, BalticSea, GulfOfBothnia, Finland);
            
            //england
            Edinburgh.AddNeighbor(Clyde, Liverpool, Yorkshire, NorthSea, NorwegianSea);
            Clyde.AddNeighbor(NorthAtlanticOcean, Liverpool, Edinburgh, NorwegianSea);
            Liverpool.AddNeighbor(Clyde, NorthAtlanticOcean, IrishSea, Yorkshire, Wales, Edinburgh);
            Wales.AddNeighbor(Liverpool, IrishSea, EnglishChannel, London, Yorkshire);
            London.AddNeighbor(Yorkshire, Wales, EnglishChannel, NorthSea);
            Yorkshire.AddNeighbor(Edinburgh, Liverpool, Wales, London, NorthSea);

            //english seas
            NorthSea.AddNeighbor(NorwegianSea, Edinburgh, Yorkshire, London, EnglishChannel, Belgium, Holland, HeligolandBight,Denmark,Skagerrak,Norway);
            IrishSea.AddNeighbor(NorthAtlanticOcean, MidAtlanticOcean, EnglishChannel, Wales, Liverpool);
            EnglishChannel.AddNeighbor(IrishSea, MidAtlanticOcean, Brest, Picardy, Belgium, NorthSea, London, Wales);

            //baltics
                        HeligolandBight.AddNeighbor(NorthSea, Holland, Kiel, Denmark);
Denmark.AddNeighbor(NorthSea, HeligolandBight, Kiel, BalticSea, Sweden, Skagerrak);
            Skagerrak.AddNeighbor(Norway, NorthSea, Denmark, Sweden);
            BalticSea.AddNeighbor(Sweden, Denmark, Kiel, Berlin, Prussia, Livonia, GulfOfBothnia);
            GulfOfBothnia.AddNeighbor(Sweden, BalticSea, Livonia, SaintPetersburg, Finland);

            //russia
            SaintPetersburg.AddNeighbor(BarentsSea, Norway, Finland, GulfOfBothnia, Livonia, Moscow);
            Moscow.AddNeighbor();
            Livonia.AddNeighbor();
            Prussia.AddNeighbor();
            Warsaw.AddNeighbor();
            Ukraine.AddNeighbor();
            Sevastopol.AddNeighbor();

            //france
            Picardy.AddNeighbor();
            Brest.AddNeighbor();
            Paris.AddNeighbor();
            Gascony.AddNeighbor();
            Marseilles.AddNeighbor();
            Burgundy.AddNeighbor();

            //west
            MidAtlanticOcean.AddNeighbor();
            Spain.AddNeighbor();
            Portugal.AddNeighbor();

            //africa
            NorthAfrica.AddNeighbor();
            Tunis.AddNeighbor();

            //mediterranean
            WesternMediterraneanSea.AddNeighbor();
            GulfOfLyons.AddNeighbor();
            TyrrhenianSea.AddNeighbor();
            IonianSea.AddNeighbor();
            AdriaticSea.AddNeighbor();
            AeganSea.AddNeighbor();
            EasternMediterraneanSea.AddNeighbor();

            //black sea
            BlackSea.AddNeighbor();

            //belgium and hollland
            Belgium.AddNeighbor();
            Holland.AddNeighbor();

            //germany
            Kiel.AddNeighbor();
            Ruhr.AddNeighbor();
            Munich.AddNeighbor();
            Berlin.AddNeighbor();
            Bohemia.AddNeighbor();
            Tyrolia.AddNeighbor();

            //italy
            Piedmont.AddNeighbor();
            Tuscany.AddNeighbor();
            Rome.AddNeighbor();
            Naples.AddNeighbor();
            Apulia.AddNeighbor();
            Venice.AddNeighbor();
            
            //mid Europe
            Silesia.AddNeighbor();
            Galacia.AddNeighbor();
            
            //austria
            Vienna.AddNeighbor();
            Budapest.AddNeighbor();
            Trieste.AddNeighbor();
            
            //balkans
            Rumania.AddNeighbor();
            Serbia.AddNeighbor();
            Bulgaria.AddNeighbor();
            Albania.AddNeighbor();
            Greece.AddNeighbor();

            //turkey
            Constantinople.AddNeighbor();
            Ankara.AddNeighbor();
            Smyrna.AddNeighbor();
            Armenia.AddNeighbor();
            Syria.AddNeighbor();

            //hybrids

            //coastlines
        }
    }
}
