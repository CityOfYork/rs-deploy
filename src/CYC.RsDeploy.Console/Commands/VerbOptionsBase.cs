using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public abstract class VerbOptionsBase
    {
        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
