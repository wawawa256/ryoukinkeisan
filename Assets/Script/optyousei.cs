using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class optyousei : MonoBehaviour {
    public GameObject score_object = null; // Textオブジェクト
    public static int a;
    public static int b;
    public static int c;
    public static int d;
    public static int e;
    public static int f;
    public static int g;
    public static int ahamoop;
    public static int motihakobi;
    public static int zoryo;
    public static int tuutei;
      // 初期化
      void Start () {
        ahamoop = 0;
        motihakobi = changescene.motihakobi;
        tuutei = changescene.tuutei;
        if (motihakobi == 1) motihakobi = 0;
        zoryo = changescene.zoryo;
        if (zoryo == 1) zoryo = 0;
        if ((detectCarrier.kyaria == 0) && (detectPlan.puran == 3) && (toguru.zoryo == 1)) ahamoop = 1100; //ahamoだけ翌月から金かかる
        Text score_text = score_object.GetComponent<Text> ();
        a=changescene.motihakobi + tuutei;    //1
        b=motihakobi + ahamoop + tuutei;    //2
        c=motihakobi + ahamoop + tuutei;   //3-7
        d=motihakobi + zoryo + tuutei;   //8-13
        e=motihakobi + zoryo + tuutei;    //14-n
        f=motihakobi + zoryo + tuutei;    //n-48
        g=motihakobi + zoryo + tuutei;   //49-
        score_text.text ="OP料金" +
                  "\n" + a +  //初月
                  "\n" + b +                           //2ヶ月目
                  "\n" + c +                           //3-7ヶ月目
                  "\n" + d +                           //8-13ヶ月目
                  "\n" + e +                           //14-nヶ月目
                  "\n" + f +    //n+1-48ヶ月目
                  "\n" + g;     //49-ヶ月目

      }

      // 更新
      public void opkeisan () {
        ahamoop = 0;
        motihakobi = changescene.motihakobi;
        tuutei = changescene.tuutei;
        if (motihakobi == 1) motihakobi = 0;
        zoryo = changescene.zoryo;
        if (zoryo == 1) zoryo = 0;
        if ((detectCarrier.kyaria == 0) && (detectPlan.puran == 3) && (toguru.zoryo == 1)) ahamoop = 1980; //ahamoだけ翌月から金かかる
        Text score_text = score_object.GetComponent<Text> ();
        a=changescene.motihakobi + ahamoop + tuutei + S4.getugaku;    //1
        b=motihakobi + ahamoop + tuutei + S4.getugaku;    //2
        c=motihakobi + ahamoop + tuutei + S4.getugaku;   //3-7
        d=motihakobi + zoryo + tuutei + S4.getugaku;   //8-13
        e=motihakobi + zoryo + tuutei + S4.getugaku;    //14-n
        f=motihakobi + zoryo + tuutei + S4.getugaku;    //n-48
        g=motihakobi + zoryo + tuutei + S4.getugaku;   //49-
        score_text.text = "OP料金" +
                  "\n" + a +  //初月
                  "\n" + b +                           //2ヶ月目
                  "\n" + c +                           //3-7ヶ月目
                  "\n" + d +                           //8-13ヶ月目
                  "\n" + e +                           //14-nヶ月目
                  "\n" + f +    //n+1-48ヶ月目
                  "\n" + g;     //49-ヶ月目

      }
}
