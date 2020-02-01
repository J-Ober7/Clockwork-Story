using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetecter: MonoBehaviour {
	private int groundLayerMask;
	public bool onGround { get; private set; } = false;

	// Start is called before the first frame update
	void Start() {
		groundLayerMask = LayerMask.NameToLayer("Ground");
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if(otherCollider.gameObject.layer == groundLayerMask)
			onGround = true;
	}

	void OnTriggerExit2D(Collider2D otherCollider) {
		if(otherCollider.gameObject.layer == groundLayerMask)
			onGround = false;
	}
}
