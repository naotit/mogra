using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GamepadInput;

public class PlayerManager : MonoBehaviour {
    static public bool [] PlayerSwitch= new bool[4];
    static public int NumP;
    static public bool defineFlag;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            PlayerSwitch[i] = false;
        }
        NumP = 0;
        defineFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Text>().text = NumP+"人";

        if (defineFlag == false)//人数確定前
        {
                //  プレイヤー認証完了

                if (NumP > 4)
                {
                    NumP = 4;
                }
            if (PlayerSwitch[0] == false && GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One))
            {
                PlayerSwitch[0] = true;
                GameObject.Find("Cover").transform.Find("1P").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("Text 1").gameObject.SetActive(true);
            NumP++;
            }
            if (PlayerSwitch[1] == false && GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Two))
                {
                    PlayerSwitch[1] = true;
                    GameObject.Find("Cover").transform.Find("2P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 2").gameObject.SetActive(true);
                NumP++;
            }
                if (PlayerSwitch[2] == false && GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Three))
                {
                    PlayerSwitch[2] = true;
                    GameObject.Find("Cover").transform.Find("3P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 3").gameObject.SetActive(true);
                NumP++;
            }
                if (PlayerSwitch[3] == false && GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Four))
                {
                    PlayerSwitch[3] = true;
                    GameObject.Find("Cover").transform.Find("4P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 4").gameObject.SetActive(true);
                NumP++;
            }

            }
     
            //  取り消し処理
            if (defineFlag == false )
            {

                if (PlayerSwitch[0] == true && GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One))
                {
                    PlayerSwitch[0] = false;
                    GameObject.Find("Cover").transform.Find("1P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 1").gameObject.SetActive(false);
                NumP--;
            }
                if (PlayerSwitch[1] == true && GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two))
                {
                    PlayerSwitch[1] = false;
                    GameObject.Find("Cover").transform.Find("2P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 2").gameObject.SetActive(false);
                NumP--;
            }
                if (PlayerSwitch[2] == true && GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Three))
                {
                    PlayerSwitch[2] = false;
                    GameObject.Find("Cover").transform.Find("3P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 3").gameObject.SetActive(false);
                NumP--;
            }
                if (PlayerSwitch[3] == true && GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Four))
                {
                    PlayerSwitch[3] = false;
                    GameObject.Find("Cover").transform.Find("4P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 4").gameObject.SetActive(false);
                NumP--;
            }
            }
            if (GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any) && PlayerManager.NumP != 0)//YES/NOにはいった
            {
                defineFlag = true;
                GameObject.Find("OK").transform.Find("Panel").gameObject.SetActive(true);
                GameObject.Find("OK").transform.Find("NO").gameObject.SetActive(true);
            }
        }
        



    }


/*
 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GamepadInput;

public class PlayerManager : MonoBehaviour {
    static public bool [] PlayerSwitch= new bool[4];
    private int NumP;
    private bool UpStopFlag;
    private bool DownStopFlag;
    static public bool defineFlag;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            PlayerSwitch[i] = false;
        }
        NumP = 1;
        UpStopFlag = false;
        DownStopFlag = false;
        defineFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Text>().text = NumP+"人";

        if (defineFlag == false)//人数確定前
        {
            if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y == 1 && UpStopFlag == false)
            {
                //  プレイヤー認証完了
                UpStopFlag = true;

                NumP++;
                if (NumP > 4)
                {
                    NumP = 4;
                }
                /*
                if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One))
                {
                    PlayerSwitch[0] = true;
                    GameObject.Find("Cover").transform.Find("1P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 1").gameObject.SetActive(true);
                }
                */
                /*
                if (PlayerSwitch[1] == false && NumP == 2)
                {
                    PlayerSwitch[1] = true;
                    GameObject.Find("Cover").transform.Find("2P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 2").gameObject.SetActive(true);
                }
                if (PlayerSwitch[2] == false && NumP == 3)
                {
                    PlayerSwitch[2] = true;
                    GameObject.Find("Cover").transform.Find("3P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 3").gameObject.SetActive(true);
                }
                if (PlayerSwitch[3] == false && NumP == 4)
                {
                    PlayerSwitch[3] = true;
                    GameObject.Find("Cover").transform.Find("4P").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Text 4").gameObject.SetActive(true);
                }

            }
            else if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y == 0)
            {
                UpStopFlag = false;
            }
            //  取り消し処理
            if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y == -1 && DownStopFlag == false)
            {
                //  プレイヤー認証完了
                DownStopFlag = true;

                NumP--;
                if (NumP< 1)
                {
                    NumP = 1;
                }
                /*
                if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One))
                {
                    PlayerSwitch[0] = false;
                    GameObject.Find("Cover").transform.Find("1P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 1").gameObject.SetActive(false);
                }
                */
                /*
                if (PlayerSwitch[1] == true && NumP == 1)
                {
                    PlayerSwitch[1] = false;
                    GameObject.Find("Cover").transform.Find("2P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 2").gameObject.SetActive(false);
                }
                if (PlayerSwitch[2] == true && NumP == 2)
                {
                    PlayerSwitch[2] = false;
                    GameObject.Find("Cover").transform.Find("3P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 3").gameObject.SetActive(false);
                }
                if (PlayerSwitch[3] == true && NumP == 3)
                {
                    PlayerSwitch[3] = false;
                    GameObject.Find("Cover").transform.Find("4P").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Text 4").gameObject.SetActive(false);
                }
            }
            else if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y == 0)
            {
                DownStopFlag = false;
            }

            if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One))//YES/NOにはいった
            {
                defineFlag = true;
                GameObject.Find("OK").transform.Find("Panel").gameObject.SetActive(true);
                GameObject.Find("OK").transform.Find("NO").gameObject.SetActive(true);
            }
        }
        



    }
}

     */