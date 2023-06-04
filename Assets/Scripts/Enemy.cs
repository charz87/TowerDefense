using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float startHealth = 100;
    private float health;

    [HideInInspector]
    public float speed;

    

    public int resourceValue = 5;


    [Header("Unity Setting")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Damaging");
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        Debug.Log("Slowing");
        speed = startSpeed * (1f - amount);

    }

    void Die()
    {
        PlayerStats.Resources += resourceValue;
        Destroy(gameObject);
        WaveSpawn.EnemiesAlive--;
    }

    

}
