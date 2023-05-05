using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Mouses
{
    private Texture2D _modelMouse;
    private Vector2 _positionMouse;
    public Mouses()
    {
        _positionMouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        _modelMouse = Configurations.ContentGame.Load<Texture2D>("TextureGames/PlayerModel/TexturePlayer");
    }

    public void Update()
    {
        _positionMouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
    }

    public void Draw()
    {
        Configurations.SpriteBatch.
            Draw(_modelMouse,
                new Rectangle((int)_positionMouse.X,(int)_positionMouse.Y,
                    10,10), 
                Color.Black
            );
    }

    public Vector2 GetPositionMouse()
    {
        return _positionMouse;
    }
}