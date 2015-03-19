using System.Collections.Generic;

namespace Diplomacy.Board
{
    class Board
    {
        public HashSet<ILocation> Locations { get; set; }

        public HashSet<SupplyCentre> SupplyCentres { get; set; }

        public HashSet<Unit> Units { get; set; }
    }
}
