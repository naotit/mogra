
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class timescript : MonoBehaviour
{
    public float time;
    private int min;
    private int sec;

    public string Filename;

    void Start()
    {
        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();

        min = 0;
        sec = 0;
    }

    void Update()
    {
        //1秒に1ずつ減らしていく
       // if(CountDown.time<0f)
        time -= Time.deltaTime;
        //マイナスは表示しない
        if (time > 0) {
        min = (int)time / 60;
        sec = (int)time % 60;


/*    if((int)time == 115)
            {
                Debug.Log(Application.dataPath);
Application.CaptureScreenshot(Filename);
            }*/

        if(sec<=9)
            GetComponent<Text>().text = (min).ToString()+":"+"0"+ (sec).ToString();
        else
            GetComponent<Text>().text = (min).ToString() + ":"  + (sec).ToString();
        }
        else {

                GameObject.Find("Canvas").transform.Find("Finish").gameObject.SetActive(true);
            if (time < -1)
                SceneManager.LoadScene("Result");
        }
    }
}