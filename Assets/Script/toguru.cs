using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class toguru : MonoBehaviour {

    //Text用のフィールド
    public static int motihakobi;
    public static int zoryo;

    //Toggle用のフィールド
    public Toggle mail;
    public Toggle zoryoOP;


    public void mailchange(){
      if (mail.isOn){
        motihakobi = 1;
      }else{
        motihakobi= 0;
      }
      Debug.Log("メールオプションは" + motihakobi);
    }

    public void zoryochange(){
      if (zoryoOP.isOn){
        zoryo = 1;
      }else{
        zoryo= 0;
      }
      Debug.Log("増量オプションは" + zoryo);
    }

}
