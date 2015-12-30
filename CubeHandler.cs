using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{

	float yMinLimit = 0f;
	float yMaxLimit = 90f;

	float x = 0f;
	float y = 0f;



	// Use this for initialization
	void Start ()
	{
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Rotate (0, 2, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Rotate (0, -2, 0);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (gameObject.transform.eulerAngles.x <= 90f && this.transform.eulerAngles.x >= 0f) {
				gameObject.transform.Rotate (-2, 0, 0, Space.World);
				if (gameObject.transform.eulerAngles.x > 90f || this.transform.eulerAngles.x < 0f) {
					gameObject.transform.Rotate (2, 0, 0, Space.World);
				}
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (gameObject.transform.eulerAngles.x <= 90f && this.transform.eulerAngles.x >= 0f) {
				gameObject.transform.Rotate (2, 0, 0, Space.World);
				if (gameObject.transform.eulerAngles.x > 90f || this.transform.eulerAngles.x < 0f) {
					gameObject.transform.Rotate (-2, 0, 0, Space.World);
				}
			}
		}
//		if (Input.GetKey (KeyCode.UpArrow)) {
//			if(gameObject.transform.localEulerAngles.x <= 90f && this.transform.localEulerAngles.x >= 0f){
//				gameObject.transform.Rotate (-2, 0, 0, Space.World);
//				if(gameObject.transform.localEulerAngles.x > 90f || this.transform.localEulerAngles.x < 0f){
//					gameObject.transform.Rotate (2, 0, 0, Space.World);
//				}
//			}
//		}
//		if (Input.GetKey (KeyCode.DownArrow)) {
//			if(gameObject.transform.localEulerAngles.x <= 90f && this.transform.localEulerAngles.x >= 0f){
//				gameObject.transform.Rotate (2, 0, 0, Space.World);
//				if(gameObject.transform.localEulerAngles.x > 90f || this.transform.localEulerAngles.x < 0f){
//					gameObject.transform.Rotate (-2, 0, 0, Space.World);
//				}
//			}
//		}
		if (Input.GetMouseButton (1)) {
			gameObject.transform.localRotation = new Quaternion (0, 0, 0, 0);
		}
	}

	void LateUpdate ()
	{
		y = ClampAngle (y, yMinLimit, yMaxLimit);

		var rotation = Quaternion.Euler (y, 0, 0);
		transform.rotation = rotation;
	}

	void rotateGO(){
		y = 
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
