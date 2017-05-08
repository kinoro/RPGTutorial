using UnityEngine;
using System.Collections;

namespace S3
{
	public class PlayerController : MonoBehaviour 
	{

		public float moveSpeed;

		private Animator animator;
		private bool isPlayerMoving;
		private Vector2 lastMove;

		void Start () 
		{
			animator = GetComponent<Animator> ();
		}
	
		void Update () 
		{
			isPlayerMoving = false;

			var horizontalAxis = Input.GetAxisRaw ("Horizontal");
			var verticalAxis = Input.GetAxisRaw ("Vertical");

			if (horizontalAxis < -0.5f || horizontalAxis > 0.5f) {
				transform.Translate(horizontalAxis * moveSpeed * Time.deltaTime, 0, 0);
				isPlayerMoving = true;
				lastMove = new Vector2 (horizontalAxis, 0);
			}

			if (verticalAxis < -0.5f || verticalAxis > 0.5f) {
				transform.Translate(0, verticalAxis * moveSpeed * Time.deltaTime, 0);
				isPlayerMoving = true;
				lastMove = new Vector2 (0, verticalAxis);
			}

			animator.SetFloat ("MoveX", horizontalAxis);
			animator.SetFloat ("MoveY", verticalAxis);
			animator.SetFloat ("LastMoveX", lastMove.x);
			animator.SetFloat ("LastMoveY", lastMove.y);
			animator.SetBool ("IsPlayerMoving", isPlayerMoving);
		}

	}
}
