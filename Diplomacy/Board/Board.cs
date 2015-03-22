using System.Collections.Generic;

namespace Diplomacy.Board
{
    public class Board
    {
        public HashSet<ILocation> Locations { get; set; }

        public HashSet<SupplyCentre> SupplyCentres { get; set; }

        public HashSet<Unit> Units { get; set; }
    }
}
