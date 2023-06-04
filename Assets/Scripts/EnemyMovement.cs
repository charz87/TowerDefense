using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextPoint();
        }

        enemy.speed = enemy.startSpeed;

    }

    void GetNextPoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPoint();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPoint()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        WaveSpawn.EnemiesAlive--;
    }
}
