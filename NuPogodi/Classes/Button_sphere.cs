using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    class Button_sphere
    {
        Vector2 position;
        Texture2D texture;
        private int a;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("button");
        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
         

          
            a++;
          
            if (capabilities.IsConnected)
            {
                // Get the current state of Controller1
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (state.IsButtonDown(Buttons.LeftShoulder))  //state.IsButtonDown(Buttons.LeftTrigger)
                {
                    position.X = -772;
                    position.Y = 167;
                    a = 0;
                }
                if (state.IsButtonDown(Buttons.LeftTrigger))
                {
                    position.X = -772;
                    position.Y = 376;
                    a = 0;
                }
                if (state.IsButtonDown(Buttons.RightTrigger))
                {  
                    position.X = 556;
                    position.Y = 376;
                    a = 0;
                }
                if (state.IsButtonDown(Buttons.RightShoulder))
                {
                    position.X = 556;
                    position.Y = 167;
                    a = 0;
                }

            }
             else
             {
                 if (keyboard.IsKeyDown(Keys.E))
                 {
                     position.X = 556;
                     position.Y = 167;
                     a = 0;
                 }
                 if (keyboard.IsKeyDown(Keys.D))
                 {
                     position.X = 556;
                     position.Y = 376;
                     a = 0;
                 }
                 if (keyboard.IsKeyDown(Keys.Q))
                 {
                     position.X = -772;
                     position.Y = 167;
                     a = 0;
                 }
                 if (keyboard.IsKeyDown(Keys.A))
                 {
                     position.X = -772;
                     position.Y = 376;
                     a = 0;
                 }

             }


            if (a == 5)
            {
                a = 0;
                position.X = 2000;
                position.Y = 2000;
            }
        }
    }
}
