using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class goukei : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int a;
    public static int b;
    public static int c;
    public static int d;
    public static int e;
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        a = changescene.ryoukin[0,0]+changescene.ryoukin[0,1]+3850;
        b = tanmatudai.b+changescene.ryoukin[1,1];
        c = tanmatudai.c+changescene.ryoukin[2,1];
        d = changescene.ryoukin[2,0]+changescene.ryoukin[2,1];
        e = changescene.ryoukin[3,0]+changescene.ryoukin[2,1];
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "合計" +
                  "\n"   +a +
                  "\n\n" + b +
                  "\n\n" +c+
                  "\n\n" +d+
                  "\n\n" +e;

      }
}
