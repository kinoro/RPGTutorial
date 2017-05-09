using UnityEngine;
using System.Collections;

public class PlayerStart : MonoBehaviour {

	public Vector2 startDirection;
	private PlayerController player;
	private CameraController cam;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		player.gameObject.transform.position = transform.position;
		player.lastMove = startDirection;

		cam = FindObjectOfType<CameraController> ();
		cam.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, cam.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
