using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class detectsumatoku : MonoBehaviour {

    //Text用のフィールド
    public static int sumatoku;

    //Toggle用のフィールド
    public Toggle toggle;


    public void OnToggleChanged(){
      if (toggle.isOn){
        sumatoku = 1;
      }else{
        sumatoku = 0;
      }
      Debug.Log("返却プランは" + sumatoku);
    }
}
