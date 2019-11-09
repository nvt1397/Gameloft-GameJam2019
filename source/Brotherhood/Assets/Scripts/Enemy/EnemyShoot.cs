using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 projectileSpawn;
    Vector3 spawn;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spawn = Vector3.down*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyShoot();
    }

    public void enemyShoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            projectileSpawn = transform.position + spawn;
            manager.enemyBulletPool.GetObjFromPool(projectileSpawn, Quaternion.identity);
            Debug.Log(manager.enemyBulletPool.getPoolSize());
            currentTime = 0.0f;
        }
    }
}
