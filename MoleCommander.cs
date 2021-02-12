using UnityEngine;
using System.Collections;


public class MoleCommander : MonoBehaviour {
    public float timeOut;
    private float timeTrigger=0f;
    int i=0;
    public GameObject[] Moles= new GameObject[3];
  //  private GameObject PObj;
    //登場させる穴座標
    static public int[] Flag = new int[16];
    Vector3[] HolePositions = new Vector3[]{
      new Vector3  (1.5f,-2,1.5f),
      new Vector3  (1.5f,-2,4.5f),
      new Vector3  (1.5f,-2,-1.5f),
      new Vector3  (1.5f,-2,-4.5f),
      new Vector3 (-1.5f,-2,1.5f),
      new Vector3 (-1.5f,-2,4.5f),
      new Vector3 (-1.5f,-2,-1.5f),
      new Vector3 (-1.5f,-2,-4.5f),
      new Vector3  (4.5f,-2,1.5f),
      new Vector3  (4.5f,-2,4.5f),
      new Vector3  (4.5f,-2,-1.5f),
      new Vector3  (4.5f,-2,-4.5f),
      new Vector3 (-4.5f,-2,1.5f),
      new Vector3 (-4.5f,-2,4.5f),
      new Vector3 (-4.5f,-2,-1.5f),
      new Vector3 (-4.5f,-2,-4.5f),


    };
    enum PController
    {
     Normal = 85,
     Silver = 95,
     Gold = 100,
    };


    // プレハブからインスタンスを生成
    // Use this for initialization
    void Start () {

    //    PObj = GameObject.Find("PausableObject");
    }
	
	// Update is called once per frame
	void Update () {
        i = Random.Range(0, 16);

       /* Debug.Log("TTTTT"+timeTrigger);
        Debug.Log(Time.time);*/
        if (Time.time > timeTrigger)
        {
            timeTrigger = Time.time + timeOut;
            // Do anything
            if (Flag[i] == 0)
            {
                int PersenTage = Random.Range(0,100);
                int MoleGrade = 0;
                if (PersenTage < (int)PController.Normal)
                {
                    MoleGrade = 0;
                }
                else if(PersenTage < (int)PController.Silver)
                {

                    MoleGrade = 1;
                }
                else if (PersenTage < (int)PController.Gold)
                {

                    MoleGrade = 2;
                }

                var Mole =Instantiate(Moles[MoleGrade], HolePositions[i], Quaternion.Euler(-90, 180, 0)) as GameObject;
               // Mole.transform.parent = PObj.transform;
                Mole.GetComponent<Mole>().ID = i;
                Mole.GetComponent<Mole>().Grade = MoleGrade;
				/*
				switch (i+1) {
				case 1:
					Mole.GetComponent<Mole>().Rate = 1;
					break;
				case 2:
					Mole.GetComponent<Mole>().Rate = 1.3f;
					break;
				case 3:
					Mole.GetComponent<Mole>().Rate = 2;
					break;
				}
				*/
                Flag[i] = 1;
            }
         
        }

    }
}
