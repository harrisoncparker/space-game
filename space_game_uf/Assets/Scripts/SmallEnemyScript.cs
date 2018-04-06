using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyScript : MonoBehaviour {

	public int verticalSpeed = 8;
	private float vMove;
	private Camera mainCamera;
	private Vector3 stageDimensions;
	private float boundsBottom;

	// Use this for initialization
	void Start () {
		// Get Stage Dimentions
		vMove = 0.1f * verticalSpeed / 10;
		mainCamera = Camera.main;
		// Get Stage Dimentions
		stageDimensions = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		boundsBottom = -stageDimensions.y + 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;

		position.y = position.y - vMove;
		this.transform.position = position;

		if(position.y <= boundsBottom){
			Object.Destroy(this.gameObject);
		}

	}
}
