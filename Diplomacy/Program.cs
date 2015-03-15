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
            var NorthAfrica = new Province("North Africa", "NAF", "Africa", SpaceType.LandWithOneCoastline);
            var Tunis = new Province("Tunis", "TUN", "Africa", SpaceType.LandWithOneCoastline);
            var Bohemia = new Province("Bohemia", "BOH", "Austria", SpaceType.Land);
            var Budapest = new Province("Budapest", "BUD", "Austria", SpaceType.Land);
            var Galacia = new Province("Galacia", "GAL", "Austria", SpaceType.Land);
            var Trieste = new Province("Trieste", "TRI", "Austria", SpaceType.LandWithOneCoastline);
            var Tyrolia = new Province("Tyrolia", "TYR", "Austria", SpaceType.Land);
            var Vienna = new Province("Vienna", "VIE", "Austria", SpaceType.Land);
            var Bulgaria = new Province("Bulgaria", "BUL", "Balkans", SpaceType.LandWithTwoCoastlines);
            var Greece = new Province("Greece", "GRE", "Balkans", SpaceType.LandWithOneCoastline);
            var Rumania = new Province("Rumania", "RUM", "Balkans", SpaceType.LandWithOneCoastline);
            var Serbia = new Province("Serbia", "SER", "Balkans", SpaceType.Land);
            var Albania = new Province("Albania", "ALB", "Balkans", SpaceType.LandWithOneCoastline);
            var Clyde = new Province("Clyde", "CLY", "England", SpaceType.LandWithOneCoastline);
            var Edinburgh = new Province("Edinburgh", "EDI", "England", SpaceType.LandWithOneCoastline);
            var Liverpool = new Province("Liverpool", "LVP", "England", SpaceType.LandWithOneCoastline);
            var London = new Province("London", "LON", "England", SpaceType.LandWithOneCoastline);
            var Wales = new Province("Wales", "WAL", "England", SpaceType.LandWithOneCoastline);
            var Yorkshire = new Province("Yorkshire", "YOR", "England", SpaceType.LandWithOneCoastline);
            var Brest = new Province("Brest", "BRE", "France", SpaceType.LandWithOneCoastline);
            var Burgundy = new Province("Burgundy", "BUR", "France", SpaceType.Land);
            var Gascony = new Province("Gascony", "GAS", "France", SpaceType.LandWithOneCoastline);
            var Marseilles = new Province("Marseilles", "MAR", "France", SpaceType.LandWithOneCoastline);
            var Paris = new Province("Paris", "PAR", "France", SpaceType.Land);
            var Picardy = new Province("Picardy", "PIC", "France", SpaceType.LandWithOneCoastline);
            var Berlin = new Province("Berlin", "BER", "Germany", SpaceType.LandWithOneCoastline);
            var Kiel = new Province("Kiel", "KIE", "Germany", SpaceType.LandWithOneCoastline);
            var Munich = new Province("Munich", "MUN", "Germany", SpaceType.Land);
            var Prussia = new Province("Prussia", "PRU", "Germany", SpaceType.LandWithOneCoastline);
            var Ruhr = new Province("Ruhr", "RUH", "Germany", SpaceType.Land);
            var Silesia = new Province("Silesia", "SIL", "Germany", SpaceType.Land);
            var Spain = new Province("Spain", "SPA", "Iberia", SpaceType.LandWithTwoCoastlines);
            var Portugal = new Province("Portugal", "POR", "Iberia", SpaceType.LandWithOneCoastline);
            var Apulia = new Province("Apulia", "APU", "Italy", SpaceType.LandWithOneCoastline);
            var Naples = new Province("Naples", "NAP", "Italy", SpaceType.LandWithOneCoastline);
            var Piedmont = new Province("Piedmont", "PIE", "Italy", SpaceType.LandWithOneCoastline);
            var Rome = new Province("Rome", "ROM", "Italy", SpaceType.LandWithOneCoastline);
            var Tuscany = new Province("Tuscany", "TUS", "Italy", SpaceType.LandWithOneCoastline);
            var Venice = new Province("Venice", "VEN", "Italy", SpaceType.LandWithOneCoastline);
            var Belgium = new Province("Belgium", "BEL", "Low Countries", SpaceType.LandWithOneCoastline);
            var Holland = new Province("Holland", "HOL", "Low Countries", SpaceType.LandWithOneCoastline);
            var Finland = new Province("Finland", "FIN", "Russia", SpaceType.LandWithOneCoastline);
            var Livonia = new Province("Livonia", "LVN", "Russia", SpaceType.LandWithOneCoastline);
            var Moscow = new Province("Moscow", "MOS", "Russia", SpaceType.Land);
            var Sevastopol = new Province("Sevastopol", "SEV", "Russia", SpaceType.LandWithOneCoastline);
            var SaintPetersburg = new Province("Saint Petersburg", "STP", "Russia", SpaceType.LandWithTwoCoastlines);
            var Ukraine = new Province("Ukraine", "UKR", "Russia", SpaceType.Land);
            var Warsaw = new Province("Warsaw", "WAR", "Russia", SpaceType.Land);
            var Denmark = new Province("Denmark", "DEN", "Scandinavia", SpaceType.LandWithOneCoastline);
            var Norway = new Province("Norway", "NWY", "Scandinavia", SpaceType.LandWithOneCoastline);
            var Sweden = new Province("Sweden", "SWE", "Scandinavia", SpaceType.LandWithOneCoastline);
            var Ankara = new Province("Ankara", "ANK", "Turkey", SpaceType.LandWithOneCoastline);
            var Armenia = new Province("Armenia", "ARM", "Turkey", SpaceType.LandWithOneCoastline);
            var Constantinople = new Province("Constantinople", "CON", "Turkey", SpaceType.LandWithOneCoastline);
            var Smyrna = new Province("Smyrna", "SMY", "Turkey", SpaceType.LandWithOneCoastline);
            var Syria = new Province("Syria", "SYR", "Turkey", SpaceType.LandWithOneCoastline);
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

            //attach neighbors (both ways) (todo don't attach seas to lands with 2 coasts ?)

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
            NorthSea.AddNeighbor(NorwegianSea, Edinburgh, Yorkshire, London, EnglishChannel, Belgium, Holland, HeligolandBight, Denmark, Skagerrak, Norway);
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
            Moscow.AddNeighbor(SaintPetersburg, Livonia, Warsaw, Ukraine, Sevastopol);
            Livonia.AddNeighbor(GulfOfBothnia, BalticSea, Prussia, Warsaw, Moscow, SaintPetersburg);
            Prussia.AddNeighbor(Livonia, BalticSea, Berlin, Silesia, Warsaw);
            Warsaw.AddNeighbor(Prussia, Silesia, Galacia, Ukraine, Moscow, Livonia);
            Ukraine.AddNeighbor(Moscow, Warsaw, Galacia, Rumania, Sevastopol);
            Sevastopol.AddNeighbor(Moscow, Ukraine, Rumania, BlackSea, Armenia);

            //france
            Picardy.AddNeighbor(Belgium, EnglishChannel, Brest, Paris, Burgundy);
            Brest.AddNeighbor(Picardy, EnglishChannel, MidAtlanticOcean, Gascony, Paris);
            Paris.AddNeighbor(Picardy, Brest, Gascony, Burgundy);
            Gascony.AddNeighbor(Brest, MidAtlanticOcean, Spain, Marseilles, Burgundy, Paris);
            Marseilles.AddNeighbor(Burgundy, Gascony, Spain, GulfOfLyons, Piedmont);
            Burgundy.AddNeighbor(Belgium, Picardy, Paris, Gascony, Marseilles, Munich, Ruhr);

            //west
            MidAtlanticOcean.AddNeighbor(NorthAtlanticOcean, IrishSea, EnglishChannel, Brest, Gascony, Spain, Portugal, WesternMediterraneanSea, NorthAfrica);
            Spain.AddNeighbor(MidAtlanticOcean, Portugal, WesternMediterraneanSea, GulfOfLyons, Marseilles, Gascony);
            Portugal.AddNeighbor(MidAtlanticOcean, Spain);

            //africa
            NorthAfrica.AddNeighbor(MidAtlanticOcean, WesternMediterraneanSea, Tunis);
            Tunis.AddNeighbor(NorthAfrica, WesternMediterraneanSea, TyrrhenianSea, IonianSea);

            //mediterranean
            WesternMediterraneanSea.AddNeighbor(MidAtlanticOcean, NorthAfrica, Tunis, TyrrhenianSea, GulfOfLyons, Spain);
            GulfOfLyons.AddNeighbor(Marseilles, Spain, WesternMediterraneanSea, TyrrhenianSea, Tuscany, Piedmont);
            TyrrhenianSea.AddNeighbor(GulfOfLyons, WesternMediterraneanSea, Tunis, IonianSea, Naples, Rome, Tuscany);
            IonianSea.AddNeighbor(EasternMediterraneanSea, AeganSea, Greece, Albania, AdriaticSea, Apulia, Naples, TyrrhenianSea, Tunis);
            AdriaticSea.AddNeighbor(Venice, Apulia, IonianSea, Albania, Trieste);
            AeganSea.AddNeighbor(Bulgaria, Greece, IonianSea, EasternMediterraneanSea, Smyrna, Constantinople);
            EasternMediterraneanSea.AddNeighbor(IonianSea, AeganSea, Smyrna, Syria);

            //black sea
            BlackSea.AddNeighbor(Sevastopol, Rumania, Bulgaria, Constantinople, Ankara, Armenia);

            //belgium and hollland
            Belgium.AddNeighbor(NorthSea, EnglishChannel, Picardy, Burgundy, Ruhr, Holland);
            Holland.AddNeighbor(NorthSea, Belgium, Ruhr, Kiel, HeligolandBight);

            //germany
            Kiel.AddNeighbor(Denmark, HeligolandBight, Holland, Ruhr, Munich, Berlin, BalticSea);
            Ruhr.AddNeighbor(Holland, Belgium, Burgundy, Munich, Kiel);
            Munich.AddNeighbor(Ruhr, Burgundy, Tyrolia, Bohemia, Silesia, Berlin, Kiel);
            Berlin.AddNeighbor(BalticSea, Kiel, Munich, Silesia, Prussia);
            Bohemia.AddNeighbor(Munich, Tyrolia, Vienna, Galacia, Silesia);
            Tyrolia.AddNeighbor(Munich, Piedmont, Venice, Trieste, Vienna, Bohemia);

            //italy
            Piedmont.AddNeighbor(Marseilles, GulfOfLyons, Tuscany, Venice, Tyrolia);
            Tuscany.AddNeighbor(Piedmont, GulfOfLyons, TyrrhenianSea, Rome, Venice);
            Rome.AddNeighbor(Tuscany, TyrrhenianSea, Naples, Apulia, Venice);
            Naples.AddNeighbor(Rome, TyrrhenianSea, IonianSea, Apulia);
            Apulia.AddNeighbor(Venice, Rome, Naples, IonianSea, AdriaticSea);
            Venice.AddNeighbor(Piedmont, Tuscany, Rome, Apulia, AdriaticSea, Trieste, Tyrolia);

            //mid Europe
            Silesia.AddNeighbor(Prussia, Berlin, Munich, Bohemia, Galacia, Warsaw);
            Galacia.AddNeighbor(Warsaw, Silesia, Bohemia, Vienna, Budapest, Rumania, Ukraine);

            //austria
            Vienna.AddNeighbor(Bohemia, Tyrolia, Trieste, Budapest, Galacia);
            Budapest.AddNeighbor(Galacia, Vienna, Trieste, Serbia, Rumania);
            Trieste.AddNeighbor(Vienna, Tyrolia, Venice, AdriaticSea, Albania, Serbia, Budapest);

            //balkans
            Rumania.AddNeighbor(Ukraine, Galacia, Budapest, Serbia, Bulgaria, BlackSea, Sevastopol);
            Serbia.AddNeighbor(Budapest, Trieste, Albania, Greece, Bulgaria, Rumania);
            Bulgaria.AddNeighbor(Rumania, Serbia, Greece, AeganSea, Constantinople, BlackSea);
            Albania.AddNeighbor(Trieste, AdriaticSea, IonianSea, Greece, Serbia);
            Greece.AddNeighbor(Serbia, Albania, IonianSea, AeganSea, Bulgaria);

            //turkey
            Constantinople.AddNeighbor(Bulgaria, AeganSea, Smyrna, Ankara, BlackSea);
            Ankara.AddNeighbor(BlackSea, Constantinople, Smyrna, Armenia);
            Smyrna.AddNeighbor(Constantinople, AeganSea, EasternMediterraneanSea, Syria, Armenia, Ankara);
            Armenia.AddNeighbor(Sevastopol, BlackSea, Ankara, Smyrna, Syria);
            Syria.AddNeighbor(Armenia, Smyrna, EasternMediterraneanSea);

            //attach coastlines neighbors
            SpainNorthCoast.AddNeighbor(Portugal, MidAtlanticOcean, Gascony);
            SpainSouthCoast.AddNeighbor(MidAtlanticOcean, Portugal, WesternMediterraneanSea, GulfOfLyons, Marseilles);
            SaintPetersburgNorthCoast.AddNeighbor(BarentsSea, Norway);
            SaintPetersburgSouthCoast.AddNeighbor(Finland, Livonia, GulfOfBothnia);
            BulgariaEastCoast.AddNeighbor(Rumania, BlackSea, Constantinople);
            BulgariaSouthCoast.AddNeighbor(Greece, AeganSea, Constantinople);

            //supply centres
            var portugalCentre = new SupplyCentre(Portugal);
            var spainCentre = new SupplyCentre(Spain);

            var brestCentre = new SupplyCentre(Brest, Force.France);
            var parisCentre = new SupplyCentre(Paris, Force.France);
            var marseillesCentre = new SupplyCentre(Marseilles, Force.France);

            var edinburghCentre = new SupplyCentre(Edinburgh, Force.England);
            var liverpoolCentre = new SupplyCentre(Liverpool, Force.England);
            var londonCentre = new SupplyCentre(London, Force.England);

            var belgiumCentre = new SupplyCentre(Belgium);
            var hollandCentre = new SupplyCentre(Holland);

            var kielCentre = new SupplyCentre(Kiel, Force.Germany);
            var berlinCentre = new SupplyCentre(Berlin, Force.Germany);
            var munichCentre = new SupplyCentre(Munich, Force.Germany);

            var veniceCentre = new SupplyCentre(Venice, Force.Italy);
            var romeCentre = new SupplyCentre(Rome, Force.Italy);
            var naplesCentre = new SupplyCentre(Naples, Force.Italy);

            var viennaCentre = new SupplyCentre(Vienna, Force.AustriaHungary);
            var triesteCentre = new SupplyCentre(Budapest, Force.AustriaHungary);
            var budapestCentre = new SupplyCentre(Trieste, Force.AustriaHungary);

            var saintPetersburgCentre = new SupplyCentre(SaintPetersburg, Force.Russia);
            var moscowCentre = new SupplyCentre(Moscow, Force.Russia);
            var sevastopolCentre = new SupplyCentre(Sevastopol, Force.Russia);
            var warsawCentre = new SupplyCentre(Warsaw, Force.Russia);

            var serbiaCentre = new SupplyCentre(Serbia);
            var rumaniaCentre = new SupplyCentre(Rumania);
            var bulgariaCentre = new SupplyCentre(Bulgaria);

            var greeceCentre = new SupplyCentre(Greece);
            var tunisCentre = new SupplyCentre(Tunis);

            var constantinopleCentre = new SupplyCentre(Constantinople, Force.Turkey);
            var ankaraCentre = new SupplyCentre(Ankara, Force.Turkey);
            var smyrnaCentre = new SupplyCentre(Smyrna, Force.Turkey);

            var norwayCentre = new SupplyCentre(Norway);
            var swedenCentre = new SupplyCentre(Sweden);
            var denmarkCentre = new SupplyCentre(Denmark);

            //initialize units
            var marseillesUnit = new Unit(UnitType.Army, Force.France, Marseilles);
            var parisUnit = new Unit(UnitType.Army, Force.France, Paris);
            var brestUnit = new Unit(UnitType.Fleet, Force.France, Brest);

            var edinburghUnit = new Unit(UnitType.Fleet, Force.England, Edinburgh);
            var liverpoolUnit = new Unit(UnitType.Army, Force.England, Liverpool);
            var londonUnit = new Unit(UnitType.Fleet, Force.England, London);

            var kielUnit = new Unit(UnitType.Fleet, Force.Germany, Kiel);
            var berlinUnit = new Unit(UnitType.Army, Force.Germany, Berlin);
            var munichUnit = new Unit(UnitType.Army, Force.Germany, Munich);

            var veniceUnit = new Unit(UnitType.Army, Force.Italy, Venice);
            var romeUnit = new Unit(UnitType.Army, Force.Italy, Rome);
            var naplesUnit = new Unit(UnitType.Fleet, Force.Italy, Naples);

            var viennaUnit = new Unit(UnitType.Army, Force.AustriaHungary, Vienna);
            var triesteUnit = new Unit(UnitType.Fleet, Force.AustriaHungary, Trieste);
            var budapestUnit = new Unit(UnitType.Army, Force.AustriaHungary, Budapest);

            var constantinopleUnit = new Unit(UnitType.Army, Force.Turkey, Constantinople);
            var ankaraUnit = new Unit(UnitType.Fleet, Force.Turkey, Ankara);
            var smyrnaUnit = new Unit(UnitType.Army, Force.Turkey, Smyrna);

            var saintPetersburgUnit = new Unit(UnitType.Fleet, Force.Russia, SaintPetersburg);
            var moscowUnit = new Unit(UnitType.Army, Force.Russia, Moscow);
            var sevastopolUnit = new Unit(UnitType.Fleet, Force.Russia, Sevastopol);
            var warsawUnit = new Unit(UnitType.Army, Force.Russia, Warsaw);
        }
    }
}
