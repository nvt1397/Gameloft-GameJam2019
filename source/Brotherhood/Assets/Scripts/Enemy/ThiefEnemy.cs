using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefEnemy : Enemy
{ 
    public Rigidbody2D enemy;

    Vector3 direction, target;

    [SerializeField]
    float time = 20f;

    public Transform tree;
    Vector3 startPos;

    public float moveSpeed = 2f;
    bool isHit = true;

    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        startPos = enemy.transform.position;
        target = new Vector3(tree.position.x, tree.position.y + 5);
    }

    private void FixedUpdate()
    {
        if (isHit)
        {
            moveEnemy(tree);
        }
        else
        {
            StartCoroutine(Comeback(time));
        }
    }
    IEnumerator Comeback(float timer)
    {

        yield return new WaitForSeconds(timer);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos, moveSpeed * Time.deltaTime);

    }
    public void moveEnemy(Transform tree)
    {
        direction = (target - transform.position).normalized;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, moveSpeed * Time.deltaTime);
        if (Mathf.Approximately(tree.position.x, enemy.position.x))
        {
            isHit = false;
        }
    }
}
