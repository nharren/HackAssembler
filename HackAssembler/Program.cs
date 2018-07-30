using HackAssembler.Instructions;
using HackAssembler.Parsing;
using HackAssembler.Parsing.InstructionParsers;
using HackAssembler.Preprocessing;
using HackAssembler.Translation;
using HackAssembler.Translation.InstructionTranslators;
using System;
using System.Collections.Generic;
using System.IO;

namespace HackAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new Exception("No source file provided.");
            }

            IPreprocessor whitespaceRemover = new WhitespaceRemover();
            IPreprocessor commentRemover = new CommentRemover();
            IPreprocessor labelSymbolPreprocessor = new LabelSymbolPreprocessor();
            IPreprocessor emptyLineRemover = new EmptyLineRemover();
            IPreprocessor predefinedSymbolPreprocessor = new PredefinedSymbolPreprocessor();
            IPreprocessor variableSymbolPreprocessor = new VariableSymbolPreprocessor();

            IEnumerable<IPreprocessor> preprocessors = new[] {
                commentRemover,
                whitespaceRemover,
                labelSymbolPreprocessor,
                emptyLineRemover,
                predefinedSymbolPreprocessor,
                variableSymbolPreprocessor
            };

            IDestinationsParser destinationsParser = new DestinationsParser();
            IComputationOptionsParser computationOptionsParser = new ComputationOptionsParser();
            IJumpConditionsParser jumpConditionsParser = new JumpConditionsParser();

            IInstructionParser addressingInstructionParser = new AddressingInstructionParser();
            IInstructionParser computeInstructionParser = new ComputeInstructionParser(destinationsParser, computationOptionsParser, jumpConditionsParser);

            IEnumerable<IInstructionParser> instructionParsers = new[] {
                addressingInstructionParser,
                computeInstructionParser
            };

            IParser parser = new Parser(instructionParsers);

            IDictionary<Type, IInstructionTranslator> translators = new Dictionary<Type, IInstructionTranslator>()
            {
                { typeof(AddressingInstruction), new AddressingInstructionTranslator() },
                { typeof(ComputeInstruction), new ComputeInstructionTranslator() }
            };

            ITranslator translator = new Translator(translators);

            IAssembler assembler = new Assembler(preprocessors, parser, translator);

            for (int i = 0; i < args.Length; i++)
            {
                var lines = File.ReadAllLines(args[i]);

                Result<List<string>> assemblyResult = assembler.Assemble(lines);

                if (assemblyResult.Error != null)
                {
                    Console.WriteLine($"Error: {assemblyResult.Error}");
                }

                File.WriteAllLines(Path.ChangeExtension(args[i], ".hack"), assemblyResult.Value);

                Console.WriteLine($"Successfully assembled {Path.GetFileName(args[i])}."); 
            }
        }
    }
}
