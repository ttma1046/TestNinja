using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.v2.Mocking
{
    class FakeDeserializer : IDeserializer
    {
        public T DeserializeObject<T>(string input)
        {
            return default(T);
        }
    }
}
