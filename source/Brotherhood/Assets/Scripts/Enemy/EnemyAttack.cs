using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D enemy;
    public Vector2 dir;
    public float turnSpeed;
    float targetAngle;
    Vector2 currentPos;
    bool play = true;
    Vector2 direction;

    void Start()
    {
        dir = Vector2.up;
        InvokeRepeating("Start1", 0f, 1f);
        enemy = GetComponent<Rigidbody2D>();
    }
    void Start1()
    {
        play = true;
        direction = new Vector2(Random.Range(-9f, 9f), Random.Range(0f, 3f)); //random position in x and y
    }
    void Update()
    {
        currentPos = transform.position;//current position of gameObject
        if (play)
        { //calculating direction
            dir = direction - currentPos;

            dir.Normalize();
            play = false;
        }
        Vector2 target = dir * moveSpeed + currentPos;  //calculating target position
        transform.position = Vector2.Lerp(currentPos, target, Time.deltaTime);//movement from current position to target position
        targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; //angle of rotation of gameobject
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime); //rotation from current direction to target direction
    }
    void OnCollisionEnter2D()
    {

        CancelInvoke();//stop call to start1 method
        direction = new Vector2(Random.Range(-9f, 9f), Random.Range(0f, 3f)); //again provide random position in x and y
        play = true;

    }
    void OnCollisionExit2D()
    {
        InvokeRepeating("Start1", -1f, 1f);
    }


}
