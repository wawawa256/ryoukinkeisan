using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plantext : MonoBehaviour {
    public static int puran;
    public static int nowkyaria; //Updateによる選択肢書き換え防止フラグ
    public Dropdown dropdown;    //操作するオブジェクトを設定す

     public void start(){
       nowkyaria = 0;
       //最初はドコモ
       dropdown.ClearOptions();    //現在の要素をクリアする
       List<string> list = new List<string>();
       list.Add("eximo");
       list.Add("irumo");
       list.Add("eximo→irumo");
       list.Add("eximo→ahamo");
       list.Add("U15はじスマ5GB");
       list.Add("U15はじスマ10GB");
       dropdown.AddOptions(list);  //新しく要素のリストを設定する
     }




    public  void Update(){
      if (nowkyaria != detectCarrier.kyaria){  //キャリアが変更した場合のみ動作するフラグ
        nowkyaria = detectCarrier.kyaria; //上記フラグ変更

      //Docomo関連プラン登録場所
      if (detectCarrier.kyaria == 0){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("eximo");
        list.Add("irumo");
        list.Add("eximo→irumo");
        list.Add("eximo→ahamo");
        list.Add("U15はじスマ5GB");
        list.Add("U15はじスマ10GB");
        dropdown.AddOptions(list);  //新しく要素のリストを設定する

      }

      //AU関連プラン登録場所
      if (detectCarrier.kyaria == 1){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("使い放題MAX");
        list.Add("翌ミニミニ");
        list.Add("翌トクトク");
        list.Add("翌コミコミ");
        list.Add("U22スマホ応援割");
        dropdown.AddOptions(list);  //新しく要素のリストを設定する

      }

      //softbank関連プラン登録場所
      if (detectCarrier.kyaria == 2){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("メリハリ無制限");
        list.Add("U22デビュープラン");
        dropdown.AddOptions(list);  //新しく要素のリストを設定する

      }

      //UQ関連プラン登録場所
      if (detectCarrier.kyaria == 3){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("ミニミニ");
        list.Add("トクトク");
        list.Add("コミコミ");
        list.Add("U18親子応援割");
        dropdown.AddOptions(list);  //新しく要素のリストを設定する

      }

      //YM関連プラン登録場所
      if (detectCarrier.kyaria == 4){
        dropdown.ClearOptions();    //現在の要素をクリアする
        List<string> list = new List<string>();
        list.Add("シンプル2 S");
        list.Add("シンプル2 M");
        list.Add("シンプル2 L");
        list.Add("U18親子割 M");
        list.Add("U18親子割 L");        
        dropdown.AddOptions(list);  //新しく要素のリストを設定する

      }



    }
  }


}
