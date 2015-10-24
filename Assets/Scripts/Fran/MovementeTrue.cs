using UnityEngine;
using System.Collections;

public class MovementeTrue : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GetComponent<Animator> ().SetBool ("Move",true);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
