using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Aoria
{
    public sealed class Window
    {
        private static readonly object padlock = new object();
        private static Window instance = null;
        public static Window Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(padlock)
                    {
                        if(instance == null)
                        {
                            instance = new Window();
                        }
                    }
                }
                return instance;
            }
        }


        private Window()
        {
            if(CreateWindow())
                logger.Info("Created window!");
            else
                logger.Error("Cannot create window!");

            GameWindow.KeyPressed += Window_KeyPressed;
            GameWindow.Closed += (sender, __) =>
            {
                var window = (SFML.Window.Window)sender;
                window.Close();
                logger.Info("Game closed via [X] button");
            };
        }

        private bool CreateWindow()
        {
            videoMode = new VideoMode(1280, 720);
            try
            {
                GameWindow = new RenderWindow(videoMode, "Aoria v2 - C#");
            }
            catch(Exception e)
            {
                logger.Error(String.Format($"Cannot create window! [{e.Message}]"), e.GetHashCode());
                return false;
            }
            return true;
        }

        public RenderWindow GameWindow { get; set; }
        private VideoMode videoMode { get; set; }

        private Logger logger = Logger.Instance;

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
                logger.Info("Window is closed via ESC button");
            }
        }
    }
}
