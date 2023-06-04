using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Weapon Attributes")]
    public float range = 15f;

    [Header("Use Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireTimer = 0f;

    [Header("Use Laser")]
    public bool isLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public int damageOverTime = 30;
    public float slowAmount = .5f;

    [Header("Additional")]
    public string enemyTag = "Enemy";
    public Transform rotatingPart;
    public float turnSpeed = 10f;
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }

        if(nearEnemy != null && shortestDistance <= range)
        {
            target = nearEnemy.transform;
            targetEnemy = nearEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(isLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
                    
            }
            return;
        }
            

        LockTarget();

        if(isLaser)
        {
            Laser();
        }
        else
        {
            if (fireTimer <= 0f)
            {
                Shoot();
                fireTimer = 1f / fireRate;
            }

            fireTimer -= Time.deltaTime;
        }
        
    
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
            

        lineRenderer.SetPosition(0, firePosition.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 direction = firePosition.position - target.position;

        impactEffect.transform.position = target.position + direction.normalized * .5f;

        impactEffect.transform.rotation = Quaternion.LookRotation(direction);
        
    }

    void LockTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookatRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookatRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        Debug.Log("Shoot!!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Chase(target);
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
