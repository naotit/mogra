using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
    public  bool Collision_detection=false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {

        if (/*!on_damage &&*/  collider.gameObject.name == "HanmerHead")
        {
            // hpbar.gameObject.SendMessage("onDamage", 10);
            Collision_detection = true;
            //transform.localEulerAngles.x
        }

    }
}
