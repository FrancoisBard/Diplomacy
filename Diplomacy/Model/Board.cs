using System.Collections.Generic;

namespace Diplomacy.Board
{
    public class Board
    {
        public ISet<ILocation> Locations { get; set; }

        public ISet<SupplyCentre> SupplyCentres { get; set; }

        public ISet<Unit> Units { get; set; }
    }
}
