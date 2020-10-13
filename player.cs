using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class player : playerbase
    {
        private Texture2D bullets;
        private Vector2 playerPos, bulletsPos;
        private Rectangle hitbox, bulletsRec;

        private List<Vector2> Bullets = new List<Vector2>();
        public player(Texture2D tex) : base(tex)
        {

        }
        

        public override void Update()
        {
            KeyboardState a = Keyboard.GetState();

            hitbox = new Rectangle((int)hitbox.X, (int)hitbox.Y, 100, 100);
            bulletsRec = new Rectangle((int)bulletsRec.X, (int)bulletsRec.Y, 100, 100);

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
                Bullets.Add(playerPos + new Vector2(89, 0));
            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i] = Bullets[i] - new Vector2(0, 5);
            }
        }
      
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 100), Color.White);
            spriteBatch.Draw(bullets, bulletsPos, Color.White);
        }
    }
}
