using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            transform.parent.GetComponent<SlotGun>().HaveGun = false;
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            currentHP -= 1;
        }
    }
}
