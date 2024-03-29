﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
	public float baseVelocity;
	public float jumpPower;
	public GroundDetecter groundDetecter;
	[FMODUnity.EventRef]
	public string Walking = "";
	FMOD.Studio.EventInstance walkState;

	private float defaultXScale;
	private new Rigidbody2D rigidbody2D;
	private Animator anim;

	// Start is called before the first frame update
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
		defaultXScale = transform.localScale.x;
		anim = GetComponent<Animator>();
		walkState = FMODUnity.RuntimeManager.CreateInstance(Walking);
		walkState.start();
	}

	// Update is called once per frame
	//Player movement, disabled when the game is won.
	void Update() {
		if (!LevelController.gameWin) {
			rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * baseVelocity, rigidbody2D.velocity.y);
			if (Input.GetButtonDown("Jump") && groundDetecter.onGround)
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
			if (rigidbody2D.velocity.x != 0) {
				walkState.setParameterByName("player_move", 1);
				anim.SetBool("Walking", true);
				transform.localScale = new Vector3(rigidbody2D.velocity.x < 0 ? -defaultXScale : defaultXScale, transform.localScale.y, 1);
			}
			else {
				walkState.setParameterByName("player_move", 0);
				anim.SetBool("Walking", false);
			}
		}
	}
}
