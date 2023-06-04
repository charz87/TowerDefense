using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public WeaponBlueprint weapon1;
    public WeaponBlueprint weapon2;
    public WeaponBlueprint weapon3;

    BuildWeaponManager buildWeaponManager;

    private void Start()
    {
        buildWeaponManager = BuildWeaponManager.instance;
    }
    public void SelectWeapon1()
    {
        Debug.Log("Weapon 1 selected");
        buildWeaponManager.SelectWeaponToBuild(weapon1);
    }

    public void SelectWeapon2()
    {
        Debug.Log("Weapon 2 selected");
        buildWeaponManager.SelectWeaponToBuild(weapon2);
    }

    public void SelectWeapon3()
    {
        Debug.Log("Weapon 3 selected");
        buildWeaponManager.SelectWeaponToBuild(weapon3);
    }
}
