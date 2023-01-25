using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    internal class BreakEgg
    {
        private Vector2 position;
        private Texture2D texture;
        private Texture2D cipa;
        private int currentFrame;//нынышний кадр
        private int countframes;//кол-во кадров
        private int widthFrame;//ширина
        private int heightFrame;//высота
        private bool loop;//зацикливание
        private float duration;//длительность в мс
        private float durationOneFrame;//задержка одного кадра
        private double totalduration;//итоговая задержка
        private int itogbreeg;
        private Rectangle rectangle;
        private Vector2 vector;
        public int Itogbreeg { get { return itogbreeg; } set { itogbreeg = value; } }
        public bool Storona { get; set; }
        public BreakEgg()
        {
            ConfigAnimation();
            position = new Vector2(1000, 1000);
        }
        public void LoadContent(ContentManager content)
        {
            cipa = content.Load<Texture2D>("cipa");
        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle(currentFrame * widthFrame, 0, widthFrame, heightFrame);
            totalduration += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (totalduration >= durationOneFrame)
            {
                currentFrame++;
                totalduration = 0;
            }
            if (currentFrame >= countframes)
            {
                ConfigAnimation();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Storona)
            {
                position = new Vector2(1000,980);
                spriteBatch.Draw(cipa,position,rectangle,Color.White);
            }
            else
            {
                SpriteEffects effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);
            }
        }

        private void ConfigAnimation()
        {
            currentFrame = 0;//нынышний кадр
            countframes = 5;//кол-во кадров
            widthFrame = 344 / 5;//ширина
            heightFrame = 194;//высота
            loop = false;//зацикливание
            duration = 5000;//длительность в мс     будет уменьшаться взависимости от сложности
            durationOneFrame = duration / countframes;//задержка одного кадра
            totalduration = 0;//итоговая задержка
        }
    }
}
