using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class enemy : playerbase
    {
        private Rectangle enemyRec;

       
        public enemy(Texture2D tex) : base(tex)
        {
            
        }

        public override void Update()
        {
            
        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, enemyRec, Color.White);
        }

    }
}
