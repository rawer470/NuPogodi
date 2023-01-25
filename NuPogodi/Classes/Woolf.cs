using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace NuPogodi.Classes
{
    internal class Woolf
    {
        Vector2 position;
        Texture2D texture_up;
        Texture2D texture_down;






        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private int position_Woolf = 1;

        public int Position_Woolf
        {
            get { return position_Woolf; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (position_Woolf == 1)
            {
                spriteBatch.Draw(texture_up, position, Color.White);
            }
            if (position_Woolf == 2)
            {
                spriteBatch.Draw(texture_down, position, Color.White);
            }
            if (position_Woolf == 3)
            {
                SpriteEffects effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture_up, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);
                position.X = -900;
            }
            if (position_Woolf == 4)
            {
                SpriteEffects effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture_down, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);


            }
        }

        public void LoadContent(ContentManager manager)
        {
            texture_up = manager.Load<Texture2D>("woolf1");
            texture_down = manager.Load<Texture2D>("woolf2");

        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            Move(keyboard);

        }

        private void Move(KeyboardState keyboard)
        {
            if (position_Woolf == 1 || position_Woolf == 2)
            {
                position.X = 600;
                position.Y = 460;
            }

            if (position_Woolf == 3 || position_Woolf == 4)
            {
                position.X = 750;
                position.Y = 460;
            }


            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);



      

            if (capabilities.IsConnected)
            {
                // Get the current state of Controller1
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (state.IsButtonDown(Buttons.LeftShoulder))  //state.IsButtonDown(Buttons.LeftTrigger)
                {
                    position_Woolf = 2;
                }
                if (state.IsButtonDown(Buttons.LeftTrigger))
                {
                    position_Woolf = 1;
                }
                if (state.IsButtonDown(Buttons.RightTrigger))
                {
                    position_Woolf = 3;
                }
                if (state.IsButtonDown(Buttons.RightShoulder))
                {
                    position_Woolf = 4;

                }

            }
            else
            {

                if (keyboard.IsKeyDown(Keys.A))
                {
                    position_Woolf = 1;


                }
                if (keyboard.IsKeyDown(Keys.Q))
                {
                    position_Woolf = 2;

                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    position_Woolf = 3;

                }
                if (keyboard.IsKeyDown(Keys.E))
                {
                    position_Woolf = 4;

                }
            }
            }

        }
    }



