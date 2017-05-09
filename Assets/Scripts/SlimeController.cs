using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	public float timeBetweenMove;
	public float timeToMove;
	public float waitToReload;

	private Rigidbody2D myRigidBody;
	private bool isMoving;
	private Vector3 moveDirection;
	private bool isReloading;
	private GameObject thePlayer;

	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;

	// Use this for initialization
	void Start () {
		
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);

		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;

			if (timeToMoveCounter < 0) {
				isMoving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0) {
				isMoving = true;
				timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);

				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0);
			}
		}

		if (isReloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene (scene);
				thePlayer.SetActive (true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Player") {
			thePlayer = other.gameObject;
			other.gameObject.SetActive (false);
			isReloading = true;

		}
	}
}
