using UnityEngine;
using System.Collections;

public class EffectTime : MonoBehaviour {
    private int time;
    public int et;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if(time>et)
            Destroy(this.gameObject);
        time++;
    }
}
