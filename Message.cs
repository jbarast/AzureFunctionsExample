﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloFunction
{
    internal class Message : IMessage
    {       

        public IBaseMessage BaseMessage { get; }

        public Message(IBaseMessage baseMessage)
        {
            BaseMessage = baseMessage;
        }

        public string CreateMessage(string name, string country)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(country)) return "No hay nada que mostrar. Llamada correcta.";
            if (string.IsNullOrWhiteSpace(country)) return $"Hello {name}";
            if (string.IsNullOrWhiteSpace(country)) return $"Welcome to {country}";
            return $"Hello {name}, Welcome to {country}";
        }
    }
}
