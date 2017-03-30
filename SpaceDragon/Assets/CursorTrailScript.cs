using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailScript : MonoBehaviour {
    Vector2 cursorInWorldPos;
	// Use this for initialization
	void Start () {
        cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorInWorldPos;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorInWorldPos;
    }
}
