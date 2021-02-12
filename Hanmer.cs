using UnityEngine;
using System.Collections;
using DG.Tweening;
using GamepadInput;

public class Hanmer : MonoBehaviour
{
    public float BangSpeed;
    int RotateHanmer = 0;
    GamePad.Index playerNo;
    int player_num;

    public AudioClip audioClip;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        player_num = gameObject.GetComponentInParent<PlayerController>().player_num;
        switch (player_num)
        {
            case 1:
                playerNo = GamePad.Index.One;
                break;
            case 2:
                playerNo = GamePad.Index.Two;
                break;
            case 3:
                playerNo = GamePad.Index.Three;
                break;
            case 4:
                playerNo = GamePad.Index.Four;
                break;

        }
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            switch (other.gameObject.GetComponent<Mole>().Grade)
            {
                case 0:
                    GameMaster.Score[player_num - 1] += 100;
                    break;
                case 1:
                    GameMaster.Score[player_num - 1] += 500;
                    break;
                case 2:
                    GameMaster.Score[player_num - 1] += 1000;
                    break;

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (GamePad.GetButtonDown(GamePad.Button.A, playerNo) || GamePad.GetButtonDown(GamePad.Button.B, playerNo) ||
            GamePad.GetButtonDown(GamePad.Button.Y, playerNo) || GamePad.GetButtonDown(GamePad.Button.X, playerNo))
        {
            if (GamePad.GetButtonDown(GamePad.Button.A, playerNo))
            {
                RotateHanmer = -90;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (GamePad.GetButtonDown(GamePad.Button.B, playerNo))
            {

                RotateHanmer = 0;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (GamePad.GetButtonDown(GamePad.Button.Y, playerNo))
            {

                RotateHanmer = 180;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (GamePad.GetButtonDown(GamePad.Button.X, playerNo))
            {

                RotateHanmer = 90;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }

        }
        else if (Input.GetKey(KeyCode.UpArrow) || GamePad.GetState(playerNo).LeftStickAxis.y > 0.8 || Input.GetKey(KeyCode.RightArrow) || GamePad.GetState(playerNo).LeftStickAxis.x > 0.8 || Input.GetKey(KeyCode.LeftArrow) || GamePad.GetState(playerNo).LeftStickAxis.x < -0.8 || Input.GetKey(KeyCode.DownArrow) || GamePad.GetState(playerNo).LeftStickAxis.y < -0.8)

        {
            if (Input.GetKey(KeyCode.UpArrow) || GamePad.GetState(playerNo).LeftStickAxis.y > 0.8)
            {
                RotateHanmer = -90;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow) || GamePad.GetState(playerNo).LeftStickAxis.x > 0.8)
            {

                RotateHanmer = 0;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || GamePad.GetState(playerNo).LeftStickAxis.x < -0.8)
            {

                RotateHanmer = 180;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
            if (Input.GetKey(KeyCode.DownArrow) || GamePad.GetState(playerNo).LeftStickAxis.y < -0.8)
            {

                RotateHanmer = 90;
                transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
            }
        }





        if (Input.GetKeyDown(KeyCode.Z) || GamePad.GetButtonDown(GamePad.Button.Back, playerNo)
            || GamePad.GetButtonDown(GamePad.Button.Start, playerNo) || GamePad.GetButtonDown(GamePad.Button.LeftShoulder, playerNo)
            || GamePad.GetButtonDown(GamePad.Button.RightShoulder, playerNo) ||
            GamePad.GetButtonDown(GamePad.Button.A, playerNo) || GamePad.GetButtonDown(GamePad.Button.B, playerNo)
            || GamePad.GetButtonDown(GamePad.Button.X, playerNo) || GamePad.GetButtonDown(GamePad.Button.Y, playerNo))
        {
            transform.DOLocalRotate(new Vector3(0, RotateHanmer, 0), BangSpeed);
            Invoke("Up", BangSpeed);
            audioSource.PlayOneShot(audioClip);
        }
    }
    void Up()
    {
        transform.DOLocalRotate(new Vector3(0, RotateHanmer, 60), BangSpeed);
    }
}
