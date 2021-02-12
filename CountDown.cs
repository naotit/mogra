using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {
    static public float time;
    // Use this for initialization
    void Start ()
    {
        GameObject.Find("PausableObject").GetComponent<Pausable>().pausing = true;
        time = 3;

    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time > 2f)
            GetComponent<Text>().text = "　3";
        else if (time > 1f)
            GetComponent<Text>().text = "　2";
        else if (time > 0f)
            GetComponent<Text>().text = "　1";
        else if (time > -1f)
        {
            GetComponent<Text>().text = "Start";
            GameObject.Find("PausableObject").GetComponent<Pausable>().pausing = false;
        }
        else
            Destroy(this.gameObject);
    }
}
