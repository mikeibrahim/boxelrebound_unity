using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    private void OnCollisionEnter(Collision col) {
		if (col.gameObject.GetComponent<Player>()) {
			print("Hit Player");
			col.gameObject.GetComponent<Player>().Die();
		}
		print("Hit Something");
    }
}
