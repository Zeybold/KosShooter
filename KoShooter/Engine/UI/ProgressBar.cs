using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public class ProgressBar
{
    private readonly Texture2D _emptyBarTexture;
    private readonly Texture2D _fillBarTexture;
    private readonly Vector2 _positionOnScreen;
    private readonly float _maxValueBar;
    private float _currentValue;
    private Rectangle _part;
    private float _targetValue;
    private const float AnimationSpeed = 25;
    private Rectangle _animationPart;
    private Vector2 _animationPosition;
    private Color _animationShade;
    public ProgressBar(Texture2D emptyBar, Texture2D fillBar, float maxValueBar, Vector2 positionOnScreen)
    {
        _emptyBarTexture = emptyBar;
        _fillBarTexture = fillBar;
        _maxValueBar = maxValueBar;
        _positionOnScreen = positionOnScreen;
        _part = new Rectangle(0, 0, _fillBarTexture.Width, _fillBarTexture.Height);
        _targetValue = maxValueBar;
        _animationPart = new Rectangle(_fillBarTexture.Width, 0, 0, _fillBarTexture.Height);
        _animationPosition = positionOnScreen;
        _animationShade = Color.White;
    }

    public void Update(float value)
    {
        if (Math.Abs(value - _currentValue) < 0.0001) 
            return;
        _targetValue = value;
        int x;
        if (_targetValue < _currentValue)
        {
            _currentValue -= AnimationSpeed * Configurations.IndependentActionsFromFramrate;
            if (_currentValue < _targetValue) 
                _currentValue = _targetValue;
            x = (int)(_targetValue / _maxValueBar * _fillBarTexture.Width);
            _animationShade = Color.Black;
            
        }
        else
        {
            _currentValue += AnimationSpeed * Configurations.IndependentActionsFromFramrate;
            if (_currentValue > _targetValue)
                _currentValue = _targetValue;
            x = (int)(_currentValue / _maxValueBar * _fillBarTexture.Width);
            _animationShade = Color.Blue * 0.5f;
        }

        _part.Width = x;
        _animationPart.X = x;
        _animationPart.Width = (int)(Math.Abs(_currentValue - _targetValue) / _maxValueBar * _fillBarTexture.Width);
        _animationPosition.X = _positionOnScreen.X + x;
    }

    public void Draw()
    {
        Configurations.SpriteBatch.Draw(_emptyBarTexture,_positionOnScreen,Color.White);
        Configurations.SpriteBatch.Draw(_fillBarTexture,_positionOnScreen,_part,Color.White,0,Vector2.Zero,1f,SpriteEffects.None,1f);
        Configurations.SpriteBatch.Draw(_fillBarTexture,_animationPosition,_animationPart,_animationShade,0,Vector2.Zero,1f,SpriteEffects.None,1f);
    }
}