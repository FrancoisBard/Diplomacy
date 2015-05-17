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

        public void NextState()
        {
            NextPhase();
            if (phase == Phase.Move)
            {
                NextSeason();
                if (season == Season.Spring)
                {
                    NextYear();
                }
            }
        }

        private void NextSeason()
        {
            switch (season)
            {
                case Season.Spring:
                    season = Season.Fall;
                    break;

                case Season.Fall:
                    season = Season.Spring;
                    break;

                default:
                    throw new Exception();
            }
        }

        private void NextPhase()
        {
            switch (phase)
            {
                case Phase.Move:
                    phase = Phase.Retreat;
                    break;

                case Phase.Retreat:
                    phase = (season == Season.Fall) ? Phase.Supply : Phase.Move;
                    break;

                case Phase.Supply:
                    phase = Phase.Move;
                    break;

                default:
                    throw new Exception();
            }
        }

        private void NextYear()
        {
            year++;
        }
    }

    //todo add summer and winter ?
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
