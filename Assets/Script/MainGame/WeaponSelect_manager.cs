using UnityEngine;
using System.Collections.Generic;

public class WeaponSelect_manager : MonoBehaviour
{
    [Header("���� �����͵�")]
    public List<Weapon> Weapons = new List<Weapon>();

    [Header("���� ���� ȭ�� obj")]
    public GameObject WeaponSelect_screen;


    private void Start()
    {
        WeaponSelect_screen.SetActive(false);
    }

    public void Show_WeaponSelect()
    {
        Time.timeScale = 0f;
        WeaponSelect_screen.SetActive(true);
    }

    public void WeaponUpgrade()
    {

        Time.timeScale = 1f;
    }
    public void WeaponChange()
    {

        Time.timeScale = 1f;
    }
}
