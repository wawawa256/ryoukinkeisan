using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class uqhiwari : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int hiwari;
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        if (changescene.yokuuq == 1){
          hiwari = changescene.uqhiwari;
          Text score_text = score_object.GetComponent<Text> ();
          score_text.text = "翌UQ:1日に開通と比べて" + "\n" +"1日あたり" + hiwari +"円高くなる";
        }else{
          hiwari = changescene.uqhiwari;
          Text score_text = score_object.GetComponent<Text> ();
          score_text.text = "";
        }

      }
}
