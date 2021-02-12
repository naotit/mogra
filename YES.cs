using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GamepadInput;

public class YES : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any))
        {
            SceneManager.LoadScene("Main");
        }
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any).y == -1) { 
            GameObject.Find("OK").transform.Find("NO").gameObject.SetActive(true);
        GameObject.Find("OK").transform.Find("YES").gameObject.SetActive(false);
        }
    }
}
