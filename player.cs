using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class player : playerbase
    {
        private Vector2 playerPos;
    

        private List<Vector2> BulletsList;

        private KeyboardState oldKState;

 

        public player(Texture2D tex, List<Vector2> bullets) : base(tex)
        {
            BulletsList = bullets;
        }

        public override void Update()
        {
            KeyboardState a = Keyboard.GetState();

            

            if (a.IsKeyDown(Keys.D))
                playerPos.X += 10;
            if (a.IsKeyDown(Keys.A))
                playerPos.X -= 10;
            if (a.IsKeyDown(Keys.W))
                playerPos.Y -= 10;
            if (a.IsKeyDown(Keys.S))
                playerPos.Y += 10;

            if (playerPos.X <= 0)
                playerPos.X = 0;
            if (playerPos.X >= 1780)
                playerPos.X = 1780;
            if (playerPos.Y <= 0)
                playerPos.Y = 0;
            if (playerPos.Y >= 930)
                playerPos.Y = 930;

            if (a.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                BulletsList.Add(playerPos + new Vector2(30, 0));
            }


            oldKState = a;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 100), Color.White);
        }
    }
}
