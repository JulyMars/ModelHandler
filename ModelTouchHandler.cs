using UnityEngine;
using System.Collections;

public class ModelTouchHandler : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	bool startFlag;
	bool ctrlKey;
	Vector3 startPos;
	Vector3 endPos;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			ctrlKey = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			ctrlKey = false;
		}
		if (Input.GetMouseButtonDown (0)) {
			if (!startFlag) {
				startPos = Input.mousePosition;
				startFlag = true;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			startFlag = false;
		}
		if (startFlag) {
			endPos = Input.mousePosition;

			Vector3 deltaPos = endPos - startPos;
			Debug.Log ("deltaPos " + deltaPos);

			if (ctrlKey) {
				gameObject.transform.Rotate (Vector3.right, deltaPos.x * 0.08f, Space.World);
			} else {
				gameObject.transform.Rotate (Vector3.up, deltaPos.y * 0.08f, Space.Self);
			}
		}
	}
}
