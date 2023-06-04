using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnLocation;

    public float waveTimerate = 5.5f;
    private float timer = 2f;

    public Text waveCountdownText;

    public GameObject gameWonUI;

    private int waveNumber = 1;

    private void Update()
    {

        if (waveNumber == waves.Length && EnemiesAlive <= 0)
        {
            Debug.Log("You Win");
            gameWonUI.SetActive(true);
            this.enabled = false;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }
           
        if(timer <= 0f)
        {
            StartCoroutine(SpawnEnemyWave());
            timer = waveTimerate;
            return;
        }

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", timer);
    }

    IEnumerator SpawnEnemyWave()
    {
        Debug.Log("Wave Coming");

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
        PlayerStats.Waves++;

        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);
        EnemiesAlive++;
    }
}
