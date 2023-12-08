using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class irumotext : MonoBehaviour {

    public Dropdown dropdown;
    public static int nowplan = 0; //Planと同様のフラグ,最初はeximo

    public void Update(){
      if (nowplan != detectPlan.puran) {
      nowplan = detectPlan.puran;
      if (detectCarrier.kyaria == 0　&& detectPlan.puran != 0 && detectPlan.puran != 3){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("0.5GB");
        list.Add("3GB");
        list.Add("6GB");
        list.Add("9GB");
        dropdown.AddOptions(list);  //新しく要素のリストを設定する
        dropdown.value = 0;         //デフォルトを設定(0～n-1)
      }else{
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        dropdown.AddOptions(list);  //新しく要素のリストを設定する
        dropdown.value = 0;         //デフォルトを設定(0～n-1)
      }
}
}
}
