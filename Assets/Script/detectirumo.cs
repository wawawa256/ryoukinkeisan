using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectirumo : MonoBehaviour {
    public static int irumodeta;
    public Dropdown dropdown;    //操作するオブジェクトを設定


    public void OnValueChanged(){
            irumodeta = dropdown.value;
            Debug.Log("irumoのデータは" + irumodeta);
    }


}
