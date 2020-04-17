using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEnemyStreamBehavior : MonoBehaviour
{
    public float Force = 1000;
    public float Lifespan = 1;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Launchs the enemy in the given direction
    public void Launch(float xv, float yv) {
        if(rb == null) {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.AddForce(new Vector2(xv, yv).normalized * Force);
    }

    void FixedUpdate()
    {
        // Make it despawn
        Lifespan -= Time.fixedDeltaTime;
        if(Lifespan <= 0) {
            Destroy(gameObject);
        }
    }
}
