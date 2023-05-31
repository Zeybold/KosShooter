using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public interface IMovementComponent
{
    public void Move();
    protected Vector2 MinPos { get; set; }
    protected Vector2 MaxPos { get; set; }

    public void SetBounds(Point mapSize, Point tileSize);
}