using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Desnegrizador : MonoBehaviour {
	public GameObject homomen,niño,sperman;
	private Color32 WHITECOLOR = new Color32(255,255,255,1);
	private int caso =PlayerPrefs.GetInt ("boss");
	// Use this for initialization
	void Start () {
	switch (caso) {
		case 1: homomen.GetComponent<Image>().color = WHITECOLOR;break;
		
		case 2:homomen.GetComponent<Image>().color = WHITECOLOR;niño.GetComponent<Image>().color = WHITECOLOR;break;
		

		case 3:homomen.GetComponent<Image>().color = WHITECOLOR;niño.GetComponent<Image>().color = WHITECOLOR;sperman.GetComponent<Image>().color = WHITECOLOR;break;
		
		default: break;

		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
