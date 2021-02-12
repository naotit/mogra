using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GamepadInput;

public class Title : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (ScoreScript.init_flag = true) {
			Result.winner = 0;
			ScoreScript.init_flag = false;
		}
		if (Input.GetKeyDown(KeyCode.Space)||GamePad.GetButtonDown(GamePad.Button.RightStick,GamePad.Index.Any))
        {
            SceneManager.LoadScene("Tutorial");
        }
		if (Input.GetKeyDown(KeyCode.Escape)||GamePad.GetButtonDown(GamePad.Button.LeftStick, GamePad.Index.Any))
        {
            Application.Quit();
        }

    }
}
