using System.Collections.Generic;

namespace HackAssembler.Preprocessing
{
    public class VariableSymbolPreprocessor : IPreprocessor
    {
        public void Process(ref string[] source)
        {
            int availableAddress = 16;
            var variables = new Dictionary<string, string>();

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].StartsWith('@'))
                {
                    if (!int.TryParse(source[i].Substring(1), out int address) && !variables.ContainsKey(source[i]))
                    {
                        variables[source[i]] = $"@{availableAddress}";
                        availableAddress++;
                    }
                }
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (variables.ContainsKey(source[i]))
                {
                    source[i] = variables[source[i]];
                }
            }
        }
    }
}
