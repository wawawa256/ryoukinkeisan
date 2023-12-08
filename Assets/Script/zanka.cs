using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class zanka : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public static int zan;

  void Start () {
    //Componentを扱えるようにする
      inputField = inputField.GetComponent<InputField> ();
    }

    public void InputText(){
         zan = int.Parse(inputField.text);
         Debug.Log("残価は" + zan);
     }

}
