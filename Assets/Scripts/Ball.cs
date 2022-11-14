using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public float speed = 90f;
	public AudioClip ball;
	public AudioClip death;
	public Text leftText;
	public Text rightText;
	public float left = 0;
	public float right = 0;
	void Start()
	{
		GetComponent <Rigidbody2D>().velocity = Vector2.right * speed;
	}
	float hitFactor(Vector2 ballPos, Vector2 racketPos,float racketHeight)
	{
		return (ballPos.y - racketPos.y) / racketHeight;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Racket_left")
		{
			GetComponent <AudioSource>().PlayOneShot(ball);
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(1, y).normalized;
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
		if (col.gameObject.name == "Racket_right")
		{
			GetComponent <AudioSource>().PlayOneShot(ball);
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(-1, y).normalized;
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
		if (col.gameObject.name == "Wall_right")
		{
			GetComponent <AudioSource>().PlayOneShot(death);
			transform.position = new Vector2 (0, 0);
			GetComponent <Rigidbody2D>().velocity = -Vector2.right * speed;
			left += 1;
			leftText.text = $"{left}";
		}
		else if (col.gameObject.name == "Wall_left")
		{
			GetComponent <AudioSource>().PlayOneShot(death);
			transform.position = new Vector2 (0, 0);
			GetComponent <Rigidbody2D>().velocity = Vector2.right * speed;
			right += 1;
			rightText.text = $"{left}";
		}
	}
}
