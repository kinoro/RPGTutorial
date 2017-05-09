using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	public float moveSpeed;
	private Vector3 targetPos;

	public static bool doesCameraExist;

	// Use this for initialization
	void Start () {
		if (doesCameraExist) {
			Destroy (transform.gameObject);
		} else {
			DontDestroyOnLoad (transform.gameObject);
			doesCameraExist = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
