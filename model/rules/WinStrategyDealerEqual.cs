using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class WinStrategyDealerEqual : IWinStrategy
    {

        public bool whoWins(model.Player a_dealer, model.Player a_player)
        {
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
