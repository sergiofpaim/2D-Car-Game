using CarGame.Enviroment;
using Gma.System.MouseKeyHook;

namespace CarGame
{
    internal static class Program
    {
        private static readonly IKeyboardMouseEvents m_GlobalHook = Hook.GlobalEvents();

        /// <summary>
        ///  The main entry po
        ///  for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            m_GlobalHook.KeyDown += GamingControl.Input_KeyDown;
            m_GlobalHook.KeyUp += GamingControl.Input_KeyUp;

            Scheduler.Init(100);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            Application.Run(new TwoDWorld());
        }
    }
}