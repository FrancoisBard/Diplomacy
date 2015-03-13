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

        public HashSet<ILocation> Neighbors { get; set; }

        public SupplyCentre SupplyCentre { get; set; }

        public Unit Unit { get; set; } //also in coastLine.        
        
        public Province(string name, string abbreviation, string region, SpaceType spaceType)
        {
            Name = name;
            Abbreviation = abbreviation;
            Region = region;
            SpaceType = spaceType;
        }
    }

    class CoastLine : ILocation
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Region { get; set; }

        public SpaceType SpaceType { get; set; } //always coastLine

        public HashSet<ILocation> Neighbors { get; set; }

        public Unit Unit { get; set; }
    }

    interface ILocation
    {
        string Name { get; set; }

        string Abbreviation { get; set; }

        string Region { get; set; }

        SpaceType SpaceType { get; set; }

        HashSet<ILocation> Neighbors { get; set; }

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
                case SpaceType.Coast:
                    //ok if the unit is an army
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
        Sea,
        Coast
    }

}
