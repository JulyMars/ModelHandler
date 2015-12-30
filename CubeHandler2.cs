using UnityEngine;
using System.Collections;

public class CubeHandler : MonoBehaviour
{

	float yMinLimit = 0f;
	float yMaxLimit = 90f;

	float x = 0f;
	float y = 0f;



	// Use this for initialization
	void Start ()
	{
		var angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;
		Debug.Log(">>>> Start x " + x);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			int direction = Input.GetKey (KeyCode.LeftArrow) ? 1 : -1;
			gameObject.transform.Rotate (0,2 * direction, 0, Space.Self);

//			Debug.LogFormat ("{0},{1}   {2},{3}", gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y,
//				gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y);

			Debug.LogFormat ("{0},{1}   {2},{3}", gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y,
				gameObject.transform.localRotation.eulerAngles.x, gameObject.transform.localRotation.eulerAngles.y);
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow)) {
			int direction = Input.GetKey (KeyCode.UpArrow) ? 1 : -1;
			x += 2 * direction;
			if ((x < 0 && direction < 0) || (x > 90 && direction > 0)) {
			} else {
				gameObject.transform.Rotate (2 * direction, 0, 0, Space.World);
			}


//			Debug.LogFormat ("{0},{1}   {2},{3}", gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y,
//				gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y);

			Debug.LogFormat ("{0},{1}   {2},{3}", gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y,
				gameObject.transform.localRotation.eulerAngles.x, gameObject.transform.localRotation.eulerAngles.y);
//			var rotation = Quaternion.Euler (y, 0, 0);
//			transform.rotation = rotation;
		}
		// if () {
		// 	if (gameObject.transform.eulerAngles.x <= 90f && this.transform.eulerAngles.x >= 0f) {
		// 		gameObject.transform.Rotate (2, 0, 0, Space.World);
		// 		if (gameObject.transform.eulerAngles.x > 90f || this.transform.eulerAngles.x < 0f) {
		// 			gameObject.transform.Rotate (-2, 0, 0, Space.World);
		// 		}
		// 	}
		// }
		if (Input.GetMouseButton (1)) {
			gameObject.transform.localRotation = new Quaternion (0, 0, 0, 0);
		}
	}

	void LateUpdate ()
	{
		y = ClampAngle (y, yMinLimit, yMaxLimit);

//		var rotation = Quaternion.Euler (y, 0, 0);
//		transform.rotation = rotation;
	}

	float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}

}