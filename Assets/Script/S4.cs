using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4 : MonoBehaviour {
    public static int touzitu;
    public static int getugaku;
    public static int htouzitu;
    public static int hgetugaku;
    public static int itouzitu;
    public Dropdown hoshou;
    public Dropdown ishoku;


    public void hoshouChanged(){
      switch(hoshou.value){
        case 0: //なし
          htouzitu = 0;
          hgetugaku = 0;
        break;
        case 1: //プラチナ一括
          htouzitu = 28800;
          hgetugaku = 0;
        break;
        case 2: //ハイスペ一括
          htouzitu = 23800;
          hgetugaku = 0;
        break;
        case 3: //スタンダ一括
          htouzitu = 22000;
          hgetugaku = 0;
        break;
        case 4://ライト一括
          htouzitu = 14300;
          hgetugaku = 0;
        break;
        case 5: //プラチナ月額
          htouzitu = 0;
          hgetugaku = 1200;
        break;
        case 6: //はいすぺ月額
          htouzitu = 0;
          hgetugaku = 990;
        break;
        case 7: //すたんだ月額
          htouzitu = 0;
          hgetugaku = 920;
        break;
        case 8: //らいと月額
          htouzitu = 0;
          hgetugaku = 550;
        break;
      }
    }

    public void ishokuChanged(){
      switch(ishoku.value){
        case 0 : //なし
          itouzitu = 0;
        break;
        case 1 : //3キャリ安心パック
          itouzitu = 0;
        break;
        case 2: //YUQキャリ安心パック
          itouzitu = 11000;
        break;
        case 3: //mnp移植
          itouzitu = 11000;
        break;
        case 4: //mnp異os移植
          itouzitu = 16500;
        break;
        case 5: //完全移植
          itouzitu = 22000;
        break;
        case 6: //異OS移植
          itouzitu = 27500;
        break;
      }
    }
    public void Update(){
      touzitu = htouzitu + itouzitu;
      getugaku = hgetugaku;
    }


}
