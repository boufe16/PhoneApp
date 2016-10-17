using UnityEngine;
using System.Collections;

public class endRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));

    }

    // Update is called once per frame
    void Update () {
	
	}
}
