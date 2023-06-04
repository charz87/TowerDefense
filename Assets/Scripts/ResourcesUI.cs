using UnityEngine;
using UnityEngine.UI;
public class ResourcesUI : MonoBehaviour
{
    public Text resourcesText;
    // Update is called once per frame
    void Update()
    {
        resourcesText.text =PlayerStats.Resources.ToString();
    }
}
