using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class tanmatudai : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "端末代金" +
                  "\n"   + changescene.ryoukin[0,0] +
                  "\n\n" + changescene.ryoukin[1,0] +
                  "\n\n" + changescene.ryoukin[1,0] +
                  "\n\n" + changescene.ryoukin[2,0] +
                  "\n\n" + changescene.ryoukin[3,0];

      }
}
