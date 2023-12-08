using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class detectBB : MonoBehaviour {

    //Text用のフィールド
    public static int BB;

    //Toggle用のフィールド
    public Toggle toggle;


    public void OnToggleChanged(){
      if (toggle.isOn){
        BB = 1;
      }else{
        BB = 0;
      }
      Debug.Log("光割は" + BB);
    }
}
