using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Aoria
{
    class Player: Entity
    {
        public Player()

        {
            logger = Logger.Instance;
            Texture texture = new Texture(@"image.png");

            Sprite = new Sprite(texture)
            {
                Position = new Vector2f(640, 360),
                Rotation = 45.0f,
                Origin = new Vector2f(48, 48)
            };

            logger.Info($"Created Player at position ({Sprite.Position.X},{Sprite.Position.Y})");
        }
        
        public override string Name { get => "Player"; set => base.Name = value; }
        public override int HP { get => base.HP; set => base.HP = value; }

        public override Sprite Sprite { get { return base.Sprite; } set => base.Sprite = value; }
    }
}
