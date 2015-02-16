using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;

	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position; //subtracting the pos of the player from the mouse ois
		difference.Normalize (); //normalzing the vector. Meaning that the sum of the vector will = 1

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; //find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);


	}
}
