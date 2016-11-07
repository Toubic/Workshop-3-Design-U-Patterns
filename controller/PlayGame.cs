using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        private const char play = 'p';
        private const char hit = 'h';
        private const char stand = 's';
        private const char quit = 'q';

        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                foreach (model.Player obs in a_game.getPlayers())
                {
                    obs.removeObserver(this);
                }
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch(a_view.GetInput()){
                case play:
                    foreach (model.Player obs in a_game.getPlayers())
                    {
                        obs.addObserver(this);
                    }
                    a_game.NewGame();
                    break;
                case hit:
                    a_game.Hit();
                    break;
                case stand:
                    a_game.Stand();
                    break;
                case quit:
                    return false;
                default:
                    return true;
            }

            return true;
        }
        public void notifyNewCard()
        {
            Thread.Sleep(500);
        }
    }
}
