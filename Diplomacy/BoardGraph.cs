using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy
{
    class BoardGraph
    {
        public HashSet<BoardNode> Nodes { get; set; }


    }

    class BoardNode
    {
        public string Name { get; set; }

        public Unit Unit { get; set; } //also in coastLine.

        public Force Owner { get; set; }

        public SpaceType SpaceType { get; set; }

        public SupplyCentre SupplyCentre { get; set; }

        public HashSet<BoardNode> NeighborLands { get; set; } //also in coastLine. //careful both ways ! //todo only land ?

        public HashSet<CoastLine> CoastLines { get; set; }
    }

    class CoastLine
    {
        public string Name { get; set; }

        public Unit Unit { get; set; }

        public HashSet<BoardNode> Seas { get; set; }
    }

    class Unit
    {
        public UnitType UnitType { get; set; }

        public Force Owner { get; set; }
    }

    enum UnitType
    {
        Army,
        Fleet
    }

    class SupplyCentre
    {
        public Force OriginalOwner { get; set; } //needed ?

        public SpaceType SpaceType { get; set; }
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
        //Coast //just means that it has at least one Sea type neighbor //todo get rid of it
    }

}
