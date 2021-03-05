namespace Supercell.Laser.Titan.Debug
{
    using System;

    public class Debugger
    {
        private static IDebuggerListener m_listener;

        public static void Print(string log)
        {
            Console.WriteLine($"[INFO] {log}");
        }

        public static void HudPrint(string log)
        {
            Console.WriteLine($"{log}");
        }

        public static void Warning(string log)
        {
            Console.WriteLine($"[WARNING] {log}");
        }

        public static void Error(string log)
        {
            Console.WriteLine($"[ERROR] {log}");
        }
        public static bool DoAssert(bool assertion, string assertionError)
        {
            if (!assertion)
            {
                Debugger.m_listener.Error(assertionError);
            }

            return assertion;
        }

        public interface IDebuggerListener
        {
            void HudPrint(string message);
            void Print(string message);
            void Warning(string message);
            void Error(string message);
        }
    }
}
