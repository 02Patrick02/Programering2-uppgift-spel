using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class enemy : playerbase
    {
        
        public enemy(Texture2D tex, Vector2 position, Point size) : base(tex)
        {
            texture = tex;
            base.position = position;
            base.rectangle = new Rectangle(position.ToPoint(), size);
        }

        public void Move()
        {
            position.Y += 2;
            rectangle = new Rectangle(position.ToPoint(), rectangle.Size); // Rectangle = Position
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }

    }
}
