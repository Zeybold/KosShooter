using System;
using System.Data;
using Microsoft.Xna.Framework;

namespace KosShooter;

public static class TimeSystem
{
    private const float Min = 0.1f;
    //Min=0.05
    private const float Max = 1f;
    private const float TimeFreezeSpeedPerSecond = Max - Min;
    private static float _timeFreeze = 1f;
    private static float _time;
    public static float FreezeTime { get; private set; }

    public static void Update(GameTime gameTime)
    {
        _time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (Configurations.IsFreezeTime)
        {
            _timeFreeze -= TimeFreezeSpeedPerSecond * _time;
        }
        else
        {
            _timeFreeze+=TimeFreezeSpeedPerSecond * _time;
        }
        _timeFreeze = Math.Clamp(_timeFreeze, Min, Max);
        FreezeTime = _timeFreeze * _time;
    }
}