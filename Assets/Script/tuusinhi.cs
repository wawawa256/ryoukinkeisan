using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class tuusinhi : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "通信費" +
                  "\n"   + changescene.ryoukin[0,1] +
                  "\n\n" + changescene.ryoukin[1,1] +
                  "\n\n" + changescene.ryoukin[2,1] +
                  "\n\n" + changescene.ryoukin[2,1] +
                  "\n\n" + changescene.ryoukin[2,1];

      }
}
