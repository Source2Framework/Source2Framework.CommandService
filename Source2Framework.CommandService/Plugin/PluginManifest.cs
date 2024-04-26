namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;

    public sealed partial class CommandServicePlugin : BasePlugin
    {
        public override string ModuleName => "Source2Framework Command Service";

        public override string ModuleDescription => "Exposing functionality for CSS commands";

        public override string ModuleAuthor => "Nexd @ Eternar";

        public override string ModuleVersion => "1.0.0 " +
#if RELEASE
            "(release)";
#else
            "(debug)";
#endif
    }
}
