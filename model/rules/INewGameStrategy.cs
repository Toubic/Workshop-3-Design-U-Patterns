﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface INewGameStrategy
    {
        bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player);

        void getShowDealCard(Deck a_deck, Player a_player, bool show);
    }
}
