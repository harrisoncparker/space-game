using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage {
    // PUBLIC
    public Dictionary<string, float> bounds;
    // PRIVATE
    private Camera mainCamera;
	private Vector3 stageDimensions;
    // Constructor
    public Stage(){
        // Set main camera
        mainCamera = Camera.main;
		// Set Stage Dimentions
		stageDimensions = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        // init bounds
        bounds = new Dictionary<string, float>();
        // Set bounds
        bounds.Add("right", stageDimensions.x - 0.8f);
        bounds.Add("left", -stageDimensions.x + 0.8f);
        bounds.Add("top", stageDimensions.y - 0.5f);
        bounds.Add("bottom", -stageDimensions.y + 0.5f);
    }
}