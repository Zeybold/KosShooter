using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Enemy : Entity
{
    public Enemy()
    {
        Texture = TextureSource.Enemy;
        Position = new Vector2(150, 150);
        Velocity = 3;
    }
    public override void Update(GameTime gameTime)
    {
        FindPlayer();
    }
    private void FindPlayer()
    {
        var mousePosition = Player.Creature.GetPositionEntity();
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI/2;
        Rotation = angle;
    }
}