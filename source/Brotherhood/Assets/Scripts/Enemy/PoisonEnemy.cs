using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemy : Enemy
{
    public Rigidbody2D enemy;

    public float maxX = 9f;
    public float minX = -9f;
    public float maxY = 4f;
    public float minY = 2f;
    GameManager manager;
    public float tChange = 0f;
    public float randomX;
    public float randomY;
    public float moveSpeed = 1f;
    float currentHP;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        enemy = GetComponent<Rigidbody2D>();
        currentHP = manager.enemyMaxHp1;
        manager.monsterCount += 1;
    }

    void Update()
    {
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-9f, 9f); // with float parameters, a random float
            randomY = Random.Range(2f, 4.5f); //  between -2.0 and 2.0 is returned
                                              // set a random interval between 0.5 and 1.5
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            randomY = -randomY;
        }

        // make sure the position is inside the borders
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(randomX, randomY, 0f), moveSpeed * Time.deltaTime);
        if (currentHP <= 0)
        {
            manager.monsterCount -= 1;
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
}
