using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.observer;

namespace BlackJack.subject
{
    public class NewCard
    {
        private List<observer.IObserver> observers = new List<observer.IObserver>();

        public void addObserver(observer.IObserver observer){
            observers.Add(observer);
        }

        public void removeObserver(observer.IObserver observer)
        {
            observers.Remove(observer);
        }

        public void notifyAll()
        {
            foreach (IObserver observer in observers)
            {
                observer.notifyNewCard();
            }

        }

    }
}
