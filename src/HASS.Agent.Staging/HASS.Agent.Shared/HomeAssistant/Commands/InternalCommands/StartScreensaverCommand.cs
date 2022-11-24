using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Functions;
using Serilog;

namespace HASS.Agent.Shared.HomeAssistant.Commands.InternalCommands
{
    /// <summary>
    /// Command to put all monitors to sleep
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class StartScreensaverCommand : InternalCommand
    {
        public StartScreensaverCommand(string name = "StartScreensaver", CommandEntityType entityType = CommandEntityType.Button, string id = default) : base(name ?? "StartScreensaver", string.Empty, entityType, id)
        {
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            NativeMethods.SendMessage(NativeMethods.GetDesktopWindow(), 0x112, (IntPtr)0xF140, (IntPtr)0);

            State = "OFF";
        }
    }
}
