﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_winRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinRule();
        }

        public bool NewGame(Player a_player)
        {

            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }

            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                getCardAndDealToPlayer(a_player);

                return true;
            }
            return false;
        }
        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                foreach (Card c in GetHand())
                {
                    c.Show(true);
                }
                while (m_hitRule.DoHit(this)) {
                    

                    m_hitRule.DoHit(this);
                    getCardAndDealToPlayer(this);
                    
                }
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {

            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return m_winRule.whoWins(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
        private Card getCardAndDealToPlayer(Player a_player)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);

            return c;
        }
    }
}
