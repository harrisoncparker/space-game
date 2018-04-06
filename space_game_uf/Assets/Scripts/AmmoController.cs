using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour {
	// PUBLIC
	public int verticalSpeed = 5;
	public int damage;
	// PRIVATE
	private float vMove;
	private Stage stage;
	// Use this for initialization
	void Start () {
		// Init stage
		stage = new Stage();
		// Get Stage Dimentions
		vMove = 0.1f * verticalSpeed / 10;
	}
	// Update is called once per frame
	void Update () {
		// get current position
		Vector3 position = this.transform.position;
		// move up at set speed
		position.y = position.y + vMove;
		this.transform.position = position;
		// destroy if off screen
		if(position.y >= stage.bounds["top"]){
			Object.Destroy(this.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D other) {
		GameObject objectHit = other.gameObject;
		DamageController damageController = objectHit.GetComponent<DamageController>();
		if(damageController is DamageController){
			damageController.takeDamage(damage);
			this.destroySelf();
		}
	}
	private void destroySelf ()
	{
		Object.Destroy(this.gameObject);
	}
}
