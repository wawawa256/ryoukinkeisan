using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class detectpay : MonoBehaviour {

    //Text用のフィールド
    public static int pay;

    //Toggle用のフィールド
    public Toggle toggle;


    public void OnToggleChanged(){
      if (toggle.isOn){
        pay = 1;
      }else{
        pay = 0;
      }
      Debug.Log("支払い割引は" + pay);
    }
}
