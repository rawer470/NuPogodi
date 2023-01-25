using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NuPogodi.Classes
{
    internal class Eggs
    {
        private Vector2 position;
        private Texture2D texture;
        Random random = new Random();
        private Rectangle rectangle;
        private int currentFrame;//нынышний кадр
        private int countframes;//кол-во кадров
        private int widthFrame;//ширина
        private int heightFrame;//высота
        private bool loop;//зацикливание
        private float duration;//длительность в мс
        private float durationOneFrame;//задержка одного кадра
        private double totalduration;//итоговая задержка
        Random r = new Random();
        private int position_spawn;   //позиция спавна (нужно сделать рандом от 1 до 4)

        private int name;

        public bool IsVisible { get; set; } = true;

        private bool is_Broken = false;

        public int CurrentFrame { get { return currentFrame; } }

        public bool Is_Broken
        {
            get { return is_Broken; }
            set { is_Broken = value; }
        }


        public int Position_Spawn
        {
            get { return position_spawn; }
        }

        public Eggs(int name)
        {
            position_spawn = r.Next(1, 5);
            ConfigAnimation();
            this.name = name;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.White);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("eggs");
        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle(currentFrame * widthFrame, 0, widthFrame, heightFrame);
            totalduration += gameTime.ElapsedGameTime.TotalMilliseconds;        //!!!!!! gameTime
            loop = true;
            //position.X += 5f;
            //position.Y += 5f;

            if (totalduration >= durationOneFrame)
            {
                currentFrame++;
                totalduration = 0;
                // IsVisible = false;   // FIX

            }
            if (currentFrame == countframes)
            {
                IsVisible = false;
            }
            /*  if (currentFrame == countframes && loop)
              {
                  currentFrame = 0;
              }*/
            OptPos();

        }
        private void OptPos()
        {
            if (position_spawn == 2)
            {
                if (currentFrame == 0)
                {
                    position.X = 450;
                    position.Y = 390;
                }
                if (currentFrame == 1)
                {
                    position.X = 490; // position.X = 450;
                    position.Y = 410; //position.Y = 390;
                }
                else if (currentFrame == 2)
                {
                    position.X = 535;
                    position.Y = 440;
                }
                else if (currentFrame == 3)
                {
                    position.X = 570;
                    position.Y = 455;
                }
                else if (currentFrame == 4)
                {
                    position.X = 605;
                    position.Y = 470;
                }
                else if (currentFrame == 5)
                {
                    position.X = 640;
                    position.Y = 500;
                }
            }

            if (position_spawn == 1)
            {
                if (currentFrame == 0)
                {
                    position.X = 450;
                    position.Y = 540;
                }
                if (currentFrame == 1)
                {
                    position.X = 490; // position.X = 450;
                    position.Y = 560; //position.Y = 390;
                }
                else if (currentFrame == 2)
                {
                    position.X = 535;
                    position.Y = 590;
                }
                else if (currentFrame == 3)
                {
                    position.X = 570;
                    position.Y = 610;
                }
                else if (currentFrame == 4)
                {
                    position.X = 605;
                    position.Y = 630;
                }
                else if (currentFrame == 5)
                {
                    position.X = 640;
                    position.Y = 650;
                }
            }

            if (position_spawn == 3)
            {
                if (currentFrame == 0)
                {
                    position.X = 1230;
                    position.Y = 540;
                }
                if (currentFrame == 1)
                {
                    position.X = 1190; // position.X = 450;
                    position.Y = 565; //position.Y = 390;
                }
                else if (currentFrame == 2)
                {
                    position.X = 1150;
                    position.Y = 590;
                }
                else if (currentFrame == 3)
                {
                    position.X = 1090;
                    position.Y = 610;
                }
                else if (currentFrame == 4)
                {
                    position.X = 1060;
                    position.Y = 630;
                }
                else if (currentFrame == 5)
                {
                    position.X = 1040;
                    position.Y = 650;
                }
            }

            if (position_spawn == 4)
            {
                if (currentFrame == 0)
                {
                    position.X = 1230;
                    position.Y = 390;
                }
                if (currentFrame == 1)
                {
                    position.X = 1190; // position.X = 450;
                    position.Y = 410; //position.Y = 390;
                }
                else if (currentFrame == 2)
                {
                    position.X = 1150;
                    position.Y = 440;
                }
                else if (currentFrame == 3)
                {
                    position.X = 1090;
                    position.Y = 460;
                }
                else if (currentFrame == 4)
                {
                    position.X = 1060;
                    position.Y = 480;
                }
                else if (currentFrame == 5)
                {
                    position.X = 1040;
                    position.Y = 510;
                }
            }
        }

        private void ConfigAnimation()
        {
            currentFrame = 0;//нынышний кадр
            countframes = 5;//кол-во кадров
            widthFrame = 171 / 5;//ширина
            heightFrame = 42;//высота
            loop = false;//зацикливание
            duration = 5000;//длительность в мс     будет уменьшаться взависимости от сложности
            durationOneFrame = duration / countframes;//задержка одного кадра
            totalduration = 0;//итоговая задержка
        }
    }
}
