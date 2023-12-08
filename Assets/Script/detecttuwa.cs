using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detecttuwa : MonoBehaviour {
    public static int tuuwa;
    public Dropdown dropdown;    //操作するオブジェクトを設定


    public void OnValueChanged(){
            tuuwa = dropdown.value;
            Debug.Log("通話オプションは" + tuuwa);
    }


}
