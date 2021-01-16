using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Camera cam;
	Player player;
	Vector3 cameraPos;
	float fastSpeed;
	float slowSpeed;

    void Start() {
		cam = GetComponent<Camera>();
		// player = GameObject.FindObjectOfType<Player>();
    }

    void Update() {
		if (player) {
			cameraPos = transform.position;
			if (cam.WorldToScreenPoint(player.transform.position).x > Screen.width * 0.25f) {
				// cameraPos.x = player.transform.position.x;
				cameraPos.x += fastSpeed * Time.deltaTime;
			} else {
				cameraPos.x += slowSpeed * Time.deltaTime;
			}
			transform.position = cameraPos;
		}
	}

	public void SetPlayer(Player p) {
		player = p;
		fastSpeed = player.GetMaxSpeed();
		slowSpeed = fastSpeed * 0.66f;
	}
}
