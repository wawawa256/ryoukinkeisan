using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;

public class wari : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public static int waribiki;

  void Start () {
    //Componentを扱えるようにする
      inputField = inputField.GetComponent<InputField> ();
    }

    public void InputText(){
         waribiki = int.Parse(inputField.text);
         Debug.Log("割引額は" + waribiki);
     }

}
