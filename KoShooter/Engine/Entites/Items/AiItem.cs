using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Mime;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Matrix = Microsoft.Xna.Framework.Matrix;
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace KosShooter.Items;
public class AiItem:Entity,IItemComponent
{
    protected Random GreatAndFuriousRandom => new Random();
    
    public void GetPosition(Vector2 position)
    {
        Position = position;
        Rotation = 0f;
    }

    public void UseItem()
    {
        Status = GameStatus.NotExist;
    }
}