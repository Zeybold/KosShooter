using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class TextureSource
{
    public static readonly Texture2D Player = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/Kosiak85x80");
    public static readonly Texture2D Bullet = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Bullet");
    public static readonly Texture2D HealthBarEmpty =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/ProgressBarEmpty256x64");
    public static readonly Texture2D HealthBarFill =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/ProgressBarFill256x64");
    public static readonly Texture2D TimeBarEmpty =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/TimeBarEmpty256x36");
    public static readonly Texture2D TimeBarFill =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/TimeBarFill256x36");
    public static readonly Texture2D LevelBarEmpty =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/LevelBarEmpty256x26");
    public static readonly Texture2D LevelBarFill =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/LevelBarFill256x26");
    public static readonly List<Texture2D> WeaponList = FillListTextures("TextureGames/Weapons/wep",4);
    public static readonly List<Texture2D> MapTextures = FillListTextures("TextureGames/Map/Title",5);
    public static readonly List<Texture2D> Medicine = FillListTextures("TextureGames/Items/HealthAid",4);
    public static readonly List<Texture2D> Enemies = FillListTextures("TextureGames/Enemies/Enemy",4);
    private static List<Texture2D> FillListTextures(string way, int count)
    {
        var list = new List<Texture2D>();
        for (var i = 1; i < count; i++)
            list.Add( Configurations.ContentGame.Load<Texture2D>(way+i));
        return list;
    }
}