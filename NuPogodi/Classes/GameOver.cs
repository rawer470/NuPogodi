using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    internal class GameOver
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(-100, 0);

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("GameOver");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }
    }
}
