using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        
        r2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

    }

}
