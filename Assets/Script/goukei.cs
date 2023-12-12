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
    public static int f;
    public static int g;
      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        a = 3850+tanmatudai.a+tuusinhi.a+optyousei.a;
        b = tanmatudai.b+tuusinhi.b+optyousei.b;
        c = tanmatudai.c+tuusinhi.c+optyousei.c;
        d = tanmatudai.d+tuusinhi.d+optyousei.d;
        e = tanmatudai.e+tuusinhi.e+optyousei.e;
        f = tanmatudai.f+tuusinhi.f+optyousei.f;
        g = tanmatudai.g+tuusinhi.g+optyousei.g;
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "合計(初月には事務手数料3850円込み)" +
                  "\n"   +a + "+前キャリの請求満額" +
                  "\n" + b +
                  "\n" +c+
                  "\n" +d+
                  "\n" +e+
                  "\n" +f+
                  "\n" +g;

      }
}
