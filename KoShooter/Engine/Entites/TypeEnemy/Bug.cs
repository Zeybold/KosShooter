using KosShooter.Items;
using Microsoft.Xna.Framework;

namespace KosShooter;

public class Bug : Enemy
{
    public Bug(Vector2 position) : base(position)
    {
        EmStatus = EnemyStatus.Bug;
        Texture = TextureSource.Enemies[(int)EmStatus];
        Velocity = 40;
        Damage = 50;
        MaxHp = 150;
        CurrentHp = MaxHp;
        DrItSys.AddItem(new AiItemWeaponAmmunition(),0.5f);
        DrItSys.AddItem(new AiItemAidKit(),0.4f);
        DrItSys.AddItem(new AiItemAidKit(45),0.3f);
        DrItSys.AddItem(new AiItemWeaponAmmunition(2),0.15f);
    }
}