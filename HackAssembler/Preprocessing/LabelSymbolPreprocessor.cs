using System.Collections.Generic;

namespace HackAssembler.Preprocessing
{
    public class LabelSymbolPreprocessor : IPreprocessor
    {
        public void Process(ref string[] source)
        {
            var labels = new Dictionary<string, string>();

            int instructionAddress = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == string.Empty)
                {
                    continue;
                }

                if (source[i].StartsWith('(') && source[i].EndsWith(')'))
                {
                    // The instruction address will be the line of the label minus the number of previous label declarations in the file (those lines will be removed).
                    labels[$"@{source[i].Substring(1, source[i].Length - 2)}"] = $"@{instructionAddress - labels.Count}";
                    source[i] = string.Empty;
                }

                instructionAddress++;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (labels.ContainsKey(source[i]))
                {
                    source[i] = labels[source[i]];
                }
            }
        }
    }
}
