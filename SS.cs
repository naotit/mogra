using UnityEngine;
using System.Collections;

public class SS : MonoBehaviour {

    public string Filename;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S)) {
            Application.CaptureScreenshot(Filename+".png");
            Debug.Log(Filename + ".png"+"Captured");
        }
    }
}
