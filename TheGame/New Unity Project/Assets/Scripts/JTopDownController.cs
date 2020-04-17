using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTopDownController : MonoBehaviour {
	// Maximum units per second
	public float Speed = 8;
	// Units per second per second while accelerating
	public float Acceleration = 64;
	// Units per second per second while decelerating
	public float Deceleration = 64;
	// Max X value
	public float MaxX = 0;
	// Min X Value
	public float MinX = 0;
	// Max Y value
	public float MaxY = 0;
	// Min Y Value
	public float MinY = 0;
	// Whether or not borders should be enabled
	public bool Borders = false;

	float xv;
	float yv;

	bool isEnabled = true;

	// Start is called before the first frame update
	void Start() {
		// Apply the scaling once so we don't have to every time we use the variables
		Speed *= Time.fixedDeltaTime;
		Acceleration *= Time.fixedDeltaTime * Time.fixedDeltaTime;
		Deceleration *= Time.fixedDeltaTime * Time.fixedDeltaTime;
	}

	// Enables the script, allowing input and movement
	public void enable() {
		isEnabled = true;
	}

	// Disables the script, disallowing input and freezing movement
	public void disable() {
		isEnabled = false;
	}

	// Getter for reading controller velocity
	public Vector2 getVelocity() {
		return new Vector2(xv, yv);
	}

	// Setter for changing controller velocity
	public void setVelocity(Vector2 vel) {
		xv = vel.x;
		yv = vel.y;
	}

	void FixedUpdate() {
		// Only run if movement is enabled
		if(isEnabled) {
			// Get user movement input
			float moveX = Input.GetAxisRaw("Horizontal");
			float moveY = Input.GetAxisRaw("Vertical");
			Debug.Log("moveY: " + moveY);
			// Normalize the motion vector so we don't get YOTE diagonally
			float len = moveX * moveX + moveY * moveY;
			// If we're accelerating, accelerate. Otherwise, decelerate
			if(len > 0) {
				moveX /= len;
				moveY /= len;
				// Apply the acceleration
				xv += moveX * Acceleration;
				yv += moveY * Acceleration;
				// Enforce the capped speed
				float curVel = Mathf.Sqrt(xv * xv + yv * yv);
				if(curVel > Speed) {
					xv /= curVel / Speed;
					yv /= curVel / Speed;
				}
			} else {
				// Create the normalized deceleration vector
				moveX = -xv;
				moveY = -yv;
				len = Mathf.Sqrt(moveX * moveX + moveY * moveY);
				moveX /= len;
				moveY /= len;
				// Apply the deceleration
				xv += moveX * Deceleration;
				yv += moveY * Deceleration;
				// Stop if we're stopped
				if(Deceleration > len) {
					xv = 0;
					yv = 0;
				}
			}
			// Transform based on current velocity
			transform.position = new Vector3(transform.position.x + xv, transform.position.y + yv, transform.position.z);
			// Enforce the borders if necessary
			if(Borders) {
				if(transform.position.x >= MaxX) {
					// Limit the location on the X axis
					transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);
					// Reset the X velocity
					xv = 0;
				} else if(transform.position.x <= MinX) {
					// Limit the location on the X axis
					transform.position = new Vector3(MinX, transform.position.y, transform.position.z);
					// Reset the X velocity
					xv = 0;
				}
				if(transform.position.y >= MaxY) {
					// Limit the location on the Y axis
					transform.position = new Vector3(transform.position.x, MaxY, transform.position.z);
					// Reset the Y velocity
					yv = 0;
				} else if(transform.position.y <= MinY) {
					// Limit the location on the Y axis
					transform.position = new Vector3(transform.position.x, MinY, transform.position.z);
					// Reset the Y velocity
					yv = 0;
				}
			}
		}
	}
}
