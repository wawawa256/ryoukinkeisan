using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class detectCarrier : MonoBehaviour {
    public static int kyaria;
    public Dropdown dropdown;    //操作するオブジェクトを設定する


    public void OnValueChanged() {
        kyaria = dropdown.value;
        Debug.Log("キャリアは" + kyaria);
        
    }
}
