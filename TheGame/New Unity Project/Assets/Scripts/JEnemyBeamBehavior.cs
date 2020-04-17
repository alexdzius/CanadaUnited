using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEnemyBeamBehavior : MonoBehaviour
{
    public GameObject StreamEnemy;
    public float Lifespan = 2;
    public float LaserTime = 1;
    public int EnemiesPerFixedUpdate = 10;

    Vector3 dir;
    Vector3 perpDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Saves the direction as a vector
    public void SetDir(float x, float y) {
        dir = new Vector3(x, y, 0).normalized;
        perpDir = new Vector3(-y, x, 0).normalized;
    }

    void FixedUpdate()
    {
        Lifespan -= Time.fixedDeltaTime;
        // If we should, spawn a bunch of stream enemies within the beam
        if(Lifespan <= LaserTime) {
            for(int i = 0; i < EnemiesPerFixedUpdate; i++) {
                float locMag = Random.Range(-44, 44);
                float lauMag = Random.value - 0.5f;
                float perpMag = Random.value * 2 - 1;
                float lx = dir.x * lauMag;
                float ly = dir.y * lauMag;
                Instantiate(StreamEnemy, locMag * dir + gameObject.transform.position + perpDir * perpMag, JEnemySpawner.randRot()).GetComponent<JEnemyStreamBehavior>().Launch(lx, ly);
            }
        }
        // Make it despawn
        if(Lifespan <= 0) {
            Destroy(gameObject);
        }
    }
}
