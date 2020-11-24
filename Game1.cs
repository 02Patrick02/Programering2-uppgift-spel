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

        private int EnemyPos = 0, EnemyTimer = 0, SpawnRate = 90;

        private readonly Random rnd = new Random();


        private readonly List<Bullet> bullets = new List<Bullet>();
        private readonly List<Vector2> RandomEnemySpawn = new List<Vector2>();
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

            foreach (Enemy enemies in enemies)
            {
                enemies.Move();
            }

            foreach (Bullet bullets in bullets)
            {
                bullets.Move();
            }


            if (SpawnRate > 10)
            {
                EnemyTimer++;
                if (EnemyTimer == 120)
                {
                    SpawnRate -= 5;
                    EnemyTimer = 0;
                }
            }

            if (SpawnRate <= 15 && SpawnRate > 5)
            {
                EnemyTimer++;
                if (EnemyTimer == 120)
                {
                    SpawnRate -= 1;
                    EnemyTimer = 0;
                }
            }

            EnemyPos = rnd.Next(0, 1800);
            if (rnd.Next(0, SpawnRate) == 0)
            {
                enemies.Add(new Enemy(enemyTex, new Vector2(EnemyPos, 0), new Point(100, 100)));
            }
            for (int i = 0; i < RandomEnemySpawn.Count; i++)
            {
                RandomEnemySpawn[i] = RandomEnemySpawn[i] - new Vector2(0, -2);

            }

            if (a.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                bullets.Add(new Bullet(bulletTex, new Vector2(player.Position.X + 30, player.Position.Y), new Point(40, 40)));

            }

            oldKState = a;

            foreach (Bullet bullets in bullets)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (bullets.Rectangle.Intersects(enemies[i].Rectangle))
                    {
                        enemies.RemoveAt(i);
                    }
                }
            }

            base.Update(gameTime);
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