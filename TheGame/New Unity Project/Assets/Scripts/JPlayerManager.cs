using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerManager : MonoBehaviour
{

	public Sprite InvincibleSprite;
	public float DeathRate = 0.333f;
	public float InvincibilityTime = 0.5f;

	Sprite NormalSprite;
	SpriteRenderer sr;
	Collider2D col;
	float invTimer = 0;

	// Start is called before the first frame update
	void Start() {
		// Grab components
		col = GetComponent<Collider2D>();
		sr = GetComponent<SpriteRenderer>();
		// Use the beginning sprite as the default, normal sprite
		NormalSprite = sr.sprite;
	}

	void FixedUpdate() {
		invTimer -= Time.fixedDeltaTime;
		// Set the sprite to normal when we're not invincible
		if(invTimer <= 0) {
			sr.sprite = NormalSprite;
		}
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		// Hurt the player and enable invincibility for a brief period
		if(invTimer <= 0 && collision.gameObject.tag == "Enemy") {
			invTimer = InvincibilityTime;
			// Switch to invincibility sprite
			sr.sprite = InvincibleSprite;
			// Handle death condition
			if(Random.value < DeathRate) {

			}
		}
	}

}
