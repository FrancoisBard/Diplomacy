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
        private HashSet<BoardNode> Nodes { get; set; }


    }

    class BoardNode
    {
        private string Name { get; set; }

        private Unit Unit { get; set; } //also in coastLine.

        private Force Owner { get; set; }

        private SpaceType SpaceType { get; set; }

        private SupplyCentre SupplyCentre { get; set; }

        private HashSet<BoardNode> Neighbors { get; set; }

        private HashSet<CoastLine> CoastLines { get; set; }
    }

    class CoastLine
    {
        private string Name { get; set; }

        private Unit Unit { get; set; }
    }

    enum Unit
    {
        Army,
        Fleet
    }

    class SupplyCentre
    {
        private Force OriginalOwner { get; set; } //needed ?

        private SpaceType SpaceType { get; set; }
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
