using System.Threading;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - UserInterface.cs
 * Intro: Create a new thread of graphical interface.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.UI
{
    class UserInterface
    {
        private static void Initialize_UI_Components()
        {
            //Initialize and open a new Winform window instance. (class GraphicalInterface)
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Components.UI.GraphicalInterface ui = new Components.UI.GraphicalInterface();
            System.Windows.Forms.Application.Run(ui);
        }
        private static void Initialize_About_Components()
        {
            //Initialize and open a new Winform window instance. (class About)
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Components.UI.About aboutui = new Components.UI.About();
            System.Windows.Forms.Application.Run(aboutui);
        }
        private static void Initialize_EasterEgg_Components()
        {
            //Initialize and open a new Winform window instance. (class EasterEggPictures)
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Components.UI.EasterEggPictures imageViewer = new Components.UI.EasterEggPictures();
            System.Windows.Forms.Application.Run(imageViewer);
        }

        /// <summary>
        /// The graphical interface must be launched in a different thread to keep the CLI application running in the background.
        /// </summary>
        public void UIWindow_StartInNewThread()
        {
            ThreadStart UIStart = new ThreadStart(Initialize_UI_Components);
            Thread NEW_UI_WINDOW_THREAD = new Thread(UIStart);
            NEW_UI_WINDOW_THREAD.Start();
        }
        public void AboutWindow_StartInNewThread()
        {
            ThreadStart UIStart = new ThreadStart(Initialize_About_Components);
            Thread NEW_UI_WINDOW_THREAD = new Thread(UIStart);
            NEW_UI_WINDOW_THREAD.Start();
        }
        public void EasterEggWindow_StartInNewThread()
        {
            ThreadStart UIStart = new ThreadStart(Initialize_EasterEgg_Components);
            Thread NEW_UI_WINDOW_THREAD = new Thread(UIStart);
            NEW_UI_WINDOW_THREAD.Start();
        }
    }
}
