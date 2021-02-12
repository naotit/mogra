using UnityEngine;
using System.Collections;
using DG.Tweening;
using GamepadInput;
using System.Collections.Generic;

public class Mole2 : MonoBehaviour
{
    public int ID;
    public float Rate;
    public int Grade;
    private bool pause;
    private int time;
    public GameObject explosionPrefab;
    // Use this for initialization
    void Start()
    {
        transform.DOLocalMove(new Vector3(transform.position.x, 1f, transform.position.z), 1f * Rate).SetEase(Ease.InOutQuart);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
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
      

            if (time == (int)100 * Rate)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                GoodBye();
            }


            if (time == (int)200 * Rate)
            { 
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            Dead();

            }


            time++;
        }
 
    }

    void GoodBye()
    {
        transform.DOLocalMove(new Vector3(transform.position.x, -3f, transform.position.z), 1f * Rate).SetEase(Ease.InOutQuart);
    }
    void Dead()
    {


     transform.DOLocalMove(new Vector3(transform.position.x, 1f, transform.position.z), 1f * Rate).SetEase(Ease.InOutQuart);
        time = 0;
    }


}