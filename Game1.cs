using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D playerTex, enemyTex, bulletTex;

        private int EnemyPos = 0, EnemyTimer = 0, SpawnRate = 90;

        private Random rnd = new Random();


        private List<Vector2> BulletsList = new List<Vector2>();
        private List<Vector2> RandomEnemySpawn = new List<Vector2>();
        List<enemy> enemies = new List<enemy>();


        player player;

        enemy enemy1;

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
            enemyTex = Content.Load<Texture2D>("enemy1");
            bulletTex = Content.Load<Texture2D>("bullet");

            player = new player(playerTex, new Vector2(100,100),BulletsList, new Point(100,100));
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

            foreach(enemy enemies in enemies)
            {
                enemies.Move();
            }
      
            for (int i = 0; i < BulletsList.Count; i++)
            {
                BulletsList[i] = BulletsList[i] - new Vector2(0, 5);
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
               enemies.Add(new enemy(enemyTex, new Vector2 (EnemyPos, 0), new Point(100, 100)));
            }
            for (int i = 0; i < RandomEnemySpawn.Count; i++)
            {
                RandomEnemySpawn[i] = RandomEnemySpawn[i] - new Vector2(0, -2);

            }




            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach(enemy enemies in enemies)
            {
                enemies.Draw(spriteBatch);
            }

            foreach (Vector2 BulletList in BulletsList)
            {
                Rectangle rec = new Rectangle();
                rec.Location = BulletList.ToPoint();
                rec.Size = new Point(40, 40);
                spriteBatch.Draw(bulletTex, rec, Color.White);
            }
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
