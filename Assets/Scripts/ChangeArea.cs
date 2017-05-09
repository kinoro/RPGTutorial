using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeArea : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		SceneManager.LoadScene (sceneName);
	}
}
