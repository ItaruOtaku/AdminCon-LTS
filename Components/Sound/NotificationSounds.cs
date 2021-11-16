using System;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ExceptionNotiSound.cs
 * Intro: Sounds
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Sound
{
    /// <summary>
    /// Notification sounds
    /// </summary>
    class NotificationSounds
    {
        public void BeepBadCommand() //While the command cannot be analyzed
        {
            for(Int32 i=0; i<3; i++)
            {
                Console.Beep(600, 50);
            }
        }
        public void BeepException() //While the command throws an exception
        {
            Console.Beep(600, 80);
            Console.Beep(400, 80);
        }
        public void BeepQuit() //While the program closes/restarts by using "QT" command
        {
            Console.Beep(600, 300);
            Console.Beep(400, 400);
        }
        public void BeepLaunch() //While the program finished loading components
        {
            Console.Beep(400, 400);
            Console.Beep(600, 300);
        }
        public void BeepComplete() //While an operation/request has been completed.
        {
            Console.Beep(400, 100);
            Console.Beep(400, 100);
        }
    }
}
//Program Entry @ Program.cs