using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {
    private int time;
    static public int winner;
	// Use this for initialization
	void Start () {
        winner = 0;
        int winscore = 0;
        time = 0;
        if (PlayerManager.PlayerSwitch[0] == false)
        {
            GameObject.Find("Canvas").transform.Find("Text").gameObject.SetActive(false);
        }
            else { winner = 1;
            winscore = GameMaster.Score[0];
        }
        if (PlayerManager.PlayerSwitch[1] == false)
        {
            GameObject.Find("Canvas").transform.Find("Text (1)").gameObject.SetActive(false);
        }
        else if (GameMaster.Score[1]>winscore)
        {
            winner = 2;
            winscore = GameMaster.Score[1];

        }
        if (PlayerManager.PlayerSwitch[2] == false) {
            GameObject.Find("Canvas").transform.Find("Text (2)").gameObject.SetActive(false);
        }
        else if (GameMaster.Score[2]>winscore)
        {
            winner = 3;
            winscore = GameMaster.Score[2];

        }
        if (PlayerManager.PlayerSwitch[3] == false)
        {
            GameObject.Find("Canvas").transform.Find("Text (3)").gameObject.SetActive(false);
        }
        else if (GameMaster.Score[3]>winscore)
        {
            winner = 4;
            winscore = GameMaster.Score[3];

        }


    }
	
	// Update is called once per frame
	void Update () {
        if(time > 2){ 
        if (GamePad.GetButtonDown(GamePad.Button.LeftStick,GamePad.Index.Any) || GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any) || GamePad.GetButtonDown(GamePad.Button.LeftShoulder, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.RightShoulder, GamePad.Index.Any) ||
            GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any) || GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Any) || GamePad.GetButtonDown(GamePad.Button.Y, GamePad.Index.Any))
            SceneManager.LoadScene("Title");


        }
        time++;
	}
}
