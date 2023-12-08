using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class detectatamakin : MonoBehaviour {

    //Text用のフィールド
    public static int atamakin = 1;

    //Toggle用のフィールド
    public Toggle toggle;


    public void OnToggleChanged(){
      if (toggle.isOn){
        atamakin = 1;
      }else{
        atamakin = 0;
      }
      Debug.Log("頭金は" + atamakin);
    }
}
