using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOfEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D projectile;
    [SerializeField]
    float moveSpeed = 3f;

    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = Vector2.down * moveSpeed;
    }
   
}
