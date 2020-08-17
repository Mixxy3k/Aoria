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

        public RenderWindow GameWindow { get; set; }
        public KeyList keyList = new KeyList();
        private VideoMode VideoMode { get; set; }
        private readonly Logger logger = Logger.Instance;
        public static Window Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Window();
                        }
                    }
                }
                return instance;
            }
        }

        public void ClearKeyList()
        {
            keyList &= keyList & ~keyList;
        }


        private Window()
        {
            if (CreateWindow())
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
            VideoMode = new VideoMode(1280, 720);
            try
            {
                GameWindow = new RenderWindow(VideoMode, "Aoria v2 - C#");
            }
            catch (Exception e)
            {
                logger.Error(String.Format($"Cannot create window! [{e.Message}]"), e.GetHashCode());
                return false;
            }
            return true;
        }

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            SFML.Window.Window window = (SFML.Window.Window)sender;

            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
                logger.Info(String.Format($"Game closed via [{e.Code}] button!"));
            }

            _ = e.Code switch
            {
                Keyboard.Key.S => keyList |= KeyList.PressedS,
                Keyboard.Key.A => keyList |= KeyList.PressedA,
                Keyboard.Key.W => keyList |= KeyList.PressedW,
                Keyboard.Key.D => keyList |= KeyList.PressedD,
            };

           
        }
    }
}
