using System.Collections.Generic;
using Diplomacy.Board;

namespace Diplomacy
{
    static class EuropeanBoardFactory
    {
        //provinces
        private static Province _northAfrica;
        private static Province _locations;
        private static Province _bohemia;
        private static Province _budapest;
        private static Province _galacia;
        private static Province _province;
        private static Province _tyrolia;
        private static Province _location;
        private static Province _bulgaria;
        private static Province _greece;
        private static Province _rumania;
        private static Province _serbia;
        private static Province _albania;
        private static Province _clyde;
        private static Province _edinburgh;
        private static Province _liverpool;
        private static Province _london;
        private static Province _wales;
        private static Province _yorkshire;
        private static Province _brest;
        private static Province _burgundy;
        private static Province _gascony;
        private static Province _marseilles;
        private static Province _paris;
        private static Province _picardy;
        private static Province _berlin;
        private static Province _kiel;
        private static Province _munich;
        private static Province _prussia;
        private static Province _ruhr;
        private static Province _silesia;
        private static Province _spain;
        private static Province _portugal;
        private static Province _apulia;
        private static Province _naples;
        private static Province _piedmont;
        private static Province _rome;
        private static Province _tuscany;
        private static Province _venice;
        private static Province _belgium;
        private static Province _holland;
        private static Province _finland;
        private static Province _livonia;
        private static Province _moscow;
        private static Province _sevastopol;
        private static Province _saintPetersburg;
        private static Province _ukraine;
        private static Province _warsaw;
        private static Province _denmark;
        private static Province _norway;
        private static Province _sweden;
        private static Province _ankara;
        private static Province _armenia;
        private static Province _constantinople;
        private static Province _smyrna;
        private static Province _syria;
        private static Province _barentsSea;
        private static Province _englishChannel;
        private static Province _heligolandBight;
        private static Province _irishSea;
        private static Province _midAtlanticOcean;
        private static Province _northAtlanticOcean;
        private static Province _northSea;
        private static Province _norwegianSea;
        private static Province _skagerrak;
        private static Province _balticSea;
        private static Province _gulfOfBothnia;
        private static Province _adriaticSea;
        private static Province _blackSea;
        private static Province _easternMediterraneanSea;
        private static Province _aeganSea;
        private static Province _gulfOfLyons;
        private static Province _ionianSea;
        private static Province _tyrrhenianSea;
        private static Province _westernMediterraneanSea;

        //coastlines
        private static CoastLine _saintPetersburgNorthCoast;
        private static CoastLine _saintPetersburgSouthCoast;
        private static CoastLine _spainNorthCoast;
        private static CoastLine _spainSouthCoast;
        private static CoastLine _bulgariaEastCoast;
        private static CoastLine _bulgariaSouthCoast;

        //supply centres
        private static SupplyCentre _portugalCentre;
        private static SupplyCentre _spainCentre;
        private static SupplyCentre _brestCentre;
        private static SupplyCentre _parisCentre;
        private static SupplyCentre _marseillesCentre;
        private static SupplyCentre _edinburghCentre;
        private static SupplyCentre _liverpoolCentre;
        private static SupplyCentre _londonCentre;
        private static SupplyCentre _belgiumCentre;
        private static SupplyCentre _hollandCentre;
        private static SupplyCentre _kielCentre;
        private static SupplyCentre _berlinCentre;
        private static SupplyCentre _munichCentre;
        private static SupplyCentre _veniceCentre;
        private static SupplyCentre _romeCentre;
        private static SupplyCentre _naplesCentre;
        private static SupplyCentre _viennaCentre;
        private static SupplyCentre _triesteCentre;
        private static SupplyCentre _budapestCentre;
        private static SupplyCentre _saintPetersburgCentre;
        private static SupplyCentre _moscowCentre;
        private static SupplyCentre _sevastopolCentre;
        private static SupplyCentre _warsawCentre;
        private static SupplyCentre _serbiaCentre;
        private static SupplyCentre _rumaniaCentre;
        private static SupplyCentre _bulgariaCentre;
        private static SupplyCentre _greeceCentre;
        private static SupplyCentre _tunisCentre;
        private static SupplyCentre _constantinopleCentre;
        private static SupplyCentre _ankaraCentre;
        private static SupplyCentre _smyrnaCentre;
        private static SupplyCentre _norwayCentre;
        private static SupplyCentre _swedenCentre;
        private static SupplyCentre _denmarkCentre;

        //units
        private static Unit _marseillesUnit;
        private static Unit _parisUnit;
        private static Unit _brestUnit;
        private static Unit _edinburghUnit;
        private static Unit _liverpoolUnit;
        private static Unit _londonUnit;
        private static Unit _kielUnit;
        private static Unit _berlinUnit;
        private static Unit _munichUnit;
        private static Unit _veniceUnit;
        private static Unit _romeUnit;
        private static Unit _naplesUnit;
        private static Unit _viennaUnit;
        private static Unit _triesteUnit;
        private static Unit _budapestUnit;
        private static Unit _constantinopleUnit;
        private static Unit _ankaraUnit;
        private static Unit _smyrnaUnit;
        private static Unit _saintPetersburgUnit;
        private static Unit _moscowUnit;
        private static Unit _sevastopolUnit;
        private static Unit _warsawUnit;

        public static Board.Board CreateEuropeBoard()
        {
            //create a blank board
            var europeBoard = new Board.Board();

            //initialize all the objects
            SetProvinces();
            SetCoastlines();
            SetCentres();
            SetUnits();

            //tie them together
            AttachCoastlines();
            AttachNeighbors();

            //attach them to the board
            AttachProvinces(europeBoard);
            AttachCentres(europeBoard);
            SetUnits(europeBoard);

            //return the board
            return europeBoard;
        }

        private static void SetUnits(Board.Board europeBoard)
        {
            europeBoard.Units = new HashSet<Unit>()
            {
                _marseillesUnit,
                _parisUnit,
                _brestUnit,
                _edinburghUnit,
                _liverpoolUnit,
                _londonUnit,
                _kielUnit,
                _berlinUnit,
                _munichUnit,
                _veniceUnit,
                _romeUnit,
                _naplesUnit,
                _viennaUnit,
                _triesteUnit,
                _budapestUnit,
                _constantinopleUnit,
                _ankaraUnit,
                _smyrnaUnit,
                _saintPetersburgUnit,
                _moscowUnit,
                _sevastopolUnit,
                _warsawUnit
            };
        }

        private static void SetUnits()
        {
            _marseillesUnit = new Unit(UnitType.Army, Force.France, _marseilles);
            _parisUnit = new Unit(UnitType.Army, Force.France, _paris);
            _brestUnit = new Unit(UnitType.Fleet, Force.France, _brest);

            _edinburghUnit = new Unit(UnitType.Fleet, Force.England, _edinburgh);
            _liverpoolUnit = new Unit(UnitType.Army, Force.England, _liverpool);
            _londonUnit = new Unit(UnitType.Fleet, Force.England, _london);

            _kielUnit = new Unit(UnitType.Fleet, Force.Germany, _kiel);
            _berlinUnit = new Unit(UnitType.Army, Force.Germany, _berlin);
            _munichUnit = new Unit(UnitType.Army, Force.Germany, _munich);

            _veniceUnit = new Unit(UnitType.Army, Force.Italy, _venice);
            _romeUnit = new Unit(UnitType.Army, Force.Italy, _rome);
            _naplesUnit = new Unit(UnitType.Fleet, Force.Italy, _naples);

            _viennaUnit = new Unit(UnitType.Army, Force.AustriaHungary, _location);
            _triesteUnit = new Unit(UnitType.Fleet, Force.AustriaHungary, _province);
            _budapestUnit = new Unit(UnitType.Army, Force.AustriaHungary, _budapest);

            _constantinopleUnit = new Unit(UnitType.Army, Force.Turkey, _constantinople);
            _ankaraUnit = new Unit(UnitType.Fleet, Force.Turkey, _ankara);
            _smyrnaUnit = new Unit(UnitType.Army, Force.Turkey, _smyrna);

            _saintPetersburgUnit = new Unit(UnitType.Fleet, Force.Russia, _saintPetersburg);
            _moscowUnit = new Unit(UnitType.Army, Force.Russia, _moscow);
            _sevastopolUnit = new Unit(UnitType.Fleet, Force.Russia, _sevastopol);
            _warsawUnit = new Unit(UnitType.Army, Force.Russia, _warsaw);
        }

        private static void AttachCentres(Board.Board europeBoard)
        {
            europeBoard.SupplyCentres = new HashSet<SupplyCentre>()
            {
                _portugalCentre,
                _spainCentre,
                _brestCentre,
                _parisCentre,
                _marseillesCentre,
                _edinburghCentre,
                _liverpoolCentre,
                _londonCentre,
                _belgiumCentre,
                _hollandCentre,
                _kielCentre,
                _berlinCentre,
                _munichCentre,
                _veniceCentre,
                _romeCentre,
                _naplesCentre,
                _viennaCentre,
                _triesteCentre,
                _budapestCentre,
                _saintPetersburgCentre,
                _moscowCentre,
                _sevastopolCentre,
                _warsawCentre,
                _serbiaCentre,
                _rumaniaCentre,
                _bulgariaCentre,
                _greeceCentre,
                _tunisCentre,
                _constantinopleCentre,
                _ankaraCentre,
                _smyrnaCentre,
                _norwayCentre,
                _swedenCentre,
                _denmarkCentre
            };
        }

        private static void SetCentres()
        {
            _portugalCentre = new SupplyCentre(_portugal);
            _spainCentre = new SupplyCentre(_spain);

            _brestCentre = new SupplyCentre(_brest, Force.France);
            _parisCentre = new SupplyCentre(_paris, Force.France);
            _marseillesCentre = new SupplyCentre(_marseilles, Force.France);

            _edinburghCentre = new SupplyCentre(_edinburgh, Force.England);
            _liverpoolCentre = new SupplyCentre(_liverpool, Force.England);
            _londonCentre = new SupplyCentre(_london, Force.England);

            _belgiumCentre = new SupplyCentre(_belgium);
            _hollandCentre = new SupplyCentre(_holland);

            _kielCentre = new SupplyCentre(_kiel, Force.Germany);
            _berlinCentre = new SupplyCentre(_berlin, Force.Germany);
            _munichCentre = new SupplyCentre(_munich, Force.Germany);

            _veniceCentre = new SupplyCentre(_venice, Force.Italy);
            _romeCentre = new SupplyCentre(_rome, Force.Italy);
            _naplesCentre = new SupplyCentre(_naples, Force.Italy);

            _viennaCentre = new SupplyCentre(_location, Force.AustriaHungary);
            _triesteCentre = new SupplyCentre(_budapest, Force.AustriaHungary);
            _budapestCentre = new SupplyCentre(_province, Force.AustriaHungary);

            _saintPetersburgCentre = new SupplyCentre(_saintPetersburg, Force.Russia);
            _moscowCentre = new SupplyCentre(_moscow, Force.Russia);
            _sevastopolCentre = new SupplyCentre(_sevastopol, Force.Russia);
            _warsawCentre = new SupplyCentre(_warsaw, Force.Russia);

            _serbiaCentre = new SupplyCentre(_serbia);
            _rumaniaCentre = new SupplyCentre(_rumania);
            _bulgariaCentre = new SupplyCentre(_bulgaria);

            _greeceCentre = new SupplyCentre(_greece);
            _tunisCentre = new SupplyCentre(_locations);

            _constantinopleCentre = new SupplyCentre(_constantinople, Force.Turkey);
            _ankaraCentre = new SupplyCentre(_ankara, Force.Turkey);
            _smyrnaCentre = new SupplyCentre(_smyrna, Force.Turkey);

            _norwayCentre = new SupplyCentre(_norway);
            _swedenCentre = new SupplyCentre(_sweden);
            _denmarkCentre = new SupplyCentre(_denmark);
        }

        private static void AttachNeighbors()
        {
            //attach neighbors (both ways) (todo don't attach seas to lands with 2 coasts ?)

            //top north seas
            _northAtlanticOcean.AddNeighbor(_norwegianSea, _clyde, _liverpool, _irishSea, _midAtlanticOcean);
            _norwegianSea.AddNeighbor(_barentsSea, _norway, _northSea, _edinburgh, _clyde, _northAtlanticOcean);
            _barentsSea.AddNeighbor(_saintPetersburg, _norway, _norwegianSea);

            //scandinavian lands
            _finland.AddNeighbor(_norway, _sweden, _gulfOfBothnia, _saintPetersburg);
            _norway.AddNeighbor(_norwegianSea, _northSea, _skagerrak, _sweden, _finland, _saintPetersburg, _barentsSea);
            _sweden.AddNeighbor(_norway, _skagerrak, _denmark, _balticSea, _gulfOfBothnia, _finland);

            //england
            _edinburgh.AddNeighbor(_clyde, _liverpool, _yorkshire, _northSea, _norwegianSea);
            _clyde.AddNeighbor(_northAtlanticOcean, _liverpool, _edinburgh, _norwegianSea);
            _liverpool.AddNeighbor(_clyde, _northAtlanticOcean, _irishSea, _yorkshire, _wales, _edinburgh);
            _wales.AddNeighbor(_liverpool, _irishSea, _englishChannel, _london, _yorkshire);
            _london.AddNeighbor(_yorkshire, _wales, _englishChannel, _northSea);
            _yorkshire.AddNeighbor(_edinburgh, _liverpool, _wales, _london, _northSea);

            //english seas
            _northSea.AddNeighbor(_norwegianSea, _edinburgh, _yorkshire, _london, _englishChannel, _belgium, _holland,
                _heligolandBight, _denmark, _skagerrak, _norway);
            _irishSea.AddNeighbor(_northAtlanticOcean, _midAtlanticOcean, _englishChannel, _wales, _liverpool);
            _englishChannel.AddNeighbor(_irishSea, _midAtlanticOcean, _brest, _picardy, _belgium, _northSea, _london, _wales);

            //baltics
            _heligolandBight.AddNeighbor(_northSea, _holland, _kiel, _denmark);
            _denmark.AddNeighbor(_northSea, _heligolandBight, _kiel, _balticSea, _sweden, _skagerrak);
            _skagerrak.AddNeighbor(_norway, _northSea, _denmark, _sweden);
            _balticSea.AddNeighbor(_sweden, _denmark, _kiel, _berlin, _prussia, _livonia, _gulfOfBothnia);
            _gulfOfBothnia.AddNeighbor(_sweden, _balticSea, _livonia, _saintPetersburg, _finland);

            //russia
            _saintPetersburg.AddNeighbor(_barentsSea, _norway, _finland, _gulfOfBothnia, _livonia, _moscow);
            _moscow.AddNeighbor(_saintPetersburg, _livonia, _warsaw, _ukraine, _sevastopol);
            _livonia.AddNeighbor(_gulfOfBothnia, _balticSea, _prussia, _warsaw, _moscow, _saintPetersburg);
            _prussia.AddNeighbor(_livonia, _balticSea, _berlin, _silesia, _warsaw);
            _warsaw.AddNeighbor(_prussia, _silesia, _galacia, _ukraine, _moscow, _livonia);
            _ukraine.AddNeighbor(_moscow, _warsaw, _galacia, _rumania, _sevastopol);
            _sevastopol.AddNeighbor(_moscow, _ukraine, _rumania, _blackSea, _armenia);

            //france
            _picardy.AddNeighbor(_belgium, _englishChannel, _brest, _paris, _burgundy);
            _brest.AddNeighbor(_picardy, _englishChannel, _midAtlanticOcean, _gascony, _paris);
            _paris.AddNeighbor(_picardy, _brest, _gascony, _burgundy);
            _gascony.AddNeighbor(_brest, _midAtlanticOcean, _spain, _marseilles, _burgundy, _paris);
            _marseilles.AddNeighbor(_burgundy, _gascony, _spain, _gulfOfLyons, _piedmont);
            _burgundy.AddNeighbor(_belgium, _picardy, _paris, _gascony, _marseilles, _munich, _ruhr);

            //west
            _midAtlanticOcean.AddNeighbor(_northAtlanticOcean, _irishSea, _englishChannel, _brest, _gascony, _spain, _portugal,
                _westernMediterraneanSea, _northAfrica);
            _spain.AddNeighbor(_midAtlanticOcean, _portugal, _westernMediterraneanSea, _gulfOfLyons, _marseilles, _gascony);
            _portugal.AddNeighbor(_midAtlanticOcean, _spain);

            //africa
            _northAfrica.AddNeighbor(_midAtlanticOcean, _westernMediterraneanSea, _locations);
            _locations.AddNeighbor(_northAfrica, _westernMediterraneanSea, _tyrrhenianSea, _ionianSea);

            //mediterranean
            _westernMediterraneanSea.AddNeighbor(_midAtlanticOcean, _northAfrica, _locations, _tyrrhenianSea, _gulfOfLyons,
                _spain);
            _gulfOfLyons.AddNeighbor(_marseilles, _spain, _westernMediterraneanSea, _tyrrhenianSea, _tuscany, _piedmont);
            _tyrrhenianSea.AddNeighbor(_gulfOfLyons, _westernMediterraneanSea, _locations, _ionianSea, _naples, _rome, _tuscany);
            _ionianSea.AddNeighbor(_easternMediterraneanSea, _aeganSea, _greece, _albania, _adriaticSea, _apulia, _naples,
                _tyrrhenianSea, _locations);
            _adriaticSea.AddNeighbor(_venice, _apulia, _ionianSea, _albania, _province);
            _aeganSea.AddNeighbor(_bulgaria, _greece, _ionianSea, _easternMediterraneanSea, _smyrna, _constantinople);
            _easternMediterraneanSea.AddNeighbor(_ionianSea, _aeganSea, _smyrna, _syria);

            //black sea
            _blackSea.AddNeighbor(_sevastopol, _rumania, _bulgaria, _constantinople, _ankara, _armenia);

            //belgium and hollland
            _belgium.AddNeighbor(_northSea, _englishChannel, _picardy, _burgundy, _ruhr, _holland);
            _holland.AddNeighbor(_northSea, _belgium, _ruhr, _kiel, _heligolandBight);

            //germany
            _kiel.AddNeighbor(_denmark, _heligolandBight, _holland, _ruhr, _munich, _berlin, _balticSea);
            _ruhr.AddNeighbor(_holland, _belgium, _burgundy, _munich, _kiel);
            _munich.AddNeighbor(_ruhr, _burgundy, _tyrolia, _bohemia, _silesia, _berlin, _kiel);
            _berlin.AddNeighbor(_balticSea, _kiel, _munich, _silesia, _prussia);
            _bohemia.AddNeighbor(_munich, _tyrolia, _location, _galacia, _silesia);
            _tyrolia.AddNeighbor(_munich, _piedmont, _venice, _province, _location, _bohemia);

            //italy
            _piedmont.AddNeighbor(_marseilles, _gulfOfLyons, _tuscany, _venice, _tyrolia);
            _tuscany.AddNeighbor(_piedmont, _gulfOfLyons, _tyrrhenianSea, _rome, _venice);
            _rome.AddNeighbor(_tuscany, _tyrrhenianSea, _naples, _apulia, _venice);
            _naples.AddNeighbor(_rome, _tyrrhenianSea, _ionianSea, _apulia);
            _apulia.AddNeighbor(_venice, _rome, _naples, _ionianSea, _adriaticSea);
            _venice.AddNeighbor(_piedmont, _tuscany, _rome, _apulia, _adriaticSea, _province, _tyrolia);

            //mid Europe
            _silesia.AddNeighbor(_prussia, _berlin, _munich, _bohemia, _galacia, _warsaw);
            _galacia.AddNeighbor(_warsaw, _silesia, _bohemia, _location, _budapest, _rumania, _ukraine);

            //austria
            _location.AddNeighbor(_bohemia, _tyrolia, _province, _budapest, _galacia);
            _budapest.AddNeighbor(_galacia, _location, _province, _serbia, _rumania);
            _province.AddNeighbor(_location, _tyrolia, _venice, _adriaticSea, _albania, _serbia, _budapest);

            //balkans
            _rumania.AddNeighbor(_ukraine, _galacia, _budapest, _serbia, _bulgaria, _blackSea, _sevastopol);
            _serbia.AddNeighbor(_budapest, _province, _albania, _greece, _bulgaria, _rumania);
            _bulgaria.AddNeighbor(_rumania, _serbia, _greece, _aeganSea, _constantinople, _blackSea);
            _albania.AddNeighbor(_province, _adriaticSea, _ionianSea, _greece, _serbia);
            _greece.AddNeighbor(_serbia, _albania, _ionianSea, _aeganSea, _bulgaria);

            //turkey
            _constantinople.AddNeighbor(_bulgaria, _aeganSea, _smyrna, _ankara, _blackSea);
            _ankara.AddNeighbor(_blackSea, _constantinople, _smyrna, _armenia);
            _smyrna.AddNeighbor(_constantinople, _aeganSea, _easternMediterraneanSea, _syria, _armenia, _ankara);
            _armenia.AddNeighbor(_sevastopol, _blackSea, _ankara, _smyrna, _syria);
            _syria.AddNeighbor(_armenia, _smyrna, _easternMediterraneanSea);

            //attach coastlines neighbors
            _spainNorthCoast.AddNeighbor(_portugal, _midAtlanticOcean, _gascony);
            _spainSouthCoast.AddNeighbor(_midAtlanticOcean, _portugal, _westernMediterraneanSea, _gulfOfLyons, _marseilles);
            _saintPetersburgNorthCoast.AddNeighbor(_barentsSea, _norway);
            _saintPetersburgSouthCoast.AddNeighbor(_finland, _livonia, _gulfOfBothnia);
            _bulgariaEastCoast.AddNeighbor(_rumania, _blackSea, _constantinople);
            _bulgariaSouthCoast.AddNeighbor(_greece, _aeganSea, _constantinople);
        }

        private static void AttachCoastlines()
        {
            _saintPetersburg.CoastLines.Add(_saintPetersburgNorthCoast);
            _saintPetersburg.CoastLines.Add(_saintPetersburgSouthCoast);
            _spain.CoastLines.Add(_spainNorthCoast);
            _spain.CoastLines.Add(_spainNorthCoast);
            _bulgaria.CoastLines.Add(_bulgariaEastCoast);
            _bulgaria.CoastLines.Add(_bulgariaSouthCoast);
        }

        private static void AttachProvinces(Board.Board europeBoard)
        {
            europeBoard.Locations = new HashSet<ILocation>()
            {
                _northAfrica,
                _locations,
                _bohemia,
                _budapest,
                _galacia,
                _province,
                _tyrolia,
                _location,
                _bulgaria,
                _greece,
                _rumania,
                _serbia,
                _albania,
                _clyde,
                _edinburgh,
                _liverpool,
                _london,
                _wales,
                _yorkshire,
                _brest,
                _burgundy,
                _gascony,
                _marseilles,
                _paris,
                _picardy,
                _berlin,
                _kiel,
                _munich,
                _prussia,
                _ruhr,
                _silesia,
                _spain,
                _portugal,
                _apulia,
                _naples,
                _piedmont,
                _rome,
                _tuscany,
                _venice,
                _belgium,
                _holland,
                _finland,
                _livonia,
                _moscow,
                _sevastopol,
                _saintPetersburg,
                _ukraine,
                _warsaw,
                _denmark,
                _norway,
                _sweden,
                _ankara,
                _armenia,
                _constantinople,
                _smyrna,
                _syria,
                _barentsSea,
                _englishChannel,
                _heligolandBight,
                _irishSea,
                _midAtlanticOcean,
                _northAtlanticOcean,
                _northSea,
                _norwegianSea,
                _skagerrak,
                _balticSea,
                _gulfOfBothnia,
                _adriaticSea,
                _blackSea,
                _easternMediterraneanSea,
                _aeganSea,
                _gulfOfLyons,
                _ionianSea,
                _tyrrhenianSea,
                _westernMediterraneanSea
            };
        }

        private static void SetCoastlines()
        {
            //coastlines //todo should we add them to the board ?
            _saintPetersburgNorthCoast = new CoastLine("Saint Petersburg North Coast", "STP NC", "Russia");
            _saintPetersburgSouthCoast = new CoastLine("Saint Petersburg South Coast", "STP SC", "Russia");
            _spainNorthCoast = new CoastLine("Spain North Coast", "SPA NC", "Iberia");
            _spainSouthCoast = new CoastLine("Spain South Coast", "SPA SC", "Iberia");
            _bulgariaEastCoast = new CoastLine("Bulgaria East Coast", "BUL EC", "Balkans");
            _bulgariaSouthCoast = new CoastLine("Bulgaria South Coast", "BUL SC", "Balkans");
        }

        private static void SetProvinces()
        {
            //create province nodes. Data from http://en.wikibooks.org/wiki/Diplomacy/Geography + a few missing.
            _northAfrica = new Province("North Africa", "NAF", "Africa", SpaceType.LandWithOneCoastline);
            _locations = new Province("Tunis", "TUN", "Africa", SpaceType.LandWithOneCoastline);
            _bohemia = new Province("Bohemia", "BOH", "Austria", SpaceType.Land);
            _budapest = new Province("Budapest", "BUD", "Austria", SpaceType.Land);
            _galacia = new Province("Galacia", "GAL", "Austria", SpaceType.Land);
            _province = new Province("Trieste", "TRI", "Austria", SpaceType.LandWithOneCoastline);
            _tyrolia = new Province("Tyrolia", "TYR", "Austria", SpaceType.Land);
            _location = new Province("Vienna", "VIE", "Austria", SpaceType.Land);
            _bulgaria = new Province("Bulgaria", "BUL", "Balkans", SpaceType.LandWithTwoCoastlines);
            _greece = new Province("Greece", "GRE", "Balkans", SpaceType.LandWithOneCoastline);
            _rumania = new Province("Rumania", "RUM", "Balkans", SpaceType.LandWithOneCoastline);
            _serbia = new Province("Serbia", "SER", "Balkans", SpaceType.Land);
            _albania = new Province("Albania", "ALB", "Balkans", SpaceType.LandWithOneCoastline);
            _clyde = new Province("Clyde", "CLY", "England", SpaceType.LandWithOneCoastline);
            _edinburgh = new Province("Edinburgh", "EDI", "England", SpaceType.LandWithOneCoastline);
            _liverpool = new Province("Liverpool", "LVP", "England", SpaceType.LandWithOneCoastline);
            _london = new Province("London", "LON", "England", SpaceType.LandWithOneCoastline);
            _wales = new Province("Wales", "WAL", "England", SpaceType.LandWithOneCoastline);
            _yorkshire = new Province("Yorkshire", "YOR", "England", SpaceType.LandWithOneCoastline);
            _brest = new Province("Brest", "BRE", "France", SpaceType.LandWithOneCoastline);
            _burgundy = new Province("Burgundy", "BUR", "France", SpaceType.Land);
            _gascony = new Province("Gascony", "GAS", "France", SpaceType.LandWithOneCoastline);
            _marseilles = new Province("Marseilles", "MAR", "France", SpaceType.LandWithOneCoastline);
            _paris = new Province("Paris", "PAR", "France", SpaceType.Land);
            _picardy = new Province("Picardy", "PIC", "France", SpaceType.LandWithOneCoastline);
            _berlin = new Province("Berlin", "BER", "Germany", SpaceType.LandWithOneCoastline);
            _kiel = new Province("Kiel", "KIE", "Germany", SpaceType.LandWithOneCoastline);
            _munich = new Province("Munich", "MUN", "Germany", SpaceType.Land);
            _prussia = new Province("Prussia", "PRU", "Germany", SpaceType.LandWithOneCoastline);
            _ruhr = new Province("Ruhr", "RUH", "Germany", SpaceType.Land);
            _silesia = new Province("Silesia", "SIL", "Germany", SpaceType.Land);
            _spain = new Province("Spain", "SPA", "Iberia", SpaceType.LandWithTwoCoastlines);
            _portugal = new Province("Portugal", "POR", "Iberia", SpaceType.LandWithOneCoastline);
            _apulia = new Province("Apulia", "APU", "Italy", SpaceType.LandWithOneCoastline);
            _naples = new Province("Naples", "NAP", "Italy", SpaceType.LandWithOneCoastline);
            _piedmont = new Province("Piedmont", "PIE", "Italy", SpaceType.LandWithOneCoastline);
            _rome = new Province("Rome", "ROM", "Italy", SpaceType.LandWithOneCoastline);
            _tuscany = new Province("Tuscany", "TUS", "Italy", SpaceType.LandWithOneCoastline);
            _venice = new Province("Venice", "VEN", "Italy", SpaceType.LandWithOneCoastline);
            _belgium = new Province("Belgium", "BEL", "Low Countries", SpaceType.LandWithOneCoastline);
            _holland = new Province("Holland", "HOL", "Low Countries", SpaceType.LandWithOneCoastline);
            _finland = new Province("Finland", "FIN", "Russia", SpaceType.LandWithOneCoastline);
            _livonia = new Province("Livonia", "LVN", "Russia", SpaceType.LandWithOneCoastline);
            _moscow = new Province("Moscow", "MOS", "Russia", SpaceType.Land);
            _sevastopol = new Province("Sevastopol", "SEV", "Russia", SpaceType.LandWithOneCoastline);
            _saintPetersburg = new Province("Saint Petersburg", "STP", "Russia", SpaceType.LandWithTwoCoastlines);
            _ukraine = new Province("Ukraine", "UKR", "Russia", SpaceType.Land);
            _warsaw = new Province("Warsaw", "WAR", "Russia", SpaceType.Land);
            _denmark = new Province("Denmark", "DEN", "Scandinavia", SpaceType.LandWithOneCoastline);
            _norway = new Province("Norway", "NWY", "Scandinavia", SpaceType.LandWithOneCoastline);
            _sweden = new Province("Sweden", "SWE", "Scandinavia", SpaceType.LandWithOneCoastline);
            _ankara = new Province("Ankara", "ANK", "Turkey", SpaceType.LandWithOneCoastline);
            _armenia = new Province("Armenia", "ARM", "Turkey", SpaceType.LandWithOneCoastline);
            _constantinople = new Province("Constantinople", "CON", "Turkey", SpaceType.LandWithOneCoastline);
            _smyrna = new Province("Smyrna", "SMY", "Turkey", SpaceType.LandWithOneCoastline);
            _syria = new Province("Syria", "SYR", "Turkey", SpaceType.LandWithOneCoastline);
            _barentsSea = new Province("Barents Sea", "BAR", "Atlantic", SpaceType.Sea);
            _englishChannel = new Province("English Channel", "ENC", "Atlantic", SpaceType.Sea);
            _heligolandBight = new Province("Heligoland Bight", "HEL", "Atlantic", SpaceType.Sea);
            _irishSea = new Province("Irish Sea", "IRS", "Atlantic", SpaceType.Sea);
            _midAtlanticOcean = new Province("Mid-Atlantic Ocean", "MAO", "Atlantic", SpaceType.Sea);
            _northAtlanticOcean = new Province("North Atlantic Ocean", "NAO", "Atlantic", SpaceType.Sea);
            _northSea = new Province("North Sea", "NTH", "Atlantic", SpaceType.Sea);
            _norwegianSea = new Province("Norwegian Sea", "NWS", "Atlantic", SpaceType.Sea);
            _skagerrak = new Province("Skagerrak", "SKA", "Atlantic", SpaceType.Sea);
            _balticSea = new Province("Baltic Sea", "BAL", "Baltic", SpaceType.Sea);
            _gulfOfBothnia = new Province("Gulf of Bothnia", "GOB", "Baltic", SpaceType.Sea);
            _adriaticSea = new Province("Adriatic Sea", "ADS", "Mediterranean", SpaceType.Sea);
            _blackSea = new Province("Black Sea", "BLA", "Mediterranean", SpaceType.Sea);
            _easternMediterraneanSea = new Province("Eastern Mediterranean Sea", "EMS", "Mediterranean", SpaceType.Sea);
            _aeganSea = new Province("Aegan Sea", "AEG", "Mediterranean", SpaceType.Sea);
            _gulfOfLyons = new Province("Gulf of Lyons", "GOL", "Mediterranean", SpaceType.Sea);
            _ionianSea = new Province("Ionian Sea", "IOS", "Mediterranean", SpaceType.Sea);
            _tyrrhenianSea = new Province("Tyrrhenian Sea", "TYS", "Mediterranean", SpaceType.Sea);
            _westernMediterraneanSea = new Province("Western Mediterranean Sea", "WMS", "Mediterranean", SpaceType.Sea);

            //impassable areas
            //Caspian Sea CAS or CSS Impassable areas 
            //Iceland ICE or ICL or ILN Impassable areas 
            //Siberia SIB Impassable areas 
            //Switzerland SWI Impassable areas 
        }
    }
}