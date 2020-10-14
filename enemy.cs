using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class enemy : playerbase
    {
        Rectangle enemyRec;
        Vector2 enemyPos;
        public enemy(Texture2D tex) : base(tex)
        {

        }
        public override void Update()
        {

        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)enemyPos.X, (int)enemyPos.Y, 100, 100), Color.White);
        }

    }
}
