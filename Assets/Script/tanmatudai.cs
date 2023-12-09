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
    public static int f;
    public static int g;
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
        a=changescene.ryoukin[0,0];    //1
        b=changescene.ryoukin[1,0];    //2
        c=changescene.ryoukin[1,0];   //3-7
        d=changescene.ryoukin[1,0];   //8-13
        e=changescene.ryoukin[1,0];    //14-n
        f=changescene.ryoukin[2,0];    //n-48
        g=changescene.ryoukin[3,0];   //49-
        if (b ==2 || b < 0 ){
          if (detectCarrier.kyaria == 1){
              b = 3;
              c = 2;
              d = 2;
              e = 2;
            }else{
              b = 1;
              c = 1;
              d = 1;
              e = 1;
            }
          }
        score_text.text = "端末代金" +
                  "\n" + a +  //初月
                  "\n" + b +                           //2ヶ月目
                  "\n" + c +                           //3-7ヶ月目
                  "\n" + d +                           //8-13ヶ月目
                  "\n" + e +                           //14-nヶ月目
                  "\n" + f +    //n+1-48ヶ月目
                  "\n" + g;     //49-ヶ月目

      }
}
