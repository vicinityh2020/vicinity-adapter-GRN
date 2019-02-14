using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace VicinityCLP
{
    public class ProcessHandling
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

        // Delegate type to be used as the Handler Routine for SCCH
        delegate Boolean ConsoleCtrlDelegate(CtrlTypes type);

        // Enumerated type for the control messages sent to the handler routine
        enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

        public static void StopProcess(uint process_id)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    // It's impossible to be attached to 2 consoles at the same time,
                    // so release the current one.
                    FreeConsole();

                    // This does not require the console window to be visible.
                    if (AttachConsole(process_id))
                    {
                        // Disable Ctrl-C handling for our program
                        SetConsoleCtrlHandler(null, true);
                        GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);

                        // Must wait here. If we don't and re-enable Ctrl-C
                        // handling below too fast, we might terminate ourselves.
                        Thread.Sleep(3000);

                        FreeConsole();

                        // Re-enable Ctrl-C handling or any subsequently started
                        // programs will inherit the disabled state.
                        SetConsoleCtrlHandler(null, false);
                    }
                }
                catch
                { }
            });
        }
    }
}
