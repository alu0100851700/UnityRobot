using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float speed = 0.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			transform.Translate (
				-Input.touches [0].deltaPosition.x * speed,
				-Input.touches [0].deltaPosition.y * speed,
				0);
		}
		if (Input.touchCount == 2) {
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			transform.Translate (0,0,
				deltaMagnitudeDiff * speed);
		}
	}
}
