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

        private int EnemyPos = 0, EnemyTimer = 0, SpawnRate = 60;

        private Random rnd = new Random();

        private List<Vector2> BulletsList = new List<Vector2>();
        private List<Vector2> RandomEnemySpawn = new List<Vector2>();


        player player;

        enemy enemy;

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
            
            
            enemy = new enemy(enemyTex);
            player = new player(playerTex,BulletsList);
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
            enemy.Update();
            for (int i = 0; i < BulletsList.Count; i++)
            {
                BulletsList[i] = BulletsList[i] - new Vector2(0, 5);
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.draw(spriteBatch);
            enemy.draw(spriteBatch);

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
