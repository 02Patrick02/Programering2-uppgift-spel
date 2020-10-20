using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class player : playerbase
    {
        private Vector2 playerPos;
        private Rectangle  bulletRec;

        private List<Vector2> BulletsList = new List<Vector2>();

        public Rectangle BulletRec;
 

        public player(Texture2D tex) : base(tex)
        {
           
        }

        public override void Update()
        {
            KeyboardState a = Keyboard.GetState();

            bulletRec = new Rectangle((int)bulletRec.X, (int)bulletRec.Y, 100, 100);

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

            if (a.IsKeyDown(Keys.Space) && a.IsKeyUp(Keys.Space))
            {
                BulletsList.Add(playerPos);
            }
            for (int i = 0; i < BulletsList.Count; i++)
            {
                BulletsList[i] = BulletsList[i] - new Vector2(0, 5);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 100), Color.White);

            foreach (Vector2 BulletList in BulletsList)
            {
                Rectangle rec = new Rectangle();
                rec.Location = BulletsList.ToPoint();
                rec.Size = new Point(40, 40);
                spriteBatch.Draw(texture, rec, Color.White);
            }
        }
    }
}
