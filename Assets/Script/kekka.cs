using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

using UnityEngine.UI;  // 追加しましょう

public class kekka : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int bun;
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
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = dt.Month + "月" +
                  "\n\n" +"2ヶ月" +
                  "\n\n" + "3-" + bun +"ヶ月" +
                  "\n\n" +  bun +"-48ヶ月"+
                  "\n\n" +"48-ヶ月";
      }
}
