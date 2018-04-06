using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// PUBLIC
	public int horrizontalSpeed;
	public int verticalSpeed;
	public GameObject ammo;
	public float fireRate = 2;
	// PRIVATE
	private float shootCoolDown;
	private string gunToFire;
	private Vector3 rightGunPosition;
	private Vector3 leftGunPosition;
	private Stage stage;
	private MoveController moveController;
	// Use this for initialization
	void Start () {
		// cache move controller
		moveController = new MoveController();
		// Init stage
		stage = new Stage();
		// Cool Weapons
		InvokeRepeating("CoolWeapons", 0.000001f, 0.01f * Time.deltaTime);
		// Set first gun
		gunToFire = "right";
	}
	void InitiateGuns(){
		// Right Gun
		rightGunPosition = this.transform.position;
		rightGunPosition.x = rightGunPosition.x + 0.2f;
		rightGunPosition.y = rightGunPosition.y + 0.05f;
		// Left Gun
		leftGunPosition = this.transform.position;
		leftGunPosition.x = leftGunPosition.x - 0.2f;
		leftGunPosition.y = leftGunPosition.y + 0.05f;
	}
	// Update is called once per frame
  	void Update () {
		Vector3 position = this.transform.position;
		
		if (Input.GetKey (KeyCode.D) && position.x < stage.bounds["right"]) {
			moveController.MoveObject(
				this.transform,
				Vector3.right,
				horrizontalSpeed
			);
		}

		if (Input.GetKey (KeyCode.A) && position.x > stage.bounds["left"]) {
			moveController.MoveObject(
				this.transform,
				Vector3.left,
				horrizontalSpeed
			);
		}

		if (Input.GetKey (KeyCode.W) && position.y < stage.bounds["top"]) {
			moveController.MoveObject(
				this.transform,
				Vector3.up,
				verticalSpeed
			);
		}

		if (Input.GetKey (KeyCode.S) && position.y > stage.bounds["bottom"]) {
			moveController.MoveObject(
				this.transform,
				Vector3.down,
				verticalSpeed
			);
		}

		if (Input.GetKey (KeyCode.Space)) {
			if(shootCoolDown <= 0){
				PlayerShoots();
			} 
		}

	}
	void CoolWeapons () {
		shootCoolDown -= 0.01f;
	} 
	void PlayerShoots () {
		shootCoolDown = fireRate;
		// initiate guns
		InitiateGuns();
		if(gunToFire == "right"){
			Instantiate (ammo, rightGunPosition, Quaternion.identity);
			gunToFire = "left";
		} else if(gunToFire == "left") {
			Instantiate (ammo, leftGunPosition, Quaternion.identity);
			gunToFire = "right";
		}
	}
}
