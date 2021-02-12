using UnityEngine;
using System.Collections;
using DG.Tweening;
using GamepadInput;
using System.Collections.Generic;

public class Mole : MonoBehaviour
{
    public int ID;
    public float Rate;
    public int Grade;
    public GameObject explosionPrefab;
    private bool pause;
    private float time;
	private float range=1.9f;//250
    // Use this for initialization
    void Start()
    {
        transform.DOLocalMove(new Vector3(transform.position.x, 1f, transform.position.z), 2f * Rate).SetEase(Ease.InOutQuart);
        //  Invoke("GoodBye", 3f * Rate);
        //  Invoke("Dead", 5f * Rate);
     	time = 0;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause != true)
        {


			if ((int)time == (int)(range * Rate))
            {
                GoodBye();
            }


			if ((int)time == (int)(range*2.5f * Rate))
                Dead();


            if (Input.GetKeyDown(KeyCode.E) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
            {
                DOTween.PauseAll();
                pause = true;
            }

			time+=Time.deltaTime;
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.E) || GamePad.GetButtonDown(GamePad.Button.RightStick, GamePad.Index.Any))
            {
                DOTween.PlayAll();
                pause = false;
            }


        }
    }

    void GoodBye()
    {
        transform.DOLocalMove(new Vector3(transform.position.x, -3f, transform.position.z), 2f * Rate).SetEase(Ease.InOutQuart);
    }
    void Dead()
    {
        MoleCommander.Flag[ID] = 0;
        Destroy(this.gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {

           Instantiate(explosionPrefab, transform.position, transform.rotation);
            Dead();


        }
    }
}