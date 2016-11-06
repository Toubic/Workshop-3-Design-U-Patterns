using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            getShowDealCard(a_deck, a_player);

            getShowDealCard(a_deck, a_dealer);

            getShowDealCard(a_deck, a_player);

            getShowDealCard(a_deck, a_dealer);

            return true;
        }

        public void getShowDealCard(Deck a_deck, Player a_player)
        {
            Card c;

            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);
        }
    }
}
