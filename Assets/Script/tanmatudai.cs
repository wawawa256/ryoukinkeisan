using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class tanmatudai : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int a;
    public static int b;
    public static int c;
    public static int d;
    public static int e;
    public static int amarib;
    public static int amaric;
    public static int amari;
    public static int bun;

      // 初期化
      void Start () {
      }

      // 更新
      void Update () {
        Text score_text = score_object.GetComponent<Text> ();
        if ((0 < bunkatu.n ) && (bunkatu.n != 1) && (detectsumatoku.sumatoku != 1)){
            bun = bunkatu.n;
        }else{
            bun = 24;
        }
        a = changescene.ryoukin[0,0];
        b = changescene.ryoukin[1,0];
        d = changescene.ryoukin[2,0];
        e = changescene.ryoukin[3,0];
        if (b < 0) b = 2;
        score_text.text = "端末代金" +
                  "\n"   + changescene.ryoukin[0,0] +
                  "\n\n" + b +
                  "\n\n" + b +
                  "\n\n" + changescene.ryoukin[2,0] +
                  "\n\n" + changescene.ryoukin[3,0];

      }
}
