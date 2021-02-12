using UnityEngine;
using System.Collections;
using GamepadInput;

public class Effect : MonoBehaviour
{
    private int time;
    private bool pause;
    public int Life;
    // Use this for initialization
    void Start()
    {
        time = 0;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
            if (Input.GetKeyDown(KeyCode.E) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
            {
                this.GetComponent<ParticleSystem>().Stop();
                pause = true;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
                {
                    this.GetComponent<ParticleSystem>().Play();
                    pause = false;
                }
            }



        if (time > Life)
            Destroy(this.gameObject);
        time++;
    }
}
