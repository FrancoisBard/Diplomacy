using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy.GamePhases
{
    class GamePhases
    {
        int year = 1901;
        Season season = Season.Spring;
        Phase phase = Phase.Move;

    }

    enum Season
    {
        Spring,
        Fall
    }

    enum Phase
    {
        Move,
        Retreat,
        Supply
    }
}
