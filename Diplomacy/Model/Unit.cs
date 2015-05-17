using System;

namespace Diplomacy.Board
{
    public class Unit
    {
        public UnitType UnitType { get; set; }

        public Force Owner { get; set; }

        public ILocation Location { get; set; }

        public Unit(UnitType unitType, Force owner, ILocation location)
        {
            UnitType = unitType;
            Owner = owner;
            Location = location;

            Location.Unit = this;
        }

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
                case SpaceType.Coastline:
                    //ok if the unit is a fleet (an army has to choose the province)
                    return UnitType == UnitType.Fleet;
                default:
                    throw new Exception();
            }
        }
    }
}