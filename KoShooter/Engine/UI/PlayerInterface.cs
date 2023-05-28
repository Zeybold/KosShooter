using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static KosShooter.Configurations;

namespace KosShooter;

public static class PlayerInterface
{
    private static readonly ProgressBar HealthBar = 
        new(TextureSource.HealthBarEmpty, TextureSource.HealthBarFill, Player.Creature.MaxHp,
        new Vector2(ScreenWidth-ScreenWidth/7, 
            ScreenHeight-ScreenHeight/20));
    private static readonly ProgressBar TimeBar = 
        new(TextureSource.TimeBarEmpty, TextureSource.TimeBarFill, Player.Creature.MaxHp,
            new Vector2(ScreenWidth/100, 
                ScreenHeight-ScreenHeight/20));
    public static void Update()
    {
        HealthBar.Update(Player.Creature.CurrentHp);
        TimeBar.Update(Player.Creature.CurrentHp);
    }

    public static void Draw()
    {
        HealthBar.Draw();
        TimeBar.Draw();
    }
}