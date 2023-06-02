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
    public static float yTimeFreeze = 1f;
    private static float _time;
    public static float FreezeTime { get; private set; }

    public static void Update(GameTime gameTime)
    {
        _time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (Configurations.IsFreezeTime)
        {
            yTimeFreeze -= TimeFreezeSpeedPerSecond * _time;
        }
        else
        {
            yTimeFreeze+=TimeFreezeSpeedPerSecond * _time;
        }
        yTimeFreeze = Math.Clamp(yTimeFreeze, Min, Max);
        FreezeTime = yTimeFreeze * _time;
    }
}