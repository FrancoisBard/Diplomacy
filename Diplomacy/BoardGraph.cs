using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy
{
    class BoardGraph
    {
        public HashSet<Province> Nodes { get; set; }


    }

    class Province : ILocation
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Region { get; set; }

        public SpaceType SpaceType { get; set; }

        public HashSet<CoastLine> CoastLines { get; set; }

        public HashSet<ILocation> Neighbors { get; private set; }

        public SupplyCentre SupplyCentre { get; set; }

        public Unit Unit { get; set; } //also in coastLine.        

        public Province(string name, string abbreviation, string region, SpaceType spaceType)
        {
            Name = name;
            Abbreviation = abbreviation;
            Region = region;
            SpaceType = spaceType;
            CoastLines = new HashSet<CoastLine>();
            Neighbors = new HashSet<ILocation>();
        }

        public void AddNeighbor(params ILocation[] locations)
        {
            foreach (var location in locations)
            {
                Neighbors.Add(location);
                location.Neighbors.Add(this);
            }
        }
    }

    class CoastLine : ILocation
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Region { get; set; }

        public SpaceType SpaceType { get; set; } //always coast

        public HashSet<ILocation> Neighbors { get; private set; }

        public Unit Unit { get; set; }

        public CoastLine(string name, string abbreviation, string region)
        {
            Name = name;
            Abbreviation = abbreviation;
            Region = region;
            SpaceType = SpaceType.Coastline;
            Neighbors = new HashSet<ILocation>();
        }
    }

    interface ILocation
    {
        string Name { get; set; }

        string Abbreviation { get; set; }

        string Region { get; set; }

        SpaceType SpaceType { get; set; }

        HashSet<ILocation> Neighbors { get; }

        Unit Unit { get; set; }
    }

    class Unit
    {
        public UnitType UnitType { get; set; }

        public Force Owner { get; set; }

        public ILocation Location { get; set; }

        public void MoveTo(ILocation location)
        {
            //leave original location
            Location.Unit = null;

            //set new location
            Location = location;
            Location.Unit = this;
        }

        /// <summary>
        /// Determines whether this unit can move to the specified location.
        /// This method test if the location may be reachable next turn by normal move (not convoy)
        /// We don't check whether the location is already occupied, for instance, because this need to be solved based on other moves.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public bool CanMoveTo(ILocation location)
        {
            //check if it's a neighbor
            if (!Location.Neighbors.Contains(location))
            {
                return false;
            }

            //compare the destination space type to the unit type
            switch (location.SpaceType)
            {
                case SpaceType.Sea:
                    //ok if the unit is a fleet
                    return UnitType == UnitType.Fleet;
                case SpaceType.Land:
                    //ok if the unit is an army
                    return UnitType == UnitType.Army;
                case SpaceType.LandWithOneCoastline:
                    //ok for both fleets or armies
                    return true;
                case SpaceType.LandWithTwoCoastlines:
                    //ok if the unit is an army (a fleet has to choose which coasline to go to)
                    return UnitType == UnitType.Army;
                case SpaceType.Hybrid:
                    //ok for both fleets or armies
                    return true;
                case SpaceType.Coastline:
                    //ok if the unit is a fleet (an army has to choose the province)
                    return UnitType == UnitType.Fleet;
            }

            //unreachable
            return false;
        }
    }

    enum UnitType
    {
        Army,
        Fleet
    }

    class SupplyCentre
    {
        //public SpaceType SpaceType { get; set; } //needed ?

        public Force Owner { get; set; }
    }

    enum Force
    {
        Russia,
        France,
        England,
        Italy,
        AustriaHungary,
        Germany,
        Turkey
    }

    enum SpaceType
    {
        Land,
        LandWithOneCoastline,
        LandWithTwoCoastlines,
        Hybrid, //a land you can go through
        Sea,
        Coastline //no need for hybrid i think
    }

}
