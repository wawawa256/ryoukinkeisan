using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectPlan : MonoBehaviour {
    public static int puran=0;
    public Dropdown dropdown;    //操作するオブジェクトを設定す


    public void OnValueChanged(){
            puran = dropdown.value;
            Debug.Log("現在のプランは" +puran);
    }


}
