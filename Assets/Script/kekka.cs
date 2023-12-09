using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

using UnityEngine.UI;  // 追加しましょう

public class kekka : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int bun;
    public static int bun1;
  DateTime dt = DateTime.Now;
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        if ((0 < bunkatu.n ) && (bunkatu.n != 1) && (detectsumatoku.sumatoku != 1)){
            bun = bunkatu.n + 1;
        }else{
            bun = 24;
        }
        bun1=bun+1;
        if (bun == 49){
          bun1 = 49;
        }
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "初月" +
                  "\n" +"2ヶ月" +
                  "\n" +"3-7ヶ月" +
                  "\n" +"8-13ヶ月" +
                  "\n" + "14-" + bun +"ヶ月" +
                  "\n" +  bun1 +"-48ヶ月"+
                  "\n" +"49-ヶ月";
      }
}
