using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEnemySpawner : MonoBehaviour
{
	public GameObject Player;
	public GameObject BasicEnemy;
	public GameObject BeamEnemy;
	public float Difficulty = 1;
	public float MinimumDistance = 3;
	public float BeamRate = 0.1f;

	float timer = 1;

	// Start is called before the first frame update
	void Start() {
	}

	// Generates a random Quaternion rotation
	public static Quaternion randRot() {
		float x, y, dir;
		dir = Random.Range(0, Mathf.PI * 2);
		x = Mathf.Cos(dir);
		y = Mathf.Sin(dir);
		return getRot(x, y);
	}

	// Generates a 2D Quaternion roation based on the direction vector
	static Quaternion getRot(float x, float y) {
		return Quaternion.LookRotation(Vector3.forward, new Vector3(x, y, 0));
	}

	void FixedUpdate() {
		timer -= Time.fixedDeltaTime;
		// Spawns enemies at random intervals based on the difficulty setting
		if(timer <= 0) {
			timer = Random.value / Difficulty * 5;
			float px = Player.transform.position.x;
			float py = Player.transform.position.y;
			// Spawn a certain enemy a certain % of times
			if(Random.value < BeamRate) {
				// Determine spawn position (doesn't use randRot() because we need those numbers)
				float x, y, dir;
				dir = Random.Range(0, Mathf.PI * 2);
				x = Mathf.Cos(dir);
				y = Mathf.Sin(dir);
				// Spawn the enemy and save the direction vector
				Instantiate(BeamEnemy, new Vector3(px, py, 0), getRot(x, y)).GetComponent<JEnemyBeamBehavior>().SetDir(x, y);
			} else {
				// Determine spawn position
				float dist = Random.Range(MinimumDistance, 18);
				float x, y, dir;
				dir = Random.Range(0, Mathf.PI * 2);
				x = Mathf.Cos(dir) * dist + px;
				y = Mathf.Sin(dir) * dist + py;
				// Spawn the enemy
				Instantiate(BasicEnemy, new Vector3(x, y, 0), randRot());
			}
		}
	}
}
