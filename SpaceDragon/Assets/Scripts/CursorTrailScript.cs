using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailScript : MonoBehaviour {
    Vector2 cursorInWorldPos;
	// Use this for initialization
	void Start () {
        cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorInWorldPos.x, cursorInWorldPos.y, transform.position.z);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorInWorldPos.x, cursorInWorldPos.y, transform.position.z);
    }
}
