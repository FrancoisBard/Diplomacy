using System.Collections.Generic;

namespace Diplomacy.Board
{
    interface ILocation
    {
        string Name { get; set; }

        string Abbreviation { get; set; }

        string Region { get; set; }

        SpaceType SpaceType { get; set; }

        HashSet<ILocation> Neighbors { get; }

        Unit Unit { get; set; }
    }
}