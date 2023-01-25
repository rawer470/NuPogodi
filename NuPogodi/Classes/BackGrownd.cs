using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    class BackGrownd
    {
      private  Vector2 position = new Vector2(-100,0);
       private Texture2D textureon;
        private Texture2D textureoff;
       private bool on = false;
        public bool On { get { return on; } set { on = value; } }

        public void Draw(SpriteBatch spriteBatch)
        {
            
               spriteBatch.Draw(textureon, position, Color.White);
            if (!on)
            {
                spriteBatch.Draw(textureoff, position, Color.White);
            }
        }

        public void LoadContent(ContentManager manager)
        {
           textureon = manager.Load<Texture2D>("console");
            textureoff = manager.Load<Texture2D>("console off");

        }

        public void Update()
        {

        }
    }
    
}
