using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial used from Brackeys
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
	
	public float speed = 12f;
	public float grav = -9.81f;
	public float jumpHeight = 3f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	void Update(){
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0){
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		if(Input.GetButtonDown("Jump") && isGrounded){
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
		}

		velocity.y += grav * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}
}
