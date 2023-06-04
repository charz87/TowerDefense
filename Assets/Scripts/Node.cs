using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject weapon;

    private Renderer rend;
    private Color initialColor;

    BuildWeaponManager buildWeaponManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;
        buildWeaponManager = BuildWeaponManager.instance;
    }

    private void OnMouseDown()
    {

        if (!buildWeaponManager.CanBuildWeapon)
            return;
        
        if(weapon != null)
        {
            Debug.Log("Cant build here!!");
            return;
        }

        buildWeaponManager.BuildWeaponOnNode(this);

    }

    private void OnMouseEnter()
    {
        if (!buildWeaponManager.CanBuildWeapon)
            return;

        if(buildWeaponManager.HasResources)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = Color.red;
        }
       
    }

    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

}
