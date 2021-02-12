using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GamepadInput;

public class GameMaster : MonoBehaviour {
    static public int []Score=new int [4];
    private int i;

    // Use this for initialization
    void Start()
    {
        for (i = 0; i < 4; i++)
        {
            Score[i] = 0;
        }

        for (i = 0; i < 4; i++)
        {

            if (PlayerManager.PlayerSwitch[i] == false)
            {
                switch (i + 1)
                {

                    case 1:
                        GameObject.Find("PausableObject").transform.Find("Player1").gameObject.SetActive(false);
                        GameObject.Find("PausableObject").transform.Find("Main Camera").transform.Find("Canvas").transform.Find("ScoreText1").gameObject.SetActive(false);
                        break;
                    case 2:
                        GameObject.Find("PausableObject").transform.Find("Player2").gameObject.SetActive(false);
                        GameObject.Find("PausableObject").transform.Find("Main Camera").transform.Find("Canvas").transform.Find("ScoreText2").gameObject.SetActive(false);
                        break;
                    case 3:
                        GameObject.Find("PausableObject").transform.Find("Player3").gameObject.SetActive(false);
                        GameObject.Find("PausableObject").transform.Find("Main Camera").transform.Find("Canvas").transform.Find("ScoreText3").gameObject.SetActive(false);
                        break;
                    case 4:
                        GameObject.Find("PausableObject").transform.Find("Player4").gameObject.SetActive(false);
                        GameObject.Find("PausableObject").transform.Find("Main Camera").transform.Find("Canvas").transform.Find("ScoreText4").gameObject.SetActive(false);
                        break;





                }

            }

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GamePad.GetButton(GamePad.Button.LeftStick,GamePad.Index.Any)&& GamePad.GetButton(GamePad.Button.RightStick, GamePad.Index.Any))
        {
            SceneManager.LoadScene("Title");
        }
        if ( GameObject.Find("PausableObject").GetComponent<Pausable>().pausing == false)
        {
			if (Input.GetKeyDown(KeyCode.Space) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
            {
                GameObject.Find("Canvas2").transform.Find("Pause").gameObject.SetActive(true);
                GameObject.Find("Canvas2").transform.Find("PauseSub").gameObject.SetActive(true);
                GameObject.Find("www").transform.Find("God").gameObject.SetActive(true);
                GameObject.Find("PausableObject").GetComponent<Pausable>().pausing = true;
            }
        }
		else if (Input.GetKeyDown(KeyCode.Space) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
        {
            GameObject.Find("Canvas2").transform.Find("Pause").gameObject.SetActive(false);
            GameObject.Find("Canvas2").transform.Find("PauseSub").gameObject.SetActive(false);
            GameObject.Find("www").transform.Find("God").gameObject.SetActive(false);
            GameObject.Find("PausableObject").GetComponent<Pausable>().pausing = false;
        }



    }
}
