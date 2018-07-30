using System;

namespace HackAssembler.Preprocessing
{
    public class EmptyLineRemover : IPreprocessor
    {
        public void Process(ref string[] source)
        {
            MoveEmptyStringsBack(source);

            Array.Resize(ref source, GetFilledLength(source));
        }

        private static void MoveEmptyStringsBack(string[] source)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0, j = 1; j < source.Length; i++, j++)
                {
                    if (source[i].Length == 0 && source[j].Length > 0)
                    {
                        source[i] = source[j];
                        source[j] = string.Empty;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        private static int GetFilledLength(string[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Length == 0)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
