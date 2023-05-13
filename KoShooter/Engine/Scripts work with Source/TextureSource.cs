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
    public static Texture2D Player = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
    public static Texture2D PlayerWithPistols = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/PlayerWithGun");
    public static Texture2D Enemy = Configurations.ContentGame.Load<Texture2D>("TextureGames/Enemies/enemy1");
    public static Texture2D Bullet = Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/bullet");
    public static Texture2D Gun1 = Configurations.ContentGame.Load<Texture2D>("TextureGames/Weapons/weapon1");
}