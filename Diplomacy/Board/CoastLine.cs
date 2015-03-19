using System.Collections.Generic;

namespace Diplomacy.Board
{
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

        public void AddNeighbor(params ILocation[] locations)
        {
            foreach (var location in locations)
            {
                Neighbors.Add(location);
                location.Neighbors.Add(this);
            }
        }
    }
}