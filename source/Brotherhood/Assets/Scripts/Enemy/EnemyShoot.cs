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

    float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spawn = Vector3.down*0.5f;
        currentHP = manager.enemyMaxHp2;
    }

    // Update is called once per frame
    void Update()
    {
        enemyShoot();
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentHP -= manager.mainTurretDmg;
        }
        if (collision.gameObject.tag == "MiniBullet")
        {
            currentHP -= manager.minigunDmg;
        }
    }
    public void enemyShoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            projectileSpawn = transform.position + spawn;
            Instantiate(projectile,projectileSpawn, Quaternion.identity);
            currentTime = 0.0f;
        }
    }
}
