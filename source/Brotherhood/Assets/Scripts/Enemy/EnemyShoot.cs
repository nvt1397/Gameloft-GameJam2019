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

    public float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spawn = Vector3.down*0.5f;
        currentHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        enemyShoot();
        if(currentHP <= 0)
        {
            Debug.Log(gameObject.name + "Destroyed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentHP -= 3;
        }
        if (collision.gameObject.tag == "MiniBullet")
        {
            currentHP -= 1;
        }
    }
    public void enemyShoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            //projectileSpawn = transform.position + spawn;
            //manager.enemyBulletPool.GetObjFromPool(projectileSpawn, Quaternion.identity);
            //Debug.Log(manager.enemyBulletPool.getPoolSize());
            currentTime = 0.0f;
        }
    }
}
