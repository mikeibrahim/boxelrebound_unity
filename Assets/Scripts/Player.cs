using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	CharacterController controller;

	private int maxSpeed = 7; 		//SPEED
	float currSpeed;
	private int acceleration = 10;

	private int gravity =80; 		//JUMP
	private int jumpPower = 30;
	private int maxJumps = 1;
	int jumps;
	Vector3 jumpVel;

    private void Start() {
        controller = GetComponent<CharacterController>();
		CameraFollow cam = GameObject.FindObjectOfType<CameraFollow>();
		cam.SetPlayer(this);
    }


    private void Update() {
		#region Jump
		controller.Move(jumpVel * Time.deltaTime);
		if (controller.isGrounded) {
			jumpVel.y = -10f;
			// jumpVel.y = 0;

			if (Input.GetButton("Jump")) { jumpVel.y = jumpPower; }
		} else {
			jumpVel.y -= gravity * Time.deltaTime;
		}
		#endregion
		
		#region Move
        controller.Move(Vector3.right * currSpeed * Time.deltaTime);
		if (controller.velocity.x == 0) {
			currSpeed = 0.5f;
		} else if (currSpeed < maxSpeed) {
			currSpeed += acceleration * Time.deltaTime;
		}
		#endregion

    }

	public int GetMaxSpeed() { return maxSpeed; }

	public void Die() {
		gameObject.SetActive(false);
	}
}