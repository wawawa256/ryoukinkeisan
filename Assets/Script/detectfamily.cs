using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectfamily : MonoBehaviour {
    public static int family;
    public Dropdown dropdown;    //操作するオブジェクトを設定


    public void OnValueChanged(){
            family = dropdown.value;
            Debug.Log("家族割は" + family);
    }


}
