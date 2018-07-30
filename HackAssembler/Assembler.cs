using HackAssembler.Parsing;
using HackAssembler.Preprocessing;
using HackAssembler.Translation;
using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class Assembler : IAssembler
    {
        private readonly IEnumerable<IPreprocessor> _preprocessors;
        private readonly IParser _parser;
        private readonly ITranslator _translator;

        public Assembler(IEnumerable<IPreprocessor> preprocessors, IParser parser, ITranslator translator)
        {
            _preprocessors = preprocessors;
            _parser = parser;
            _translator = translator;
        }

        public Result<List<string>> Assemble(string[] source)
        {
            foreach (var preprocessor in _preprocessors)
            {
                preprocessor.Process(ref source);
            }

            var parseResult = _parser.Parse(source);

            if (parseResult.Error != null)
            {
                return new Result<List<string>>(null, parseResult.Error);
            }

            var translationResult = _translator.Translate(parseResult.Value);

            if (translationResult.Error != null)
            {
                return new Result<List<string>>(null, translationResult.Error);
            }

            var machineCode = new List<string>();

            foreach (var item in translationResult.Value)
            {
                machineCode.Add(Convert.ToString(item, 2).PadLeft(16, '0'));
            }

            return new Result<List<string>>(machineCode);
        }
    }
}
