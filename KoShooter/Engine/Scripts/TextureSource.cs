using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

static class TextureSource
{
    public static Texture2D Player = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/Kosiak85x80");
    public static Texture2D PlayerWithPistols = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/Kosiak85x128");
    public static Texture2D PlayerWithShootgun = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/Kosiak85x128Shootgun");
    public static Texture2D Enemy = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Enemies/enemy1");
    public static Texture2D Bullet = 
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Bullet");
    public static Texture2D HealthBarEmpty =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/ProgressBarEmpty256x64");
    public static Texture2D HealthBarFill =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/ProgressBarFill256x64");
    public static Texture2D TimeBarEmpty =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/TimeBarEmpty256x36");
    public static Texture2D TimeBarFill =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/UI/TimeBarFill256x36");
    public static Texture2D Shootgun =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Shootgun");
     public static Texture2D Pistol =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/Pistol");
    public static Texture2D M16 =
        Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/M16");
}