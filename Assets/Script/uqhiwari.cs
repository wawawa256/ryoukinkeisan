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
        hiwari = changescene.uqhiwari;
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "翌uq:一日" + hiwari +"円高くなる";

      }
}
