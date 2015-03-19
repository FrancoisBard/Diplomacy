using System.Collections.Generic;

namespace Diplomacy.Board
{
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
}