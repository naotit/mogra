using UnityEngine;
using System.Collections;

public class RototeUFO : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 1f, 0.5f);
    }
}
