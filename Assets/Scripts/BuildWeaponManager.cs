using UnityEngine;

public class BuildWeaponManager : MonoBehaviour
{
    public static BuildWeaponManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    private WeaponBlueprint weaponToBuild;

    public bool CanBuildWeapon { get { return weaponToBuild != null; } }
    public bool HasResources { get { return PlayerStats.Resources >= weaponToBuild.cost; } }

    public void BuildWeaponOnNode(Node node)
    {
        if(PlayerStats.Resources < weaponToBuild.cost)
        {
            Debug.Log("Not enough Resources to Build");
            return;
        }

        PlayerStats.Resources -= weaponToBuild.cost;
        GameObject weaponGO = (GameObject)Instantiate(weaponToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.weapon = weaponGO;

        Debug.Log("Weapon Built!, Resources available: " + PlayerStats.Resources);
    }
    public void SelectWeaponToBuild(WeaponBlueprint weapon)
    {
        weaponToBuild = weapon;
    }



}
