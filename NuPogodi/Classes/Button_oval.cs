using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;



namespace Нупогоди.Classes
{
    class Button_oval
    {
        private KeyboardState prevKeyboardState;
        private int a;
        Vector2 position;
        Texture2D texture;
        private bool isOn = false;
        private bool isPress = false;
        private bool on=false;
        private bool music=false;
        private bool non = false;

        public bool IsOn { get { return isOn; } }
        public bool IsPress { get { return isPress; } }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("button_oval");
        }
        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            a++;
           
            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);
                if (state.IsButtonUp(Buttons.Y))
                {
                    on = false;
                }
                if (state.IsButtonUp(Buttons.B))
                {
                    music = false;
                }
                if (state.IsButtonDown(Buttons.Y)&&!on)
                {
                    if (isOn)
                    {
                        isOn = false;
                    }
                    else
                    {
                        isOn = true;
                    }
                    position.X = 600;
                    position.Y = -410;
                    a = 0;
                    on = true;
                }
                if (state.IsButtonDown(Buttons.A))
                {
                    position.X = 600;
                    position.Y = -180;
                    a = 0;
                }
                if (state.IsButtonDown(Buttons.B)&& !music)
                {
                    position.X = 600;
                    position.Y = -300;
                    a = 0;
                    isPress = !isPress;
                    music = true;
                }
                if (a == 5)
                {
                    a = 0;
                    position.X = 2000;
                    position.Y = 2000;
                }
            }
            else
            {

                if (keyboard != prevKeyboardState)
                {
                    if (keyboard.IsKeyDown(Keys.I))
                    {
                        if (isOn)
                        {
                            isOn = false;
                        }
                        else
                        {
                            isOn = true;
                        }
                        position.X = 600;
                        position.Y = -410;
                        a = 0;
                    }
                    if (keyboard.IsKeyDown(Keys.P))
                    {
                        position.X = 600;
                        position.Y = -180;
                        a = 0;
                    }
                    if (keyboard.IsKeyDown(Keys.O))
                    {
                        position.X = 600;
                        position.Y = -300;
                        a = 0;
                        isPress = !isPress;
                    }
                }
                prevKeyboardState = keyboard;

                if (a == 5)
                {
                    a = 0;
                    position.X = 2000;
                    position.Y = 2000;
                }
            }
        }
    
    }
}

