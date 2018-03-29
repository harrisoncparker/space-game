using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController {
    public void MoveObject(Transform objectToMove, Vector3 direction, float speed) {
        objectToMove.position += direction * speed * Time.deltaTime;
    }

}