using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.SceneManagement;

public class NO : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PlayerManager.NumP);
        if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any))
        {
            PlayerManager.defineFlag = false;
            GameObject.Find("OK").transform.Find("Panel").gameObject.SetActive(false);
            GameObject.Find("OK").transform.Find("NO").gameObject.SetActive(false);
        }
        if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any).y == 1)
        {
            GameObject.Find("OK").transform.Find("YES").gameObject.SetActive(true);
            GameObject.Find("OK").transform.Find("NO").gameObject.SetActive(false);
        }
    }
}
