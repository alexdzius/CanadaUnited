using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEnemyBehavior : MonoBehaviour
{
	GameObject player;
	public float TrackTime = 1;
	public float TrackForce = 1000;

	Rigidbody2D rb;

	// Start is called before the first frame update
	void Start() {
		// Get the player
		player = GameObject.FindGameObjectWithTag("Player");
		// Apply a random rotation to start with
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-100, 100));
	}

	void FixedUpdate() {
		TrackTime -= Time.fixedDeltaTime;
		if(TrackTime >= 0) {
			// Move the enemy in the direction of the player
			Vector2 force = new Vector2(player.gameObject.transform.position.x - gameObject.transform.position.x,
				player.gameObject.transform.position.y - gameObject.transform.position.y).normalized;
			force *= TrackForce * Time.fixedDeltaTime;
			rb.AddForce(force);
		} else {
			// If the enemy isn't tracking (so it's moving straight) and it's out of bounds, delete it
			if(Mathf.Abs(gameObject.transform.position.x) > 6 || Mathf.Abs(gameObject.transform.position.y) > 9.88) {
				Destroy(gameObject);
			}
		}
	}
}
