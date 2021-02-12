using UnityEngine;
using GamepadInput;
using System.Collections;


public class PlayerHead : MonoBehaviour {

    public int player_num;
    
    public bool on_damage = false;       //ダメージフラグ
    private Material material;
    float colorR,colorG,colorB;
    void Start()
    {

      material = gameObject.GetComponent<Renderer>().material;
        colorR = material.color.r;
        colorG = material.color.g;
        colorB = material.color.b;

    }
    void Update()
    {



        if (gameObject.transform.parent.GetComponent<PlayerController>().on_damage)
        {
            on_damage = true;
            OnDamageEffect();
        }
        // ダメージフラグがtrueで有れば点滅させる
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            material.color = new Color(level, level, level, level);
        }



     

    }


    void OnDamageEffect()
    {
        // ダメージフラグON
        on_damage = true;


        // コルーチン開始
        StartCoroutine("WaitForIt");
   
    }

    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        material.color = new Color(colorR, colorG, colorB, 1f);
    }
 
}
