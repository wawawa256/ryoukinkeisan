using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class bunkatu : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public static int n;

  void Start () {
    //Componentを扱えるようにする
      inputField = inputField.GetComponent<InputField> ();
      n = 24;
    }

    public void InputText(){
         n = int.Parse(inputField.text);
         Debug.Log("分割数は" + n);
     }

}
