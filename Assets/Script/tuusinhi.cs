using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class tuusinhi : MonoBehaviour {
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
        a=changescene.ryoukin[0,1];    //1
        b=changescene.ryoukin[1,1] - changescene.gakuwari[0];    //2
        c=changescene.ryoukin[2,1] - changescene.gakuwari[0];   //3-7
        d=changescene.ryoukin[2,1] - changescene.gakuwari[1];   //8-13
        e=changescene.ryoukin[2,1];    //14-n
        f=changescene.ryoukin[2,1];    //n-48
        g=changescene.ryoukin[2,1];   //49-
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "通信費" +
                  "\n" + a + //一ヶ月目
                  "\n" + b +   //2ヶ月目
                  "\n" + c +   //3-7ヶ月目
                  "\n" + d +   //8-13ヶ月目
                  "\n" + e +   //14-nヶ月目
                  "\n" + f +   //n-48ヶ月目
                  "\n" + g;    //49-ヶ月目

      }
}
