using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public abstract class VerbOptionsBase
    {
        public abstract void Validate();

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
