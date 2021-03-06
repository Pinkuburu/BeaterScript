﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaterScript
{
    public class ScriptLexer
    {
        readonly CommandsListHandler cmds;

        public ScriptLexer(Dictionary<int, Script> scripts, Dictionary<int, Script> functions, Dictionary<int, List<Movement>> movements, string script, string game)
        {
            cmds = new CommandsListHandler(game);
            WriteScript(scripts, functions, movements, script, game);
        }

        public void WriteScript(Dictionary<int, Script> scripts, Dictionary<int, Script> functions, Dictionary<int, List<Movement>> movements, string script, string game)
        {
            using (System.IO.StreamWriter o = new System.IO.StreamWriter(script))
            {
                // Write the inclusion stuff.
                Console.Write("Writing header... ");
                o.WriteLine($".include \"{game}.s\"{System.Environment.NewLine}");

                // Write the header.
                o.WriteLine("Header:");
                for (int i = 0; i < scripts.Count; i++)
                    o.WriteLine($"\tscript Script{i}");
                o.WriteLine($"  EndHeader{System.Environment.NewLine}");

                Console.WriteLine("Writing functions... ");
                // Start writing the command section.
                for (int i = 0; i < functions.Count; i++)
                {
                    Console.WriteLine($"Writing function {i}...");
                    o.WriteLine($"FunctionLabel Function{i}");
                    for (int j = 0; j < functions[functions.ElementAt(i).Key].Commands.Count; j++)
                        o.WriteLine($"\t{functions[functions.ElementAt(i).Key].Commands[j]}");
                    o.WriteLine($"{System.Environment.NewLine}");
                }

                Console.WriteLine("Writing scripts... ");
                for (int i = 0; i < scripts.Count; i++)
                {
                    Console.WriteLine($"Writing script {i}...");
                    o.WriteLine($"Script{i}:");
                    for (int j = 0; j < scripts[scripts.ElementAt(i).Key].Commands.Count; j++)
                        o.WriteLine($"\t{scripts[scripts.ElementAt(i).Key].Commands[j]}");
                    o.WriteLine($"{System.Environment.NewLine}");
                }

                Console.WriteLine("Writing movements... ");
                // Finish off with movements.
                for (int i = 0; i < movements.Count; i++)
                {
                    Console.WriteLine($"Writing movement {i}...");
                    o.WriteLine($"MovementLabel Movement{i}");
                    for (int j = 0; j < movements[movements.ElementAt(i).Key].Count; j++)
                        o.WriteLine($"\t{movements[movements.ElementAt(i).Key][j]}");
                    o.WriteLine($"{System.Environment.NewLine}");
                }

                Console.WriteLine($"Script \"{script}\" has been compiled successfully.");
            }
        }

    }
}