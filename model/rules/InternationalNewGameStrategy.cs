using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            getShowDealCard(a_deck, a_player, true);

            getShowDealCard(a_deck, a_dealer, true);

            getShowDealCard(a_deck, a_player, true);

            return true;
        }
        public void getShowDealCard(Deck a_deck, Player a_player, bool show)
        {
            Card c;

            c = a_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);
        }
    }
}
