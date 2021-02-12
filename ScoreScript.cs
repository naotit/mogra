using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    private Text ScoreText;
    public int p_num;
	public static bool init_flag=false;
	// Use this for initialization
	void Start ()
    {

        ScoreText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Result.winner == p_num)
        {
            ScoreText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            ScoreText.text = p_num + "P:" + GameMaster.Score[p_num - 1].ToString()+"　WIN!";
			init_flag = true;
        }

            else
        {
            ScoreText.text = p_num + "P:" + GameMaster.Score[p_num - 1].ToString();
        }
    }
}
