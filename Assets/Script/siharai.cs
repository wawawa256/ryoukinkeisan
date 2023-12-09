using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class siharai : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int goukei;
    public static int amari;
      // 初期化
      void Start () {
        goukei = 0;
        if (bunkatu.n == 1) {
          goukei = POS.pos - wari.waribiki;
        }else{
          goukei = detectatamakin.atamakin*11000+changescene.amari;
        }
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "当日の支払い" + "   " + goukei +
                  "\n"   + "(負ならポイント付与額)" ;
      }

      // 更新
      public void startcalc () {
        goukei = 0;
        if (bunkatu.n == 1) {
          goukei = POS.pos - wari.waribiki + S4.touzitu;
        }else{
          goukei = detectatamakin.atamakin*11000+changescene.amari + S4.touzitu;
        }
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "当日の支払い" + "   " + goukei +
                  "\n"   + "(負ならポイント付与額)" ;

      }
}
