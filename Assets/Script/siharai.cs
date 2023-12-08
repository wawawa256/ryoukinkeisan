using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class siharai : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int goukei;
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        if (bunkatu.n == 1) {
          goukei = POS.pos - wari.waribiki;
        }else{
          goukei = detectatamakin.atamakin*11000 - changescene.amari;
        }
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "当日の支払い" +
                  "\n"   + goukei ;

      }
}
