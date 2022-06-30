using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial used from Brackeys
public class MouseCam : MonoBehaviour
{
    public float mouseSens = 1000f;

	public Transform playerBody;

	float xRotation = 0f;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update(){
		float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
