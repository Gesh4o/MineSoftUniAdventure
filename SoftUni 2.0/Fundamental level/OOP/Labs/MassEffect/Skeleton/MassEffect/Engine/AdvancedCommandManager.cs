namespace MassEffect.Engine
{
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class AdvancedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
        }
    }
}
