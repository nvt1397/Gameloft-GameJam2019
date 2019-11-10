using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunMachine : MonoBehaviour
{
    public float R = 3;
    public float delayTime;
    public float delayTimeShoot;
    public Transform AimTarget;
    public float speedBullet;
    public GameObject bullet;
    public Enemy closestEnemy;
    public Enemy[] allEnemies;
    public float AngleLimited;
    // Start is called before the first frame update
    void Start()
    {
        delayTimeShoot = -1f;
        speedBullet = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        shootTheClosestEnemy();
    }
    void shootTheClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;
        allEnemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy curEnemy in allEnemies)
        {
            float distanceToEnemy = Vector2.Distance(curEnemy.transform.position, this.transform.position);
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                closestEnemy = curEnemy;
                distanceToClosestEnemy = distanceToEnemy;
            }

        }
        if (distanceToClosestEnemy <= R)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            transform.eulerAngles = new Vector3(0, 0, getAngleOfVector2(closestEnemy.transform.position - this.transform.position) - 90);
            if (delayTimeShoot <= 0)
            {
                GameObject clone = Instantiate(bullet, AimTarget.position, AimTarget.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = (AimTarget.up * speedBullet);
                delayTimeShoot = delayTime;
            }
            else { delayTimeShoot -= Time.deltaTime; }

        }


    }
    private float getAngleOfVector2(Vector2 v)
    {

        // return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        return Mathf.Clamp(Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg, AngleLimited, 180 - AngleLimited);
    }
}
