using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace Aoria
{
    class Entity: Drawable
    {
        public virtual string Name { get; set; }
        public virtual int HP { get; set; }
        public virtual Sprite Sprite { get; set; }

        protected Logger logger;

        public void Draw(RenderTarget target, RenderStates states) => target.Draw(Sprite, states);
    }
}
