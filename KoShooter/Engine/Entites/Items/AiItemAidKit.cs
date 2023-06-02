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
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace KosShooter.Items;

public class AiItemAidKit: AiItem
{
    private float heal;
    public AiItemAidKit(float hh = 0)
    {
        Status = GameStatus.OnFloor;
        if (hh==0)
            heal = GreatAndFuriousRandom.NextFloat(10, 100)*PlayerSkills.Luck;
        else
        {
            heal = hh;
        }
        if (heal > 100)
            heal = 100;
        Texture = heal switch
        {
            >= 10 and < 25 => TextureSource.Medicine[0],
            >= 25 and < 50 => TextureSource.Medicine[1],
            >= 50 and <= 100 => TextureSource.Medicine[2],
            _ => Texture
        };
    }

    public void UseItem()
    {
        Player.Creature.Heal(heal);
        base.UseItem();
    }
}