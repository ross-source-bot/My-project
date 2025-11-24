using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Weapon[] weapons;
    public Weapon equiptWeapon;

    private void Start()
    {
        InitVariables();
    }
    private void Update() ///Load Weapon
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            AddItem(equiptWeapon);
        }

    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[3]; 
    }
}

