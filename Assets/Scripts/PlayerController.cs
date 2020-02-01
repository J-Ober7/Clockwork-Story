﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
	public float baseVelocity;
	public float jumpPower;
	private new Rigidbody2D rigidbody2D;

	// Start is called before the first frame update
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * baseVelocity, rigidbody2D.velocity.y);
		if (Input.GetButtonDown("Jump"))
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
		if (rigidbody2D.velocity.x != 0)
			transform.localScale = new Vector3(rigidbody2D.velocity.x < 0 ? -1 : 1, transform.localScale.y, 1);
	}
}
