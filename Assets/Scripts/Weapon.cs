using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]

public class Weapon : Item
{
    public GameObject prefab;
    public float range;
    public WeaponStyle weaponStyle;
    public int damage;
    public float firerate;
    public float currentlyEquippedWeapon;
}

public enum WeaponStyle { Gun1, Gun2, Gun3}
