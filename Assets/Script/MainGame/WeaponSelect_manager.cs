using UnityEngine;
using System.Collections.Generic;

public class WeaponSelect_manager : MonoBehaviour
{
    [Header("���� �����͵�")]
    public List<Weapon> Weapons = new List<Weapon>();


    public void WeaponUpgrade()
    {

        Time.timeScale = 1f;
    }
    public void WeaponChange()
    {

        Time.timeScale = 1f;
    }
}
