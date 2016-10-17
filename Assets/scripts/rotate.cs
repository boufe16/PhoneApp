using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.RotateBy(gameObject, iTween.Hash("y", 1, "easeType", "linear", "loopType", "loop", "delay",0));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
