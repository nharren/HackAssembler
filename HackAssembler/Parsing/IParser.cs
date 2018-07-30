using HackAssembler.Instructions;
using System.Collections.Generic;

namespace HackAssembler.Parsing
{
    public interface IParser
    {
        Result<List<Instruction>> Parse(string[] source);
    }
}
