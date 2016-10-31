﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        private subject.NewCard newCard = new subject.NewCard();

        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                foreach (observer.IObserver obs in a_game.getPlayers())
                {
                    newCard.removeObserver(obs);
                }
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch(a_view.GetInput()){
                case 'p':
                    foreach(observer.IObserver obs in a_game.getPlayers()){
                        newCard.addObserver(obs);
                    }
                    a_game.NewGame();
                    break;
                case 'h':
                    a_game.Hit();
                    newCard.notifyAll();
                    break;
                case 's':
                    a_game.Stand();
                    break;
                case 'q':
                    return false;
                default:
                    return true;
            }

            return true;
        }
    }
}
