using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    internal class DeathScore
    {
        private static Texture2D texture;
        private Vector2 position = new Vector2(1030, 290);
        private Vector2 Pos = new Vector2(1030, 290);
        private bool installpos = true;
        public Vector2 Position { get; set; }
        public static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("breggs");
        }
        public void Draw(SpriteBatch spriteBatch,int pos)
        {
            if (installpos)
            {
                Pos.X -= pos * 100;
                installpos = false;
            }
            spriteBatch.Draw(texture, Pos, Color.White);
        }
    }
}
