﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeaterScript
{
    public class Command
    {
        public string Name { get; }
        public Type[] Types { get; }
        public bool HasFunction { get; }
        public bool HasMovement { get; }
        public ushort ID { get; }
        public List<object> Parameters { get; set; }


        public Command(string name, ushort id, bool hasFunction, bool hasMovement, params Type[] types)
        {
            Name = name;
            Types = types;
            ID = id;
            Parameters = new List<object>();
            HasFunction = hasFunction;
            HasMovement = hasMovement;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{this.Name} ");

            for (int i = 0; i < Parameters.Count; i++)
            {
                result.Append(Parameters[i]);
                if (i != Parameters.Count - 1) result.Append(", ");
            }

            return result.ToString();
        }
    }
}
