using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public static int Resources;
    public static int Lives;
    public static int Waves;

    public int startResources = 50;
    public int startLives = 20;


    private void Start()
    {
        Resources = startResources;
        Lives = startLives;

        Waves = 0;
    }

}
