using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GamepadInput;

public class Tutorial : MonoBehaviour
{
    private int page_num;
    private bool[] page = new bool[4];
    // Use this for initialization
    void Start()
    {
        for(int i=0;i<4; i++)
        {
            page[i] = false;
        }
        GameObject.Find("Canvas").transform.Find("RawImage (4)").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("RawImage (3)").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("RawImage (2)").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("RawImage (1)").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("RawImage").gameObject.SetActive(true);
        page_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(page_num) { 
        case 0:
                break;
        case 1:
                GameObject.Find("Canvas").transform.Find("RawImage").gameObject.SetActive(page[0]);
                if (page[0] == true)
                {
                    page[0] = false;
                }
                else
                {
                    //page[0] = true;
                }
                break;
        case 2:
                GameObject.Find("Canvas").transform.Find("RawImage (1)").gameObject.SetActive(page[1]);
                if (page[1] == true)
                {
                    page[1] = false;
                }
                else
                {
                    //page[1] = true;
                }
                break;
        case 3:
                GameObject.Find("Canvas").transform.Find("RawImage (2)").gameObject.SetActive(page[2]);
                if (page[2] == true)
                {
                    page[2] = false;
                }
                else
                {
                    //page[2] = true;
                }
                break;
        case 4:
                GameObject.Find("Canvas").transform.Find("RawImage (3)").gameObject.SetActive(page[3]);
                if (page[3] == true)
                {
                    page[3] = false;
                }
                else
                {
                    //page[3] = true;
                }
                break;
        default:
                SceneManager.LoadScene("Select");
                break;
    }
        if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any))
        {
            page_num++;
        }
        if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Any))
        {
            //page_num--;
        }
    }
}
