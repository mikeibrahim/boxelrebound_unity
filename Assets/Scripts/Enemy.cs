using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

	private void OnCollisionEnter(Collision col) {
		if (col.gameObject.GetComponent<Player>()) {
			print("Hit Player");
			col.gameObject.GetComponent<Player>().Die();
		}
		print("Hit Something");
    }
}
