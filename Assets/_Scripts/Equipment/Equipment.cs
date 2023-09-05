using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//todo
//read from json and scriptable object

public class Equipment : MonoBehaviour
{
    public string name;
    public WeaponType weaponType = WeaponType.NONE;
    public EquipmentWeight equipmentWeight= EquipmentWeight.NONE;

    public float damage = 1;
    public DamageType damageType = DamageType.NONE;
    public FireMode fireMode = FireMode.NONE;
    public int numOfAttacks = 0;
    public float chargeTime = 0;

    public float ammo = 0;
    public ReloadType reloadType = ReloadType.NONE;
    public float cooldown = 0;

    public List<WeaponEffect> weaponEffects = new List<WeaponEffect>();
    public List<StatusEffect> statusEffects= new List<StatusEffect>();

    public List<Transform> damagePoints = new List<Transform>();
    public List<Transform> holdPoints = new List<Transform>();

    public AltFire altFire = AltFire.NONE;
    public Equipment altWeapon = null;

    public void Initialize()
    {
    
    }

    private void Update()
    {

    }

    private void Action1()
    {
        switch(this.fireMode)
        {
            case FireMode.NONE:
            break;

            case FireMode.MELEE:
            break;

            case FireMode.BURST:
            break;

            case FireMode.AUTOMATIC:
            break;

            case FireMode.SEMIAUTO:
            break;

            case FireMode.LOCKON:
            break;

            case FireMode.CHARGE:
            break;

            default:
            break;
        }
    }

    private void Action2()
    {
        switch(this.altFire)
        {
            case AltFire.NONE:
            break;

            case AltFire.HEAVYATTACK:
            break;

            case AltFire.ALTWEAPON:
            break;

            case AltFire.ALTFIREMODE:
            break;

            case AltFire.ZOOM:
            break;

            default:
            break;
        }
    }
}


