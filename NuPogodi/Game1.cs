using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Нупогоди.Classes;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System;
using NuPogodi.Classes;

namespace NuPogodi
{
    enum GameType { Game, Off,GameOver };
    public class Game1 : Game
    {
        Random r = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song song;
        private GameType type = GameType.Off;
        private int score = 0;
        private int num_eggs = 2;
        private int difficult = 0;
      
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1725;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        BackGrownd back = new BackGrownd();
        Button_oval button_oval = new Button_oval();
        Button_sphere button_sphere = new Button_sphere();
        Woolf woolf = new Woolf();
        SpriteFont font; 
        List<DeathScore> deathScores = new List<DeathScore>();
        List<Eggs> eggsList = new List<Eggs>();
        GameOver gameOver = new GameOver();
        protected override void Initialize()
        {
         
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
  
            back.LoadContent(Content);
            button_oval.LoadContent(Content);
            button_sphere.LoadContent(Content);
            woolf.LoadContent(Content);
            DeathScore.LoadContent(Content);
            //  @break.LoadContent(Content);
            gameOver.LoadContent(Content);
            song = Content.Load<Song>("music");
            font = Content.Load<SpriteFont>("MenuFont");
            Eggs a = new Eggs(r.Next(0, 10));
            a.LoadContent(Content);
            eggsList.Add(a);
            MediaPlayer.Play(song);
        }
        protected override void Update(GameTime gameTime)
        {
            System.Diagnostics.Debug.WriteLine(eggsList.Count);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            GamePadCapabilities capabilities = GamePad.GetCapabilities(
                                            PlayerIndex.One);


          
            switch (type)
            {
                case GameType.Game:
                    // MediaPlayer.Play(song);
                    back.On = button_oval.IsOn;
                    if (!back.On)
                    {
                        type = GameType.Off;
                    }
                    UpdateGame(gameTime);
                    break;
                case GameType.Off:
                    MediaPlayer.Pause();
                    back.On = button_oval.IsOn;
                    if (back.On)
                    {
                        type = GameType.Game;
                    }
                    back.Update();
                    button_oval.Update();
                    button_sphere.Update();
                    break;
                case GameType.GameOver:
                    button_sphere.Update();
                    button_oval.Update();
                    break;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
           

                switch (type)
            {
                case GameType.Game:
                    DrawGame();
                    break;
                case GameType.Off:

                    back.On = false;
                    back.Draw(_spriteBatch);
                    button_sphere.Draw(_spriteBatch);
                    button_oval.Draw(_spriteBatch);
                    break;
                case GameType.GameOver:
                    MediaPlayer.Pause();
                    back.Draw(_spriteBatch);
                    button_sphere.Draw(_spriteBatch);
                    button_oval.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void UpdateGame(GameTime gameTime)
        {
            back.Update();
            button_sphere.Update();
            button_oval.Update();
            woolf.Update();
            if (woolf.Position_Woolf == 1 || woolf.Position_Woolf == 2)
            {
                //breakegg.Storona = true;
            }
            else
            {
              //  breakegg.Storona = false;
            }
            if (button_oval.IsPress == true)
            {
                MediaPlayer.Pause();
            }
            else
            {
                MediaPlayer.Resume();
            }

            for (int i = 0; i < eggsList.Count; i++)
            {
                eggsList[i].Update(gameTime);
            }
            EggsManager();
            Conflict();
        }

        public void DrawGame()
        {
            back.Draw(_spriteBatch);
            button_oval.Draw(_spriteBatch);
            button_sphere.Draw(_spriteBatch);
            woolf.Draw(_spriteBatch);
            for (int i = 0; i < eggsList.Count; i++)
            {
                eggsList[i].Draw(_spriteBatch);
            }
            for (int i = 0; i < deathScores.Count; i++)
            {
                deathScores[i].Draw(_spriteBatch,i);
            }
            _spriteBatch.DrawString(font, score.ToString(), new Vector2(1000, 210), Color.Black);
           // deathScore.Draw(_spriteBatch);
            // @break.Draw(_spriteBatch);
        }
        public void EggsManager()
        {


            for (int i = 0; i < eggsList.Count; i++)
            {
                if (!eggsList[i].IsVisible)
                {
                    eggsList.Remove(eggsList[i]);
                    i--;
                }
            }

            if (eggsList.Count < num_eggs && eggsList[eggsList.Count - 1].CurrentFrame >= 1 || eggsList[eggsList.Count - 1].CurrentFrame >= 2)
            {
                Eggs e = new Eggs(0);
                e.LoadContent(Content);
                eggsList.Add(e);
            }
        }
        public void Conflict()
        {
            foreach (var item in eggsList)
            {
                if (item.CurrentFrame == 4)
                {
                    if (woolf.Position_Woolf == item.Position_Spawn)
                    {
                        item.IsVisible = false;
                        score++;
                    }
                    else
                    {
                        item.IsVisible = false;
                        if (deathScores.Count>=3)
                        {
                            type =GameType.GameOver;
                        }
                        else
                        {
                            DeathScore score = new DeathScore();
                            deathScores.Add(score);
                        }
                   
                    }
                }
            }
        }
    }
}
