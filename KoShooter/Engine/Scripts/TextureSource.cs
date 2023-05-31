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
    public static readonly Texture2D Enemy = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Enemies/enemy1");
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
    public static readonly Texture2D Shootgun =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Shootgun");
     public static readonly Texture2D Pistol =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Pistol");
    public static readonly Texture2D M16 =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/M16");
    public static readonly List<Texture2D> MapTextures = new(5);

    public static void FillMap()
    {
        for (var i = 1; i < 5; i++)
        {
            MapTextures.Add( Configurations.ContentGame.Load<Texture2D>("TextureGames/Map/Title"+i));
        }
    }
}