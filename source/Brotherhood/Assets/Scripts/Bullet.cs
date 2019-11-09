using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Vector2 direction= new Vector2(1, 1);
    
    private Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        
        r2d = GetComponent<Rigidbody2D>();
        //float speedx = speed * Mathf.Cos((transform.rotation.z + 90) * Mathf.Deg2Rad);
        //float speedy = speed * Mathf.Sin((transform.rotation.z + 90) * Mathf.Deg2Rad);
       
        //r2d.velocity = new Vector3(speedx*Mathf.,speedy );
        //transform.eulerAngles = new Vector3(0, 0, getAngleOfVector2(direction) - 90);
        //r2d.velocity = new Vector3(speed*Mathf.Sin(getAngleOfVector2(direction)), speed * Mathf.Sin(getAngleOfVector2(direction)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
