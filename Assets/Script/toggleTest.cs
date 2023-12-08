using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI系のスクリプトを組むときは以下の追記を忘れずに
using UnityEngine.UI;

public class toggleTest : MonoBehaviour {

    //Text用のフィールド
    public Text text;

    //Toggle用のフィールド
    public Toggle toggle;


    public void OnToggleChanged(){

        //「isOn」はチェックの状態を表すモノ。trueなら「ON」、falseなら「OFF」を表す。
        text.text = toggle.isOn ? "ON" : "OFF";
    }
}
