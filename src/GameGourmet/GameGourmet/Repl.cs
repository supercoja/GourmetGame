using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace GameGourmet
{
    internal class Repl
    {
        readonly TextReader input;
        readonly TextWriter output;
        readonly CommandFactory factory;

        readonly Regex verbRegex = new Regex(@"^(?<verb>\w+)");
        readonly Regex fieldsRegex = new Regex(@"(?<field>\w+)=(?<value>[^;]+)");

        internal Repl(TextReader input, TextWriter output, GameStore store)
        {
            this.input = input;
            this.output = output;
            this.factory = new CommandFactory(store);
            Log.MessageLogged += ConsoleLogger;
        }

        internal void Run()
        {
            bool quitSeen = false;
            var cmdInit = factory.Init();
            output.Write(cmdInit.Notify());
            
            while (!quitSeen)
            {
                ICommand cmd = NextCommand();

                switch(cmd.Verb)
                {
                    case Commands.Start:
                        cmd.Execute();
                        break;
                    case Commands.Quit:
                        quitSeen = true;
                        break;
                    default:
                        cmd.Execute();
                        break;
                }
            }
        }

        private void Play(Plate plate)
        {
                output.WriteLine(plate);
        }

        private ICommand NextCommand()
        {
            Prompt();
            return TryMapToCommand(Read());
        }

        private ICommand TryMapToCommand(string line)
        {
            string verb;
            IReadOnlyDictionary<string, string> args;

            if (ParseLine(line, out verb, out args))
            {
                switch (verb)
                {
                    case Commands.Start:
                        return factory.Start();
                    case Commands.Load:
                        return factory.Load();
                    default:
                        return factory.UnknownCommand(verb);
                }
            }

            return factory.SyntaxError();
        }

        private bool ParseLine(string line, out string verb, out IReadOnlyDictionary<string, string> args)
        {
            Log.Verbose("input: {0}", line);

            bool parsedVerb = false;
            Dictionary<string, string> fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            Match verbMatch = verbRegex.Match(line.TrimStart());
            if (verbMatch.Success)
            {
                verb = verbMatch.Value;
                parsedVerb = true;
                foreach (Match m in fieldsRegex.Matches(line))
                {
                    fields[m.Groups["field"].Value] = m.Groups["value"].Value;
                }
            }
            else
            {
                verb = Commands.Error;
                fields["message"] = string.Format("Unable to parse verb. ({0})", line);
            }

            args = fields;
            return parsedVerb;
        }

        private string Read()
        {
            return input.ReadLine();
        }

        private void PromptFirst()
        {
            output.Write("Pense em um prato que gosta");
            output.Flush();
        }
        private void Prompt()
        {
            output.Write("> ");
            output.Flush();
        }

        private void ConsoleLogger(object sender, LogMessageEventArgs e)
        {
            switch (e.Level)
            {
                case LogLevel.Verbose:
                    // do nothing
                    break;
                case LogLevel.Info:
                case LogLevel.Warning:
                case LogLevel.Error:
                    this.output.WriteLine(e.Message);
                    this.output.Flush();
                    break;
            }
        }
    }
}
