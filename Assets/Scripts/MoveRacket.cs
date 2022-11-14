using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
	public float RacketSpeed = 100f;
	public string axis = "Vertical";
	void FixedUpdate()
	{
		float v = Input.GetAxisRaw(axis);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * RacketSpeed;
	}
}
