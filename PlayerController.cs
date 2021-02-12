using UnityEngine;
using GamepadInput;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 12.0F;
    public float gravity = 20.0F;
    public int player_num;
    private Vector3 moveDirection = Vector3.zero;
    GameObject refobj;

    public bool on_damage = false;       //ダメージフラグ
    private Material material;
    float colorR,colorG,colorB;
    public AudioClip audioClip;
    AudioSource audioSource;
    GamePad.Index playerNo;
    void Start()
    {

      material = gameObject.GetComponent<Renderer>().material;
        colorR = material.color.r;
        colorG = material.color.g;
        colorB = material.color.b;

        refobj = gameObject.transform.FindChild("Collision").gameObject;


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
    void Update()
    {

        if (this.transform.position.y<-10) {
            this.transform.position = new Vector3(0, 5, 0);

        }


       

        // ダメージフラグがtrueで有れば点滅させる
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            material.color = new Color(level, level, level, level);
        }



     

      CharacterController controller = GetComponent<CharacterController>();
      if (controller.isGrounded)
      {
          Vector2 playerAxis =GamePad.GetAxis(GamePad.Axis.LeftStick,playerNo);
          moveDirection = new Vector3(playerAxis.x, 0, playerAxis.y);
          moveDirection = transform.TransformDirection(moveDirection);
          moveDirection *= speed;
          //if (Input.GetButton("Jump"))
          //      moveDirection.y = jumpSpeed;

      }
      moveDirection.y -= gravity * Time.deltaTime;
      controller.Move(moveDirection * Time.deltaTime);

        // Use this for initialization
        /*


       if (isGrounded)
     {
         moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
         moveDirection = transform.TransformDirection(moveDirection);
         moveDirection *= speed;
         //if (Input.GetButton("Jump"))
           //  moveDirection.y = jumpSpeed;

     }
     moveDirection.y -= gravity * Time.deltaTime;
     transform.Translate(moveDirection * Time.deltaTime);
  */

    }

    void OnTriggerEnter(Collider collider)
    {
   
        if (refobj.GetComponent<Collision>().Collision_detection==true)
        {
            // hpbar.gameObject.SendMessage("onDamage", 10);
            OnDamageEffect();
            //transform.localEulerAngles.x
        }

    }

    void OnDamageEffect()
    {
        // ダメージフラグON
        on_damage = true;
        // プレイヤーの位置を後ろに飛ばす
        float s = 15f * Time.deltaTime;
        transform.Translate(Vector3.up * s);
        audioSource.PlayOneShot(audioClip);
        // プレイヤーのlocalScaleでどちらを向いているのかを判定
        if (transform.localScale.x >= 0)
        {
            transform.Translate(Vector3.left * s);
        }
        else
        {
            transform.Translate(Vector3.right * s);
        }



        if (transform.localScale.z>= 0)
        {
            transform.Translate(Vector3.forward * s);
        }
        else
        {
            transform.Translate(Vector3.back * s);
        }
        // コルーチン開始
        StartCoroutine("WaitForIt");
   
    }

    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        refobj.GetComponent<Collision>().Collision_detection = false;
        material.color = new Color(colorR, colorG, colorB, 1f);
    }
 
}
