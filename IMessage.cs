using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloFunction
{
    public interface IMessage
    {
        string CreateMessage(string name, string country);
    }
}
