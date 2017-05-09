using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	public float moveSpeed;

	private Animator animator;
	private Rigidbody2D myRigidBody;

	private bool isPlayerMoving;
	public Vector2 lastMove;

	public static bool doesPlayerExist;

	void Start () 
	{
		animator = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();

		if (doesPlayerExist) {
			Destroy (transform.gameObject);
		} else {
			DontDestroyOnLoad (transform.gameObject);
			doesPlayerExist = true;
		}
	}

	void Update () 
	{
		isPlayerMoving = false;

		var horizontalAxis = Input.GetAxisRaw ("Horizontal");
		var verticalAxis = Input.GetAxisRaw ("Vertical");

		if (horizontalAxis < -0.5f || horizontalAxis > 0.5f) {
			// transform.Translate(horizontalAxis * moveSpeed * Time.deltaTime, 0, 0);
			myRigidBody.velocity = new Vector2(horizontalAxis * moveSpeed, myRigidBody.velocity.y);
			isPlayerMoving = true;
			lastMove = new Vector2 (horizontalAxis, 0);
		}

		if (verticalAxis < -0.5f || verticalAxis > 0.5f) {
			// transform.Translate(0, verticalAxis * moveSpeed * Time.deltaTime, 0);
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, verticalAxis * moveSpeed);
			isPlayerMoving = true;
			lastMove = new Vector2 (0, verticalAxis);
		}
			
		if (horizontalAxis > -0.5f && horizontalAxis < 0.5f) {
			myRigidBody.velocity = new Vector2(0 , myRigidBody.velocity.y);
		}

		if (verticalAxis > -0.5f && verticalAxis < 0.5f) {
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
		}

		animator.SetFloat ("MoveX", horizontalAxis);
		animator.SetFloat ("MoveY", verticalAxis);
		animator.SetFloat ("LastMoveX", lastMove.x);
		animator.SetFloat ("LastMoveY", lastMove.y);
		animator.SetBool ("IsPlayerMoving", isPlayerMoving);
	}

}

