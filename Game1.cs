using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState oldKState;

        private Texture2D playerTex, enemyTex, bulletTex;

        private int enemyCount = 0;

        private readonly Random rnd = new Random();


        private readonly List<Bullet> bullets = new List<Bullet>();
        private readonly List<Enemy> enemies = new List<Enemy>();


        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTex = Content.Load<Texture2D>("player");
            enemyTex = Content.Load<Texture2D>("enemy");
            bulletTex = Content.Load<Texture2D>("bullet");

            player = new Player(playerTex, new Vector2(100, 100), new Point(100, 100));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState a = Keyboard.GetState();


            if (a.IsKeyDown(Keys.Escape))
                Exit();



            player.Update();



            foreach (Bullet bullets in bullets)
            {
                bullets.Move();
            }

            foreach (Enemy enemies in enemies)
            {
                enemies.Move();
            }



            if (rnd.Next(0, 60) == 0 && enemyCount < 20)
            {
                enemies.Add(new Enemy(enemyTex, new Vector2(rnd.Next(0, 1800),-100), new Point(100, 100), 2)); // texture, position, X, Y, Size, health 


                enemyCount++;
            }
            else
            {
                enemyCount = 0;
            }


            if (a.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                bullets.Add(new Bullet(bulletTex, new Vector2(player.Position.X + 30, player.Position.Y), new Point(40, 40)));

            }

            oldKState = a;

            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (enemies[j].Rectangle.Intersects(bullets[i].Rectangle))
                    {
                        bullets.RemoveAt(i);
                        i--;

                        enemies[j].HealthLoss();
                        if (enemies[j].Health <= 0)
                        {
                            enemies.RemoveAt(j);
                            j--;
                        }
                    }
                }


                for (int j = 0; j < enemies.Count; j++)
                {
                    if (enemies[j].Rectangle.Intersects(player.Rectangle))
                    {
                        Exit();
                    }
                }
               
                base.Update(gameTime);
            }
        }  


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach (Enemy enemies in enemies)
            {
                enemies.Draw(spriteBatch);
            }

            foreach (Bullet bullets in bullets)
            {
                bullets.Draw(spriteBatch);
            }
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
