using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class POS : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public static int pos;

  void Start () {
    //Componentを扱えるようにする
      inputField = inputField.GetComponent<InputField> ();
    }

    public void InputText(){
         pos = int.Parse(inputField.text);
         Debug.Log("POS売価は" + pos);
     }

}
