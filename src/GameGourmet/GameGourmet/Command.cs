using System.Collections.Generic;

namespace GameGourmet
{
    internal interface ICommand
    {
        string Verb { get; }
        BSTNode<Plate> Execute();
        string Notify();
    }

    internal abstract class Command : ICommand
    {
        public string Verb { get; }

        protected GameStore Store { get; }

        protected Command(string verb,  GameStore store)
        {
            Verb = verb;
            Store = store;
        }

        public abstract BSTNode<Plate> Execute();
        public abstract string Notify();
    }

    internal struct Commands
    {
        public const string Init = "start";
        public const string Start = "start";
        public const string Quit = "quit";
        public const string Error = "error";
        public const string Load = "load";
    }
}
