using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class playerbase
    {
        protected Texture2D texture;

        public virtual void Update()
        {

        }

        public playerbase(Texture2D tex)
        {
            texture = tex;
        }
    }
}
