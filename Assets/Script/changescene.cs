using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class changescene : MonoBehaviour
{
    //変数宣言,定義はコメントに
    public static int n; //端末代金分割数n
    public static int zan; //残価額
    public static int pos; //POS売価
    public static int atamakin;  //頭金有無
    public static int sumatoku; //返却を使うか
    public static int waribiki; //割引額
    public static int pay; //支払い割引があるか
    public static int BB; //光割引があるか
    public static int family; //家族割の内容
    public static int tuuwa; //通話オプション,0なし,1定額ライト,2定額,3月n,4 60歳
    public static int deta; //irumoのデータ量,0から３の段階性,小さい順
    public static int plan; //プラン選択,キャリアごとに異なる
    public static int kyaria; //キャリア選択,0から順にd au s uq y
    public static int tanmatu ; //一月あたりの端末代
    public static int tuusin ; //一月あたりの通信費
    public static int tuutei; //通話オプションによる追加金額
    public static int yuqwari; //uqの料金割引額;
    public static int uqhiwari; //翌uqが遅れるとどのくらい痛いのか?
    public static int amari; //割引多めでポイント溢れたとき(もうそんなことはないんでしょうけどね...)
    public static int motihakobi; //メール持ち運び
    public static int zoryo; //増量オプション
    public static int yokuuq; //翌uqをしてるか確認
    public static int zimute ;//事務手数料
    //以下,各料金プランの基本料金
    public static int eximo;
    public static int irumo;
    public static int irumo05;
    public static int irumo3;
    public static int irumo6;
    public static int irumo9;
    public static int ahamo;
    public static int dhazisuma5;
    public static int dhazisuma10;
    public static int aumax;
    public static int auhazisuma;
    public static int mini;
    public static int toku;
    public static int komi;
    public static int merihari;
    public static int sbhazisuma;
    public static int spuran;
    public static int mpuran;
    public static int lpuran;

    DateTime dt = DateTime.Now; //日割り用日付取得

    //料金を四期間に分けて表示する.分ける区間は→初月,二ヶ月目から返却まで、返却後から端末割賦終わるまで,その後  の四箇所
    //[]の説明として期間、端末or通信料を表す
    public static int[,] ryoukin = new int[4,2];
    //各プランの学割の割引額,5キャリアと期間(半年,一年で場合分け)
    public static int[] gakuwari = new int[2];




    public void change_button()
    {
      //料金計算
      calc();
    }

    void start (){
      tanmatu = 0;
      tuusin = 0;
      zimute = 3850;
      amari = 0;
      gakuwari[0]=0;
      gakuwari[1]=0;
      yokuuq = 0;
    }


    //料金計算関数
    public void calc(){
      //各変数を参照し,代入していく
      n = bunkatu.n; //分割数n
      zan = zanka.zan; //残価額
      pos = POS.pos; //POS売価
      atamakin = detectatamakin.atamakin;  //頭金有無
      sumatoku = detectsumatoku.sumatoku; //返却を使うか
      waribiki = wari.waribiki; //割引額
      pay = detectpay.pay; //支払い割引があるか
      BB = detectBB.BB; //光割引があるか
      family = detectfamily.family; //家族割があるか
      tuuwa = detecttuwa.tuuwa; //通話オプション,0なし,1定額ライト,2定額,3月n,4 60歳
      deta = detectirumo.irumodeta; //irumoのデータ量,0から３の段階性,小さい順
      plan = detectPlan.puran; //プラン選択,キャリアごとに異なる
      kyaria = detectCarrier.kyaria; //キャリア選択,0から順にd au s uq y
      motihakobi = toguru.motihakobi*330; //メール持ち運びの有無
      zoryo = toguru.zoryo;
//      Debug.Log(detectsumatoku.sumatoku);
//    Debug.Log("計算するプランは" + plan);

      //基本料金定義ゾーン
      eximo = 7315;
      irumo05 = 550;
      irumo3 = 2167;
      irumo6 = 2827;
      irumo9 = 3377;
      ahamo = 2970;
      dhazisuma5 = 1815;
      dhazisuma10 = 2695;
      aumax = 7238;
      auhazisuma = 4103;
      mini = 2365;
      toku = 3465;
      komi = 3278;
      merihari = 7425;
      sbhazisuma = 3916;
      spuran = 2365;
      mpuran = 4015;
      lpuran = 5115;


      //変数初期化
      tanmatu = 0;
      tuusin = 0;
      zimute = 3850;
      amari = 0;
      gakuwari[0]=0;
      gakuwari[1]=0;
      yokuuq = 0;
      //端末代金計算ゾーン
      //ポイントのあまりを計算する
      if (sumatoku == 1){
        if (detectCarrier.kyaria == 1){
          amari = pos - zan - atamakin*11000 -waribiki-47;
        }else{
          amari = pos - zan - atamakin*11000 -waribiki-23;
        }

        if (amari > 23){
          amari =0;
        }
    }else{
          if ((pos - waribiki- atamakin*11000) < 0 ) amari = (pos - waribiki- atamakin*11000);

      }


      //初月は端末代はかからない
      tanmatu = 0;
      ryoukin[0,0] = tanmatu;
      //端末代払い終わったあとは,もちろん端末代はかからないので
      tanmatu = 0;
      ryoukin[3,0] = tanmatu;
      //以下は,区間1と2についてである
      //まず返却プランを使うかどうかで分ける
      if (sumatoku == 1){
        //返却使う場合
        //返却前の一ヶ月あたりの料金は(POS売価-頭金-割引-残価)/23となる.表記簡略化のため小数部分はintでまとめる
        tanmatu = (pos -  (atamakin*11000) - waribiki - zan)/ 23 ;
        ryoukin[1,0] = tanmatu;
        //返却期間中は残価/24が一月あたりなので
        tanmatu = zan/24;
        ryoukin[2,0] = tanmatu;
        }else{
        //返却使わない場合
        //nが1,つまり一括のときは端末代は常にかからないので
            if (n==1){
              tanmatu=0;
              ryoukin[1,0]=tanmatu;
              ryoukin[2,0]=tanmatu;
            }else{
              //返却期間とかはないので期間1,2は同じ数字.
              //一月あたりの金額は(POS売価-頭金-割引)/nとなる.
              if (n != 0){ //0で割るとバグるので
              tanmatu=(pos - (atamakin*11000)-waribiki)/n;
              ryoukin[1,0] = tanmatu;
              //通常割賦はn月目で分割終わりなので
              ryoukin[2,0] = 0;
            }
            }

      }

      //通信費計算ゾーン
      switch(kyaria){
        //docomoの場合
        case 0:

          //通話オプションの料金を決める
          switch(tuuwa){
            case 0: //なし
              tuutei = 0;
              break;
            case 1: //5分定額
              tuutei = 880;
              break;
            case 2: //かけ放題
              tuutei = 1980;
              break;
          }
          switch(plan){
            //eximoの場合
            case 0:
              //一ヶ月目はeximoの日割り+通話オプション
              tuusin = (eximo*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
              ryoukin[0,1] = tuusin;
              //二ヶ月目以降は基本料金-家族割-光割ー支払い割+通話オプション代金
              tuusin = eximo - (family*550) - (BB*1100) - (pay*187);
              ryoukin[1,1] = tuusin;
              ryoukin[2,1] = tuusin;
            break;


            //irumoの場合
            case 1:
          //  Debug.Log("irumoだよ");
            //データ量によって料金変化,
              switch(deta){
                case 0:
                irumo=irumo05;
                break;
                case 1:
                irumo=irumo3;
                break;
                case 2:
                irumo=irumo6;
                break;
                case 3:
                irumo=irumo9;
                break;
              }
            //一ヶ月目はirumoの日割り+通話オプション
            tuusin = (irumo*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
            ryoukin[0,1] = tuusin;
            //二ヶ月目以降は基本料金-光割ー支払い割+通話オプション代金,ただしirumo05の場合は割引なし
            if (irumo != 550){
              tuusin = irumo - (BB*1100) - (pay*187);
              ryoukin[1,1] = tuusin;
              ryoukin[2,1] = tuusin;
            }else{
              tuusin = irumo;
              ryoukin[1,1] = tuusin;
              ryoukin[2,1] = tuusin;
            }
            break;


            //eximo→irumoの場合
            case 2:
            switch(deta){
              case 0:
              irumo=irumo05;
              break;
              case 1:
              irumo=irumo3;
              break;
              case 2:
              irumo=irumo6;
              break;
              case 3:
              irumo=irumo9;
              break;
            }
          //一ヶ月目はeximoの1gbまでの料金が満額+通話オプション
          tuusin = 4565; //eximo1GB
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は基本料金-光割ー支払い割+通話オプション代金,ただしirumo05の場合は割引なし
          if (irumo != 550){
            tuusin = irumo - (BB*1100) - (pay*187);
            ryoukin[1,1] = tuusin;
            ryoukin[2,1] = tuusin;
          }else{
            tuusin = irumo;
            ryoukin[1,1] = tuusin;
            ryoukin[2,1] = tuusin;
          }
          break;


          //eximo→ahamoの場合
          case 3:
            //ahamoの増量オプションは1100円
            zoryo = zoryo*1980;
          switch(deta){
            case 0:
            irumo=irumo05;
            break;
            case 1:
            irumo=irumo3;
            break;
            case 2:
            irumo=irumo6;
            break;
            case 3:
            irumo=irumo9;
            break;
          }
        //アハモの場合,カケホが1100円,5分は無料なので,調整する.
        if (tuutei == 880 ) tuutei = 0;
        if (tuutei == 1980)  tuutei = 1100;
        //一ヶ月目はeximoの1gbまでの料金の日割り+通話オプション
        tuusin = (4565*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
        ryoukin[0,1] = tuusin;
        //二ヶ月目以降はahamoなので割引なし
        tuusin = ahamo;
        ryoukin[1,1] = tuusin;
        ryoukin[2,1] = tuusin;

        break;

        //はじすま5gb
        case 4:
          //はじすまの場合,カケホが1100円,5分は無料なので,調整する.
          if (tuutei == 880 ) tuutei = 0;
          if (tuutei == 1980)  tuutei = 1100;
          //一ヶ月目ははじすまの日割り+通話オプション
          tuusin = (dhazisuma5*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は基本料金ー支払い割
          tuusin = dhazisuma5 - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
        break;

        //はじすま10gb
        case 5:
          //はじすまの場合,カケホが1100円,5分は無料なので,調整する.
          if (tuutei == 880 ) tuutei = 0;
          if (tuutei == 1980)  tuutei = 1100;
          //一ヶ月目ははじすまの日割り+通話オプション
          tuusin = (dhazisuma10*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は基本料金ー支払い割
          tuusin = dhazisuma10 - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
        break;
        }
        break;


        //auの場合
        case 1:
        //通話オプションの料金を決める
        switch(tuuwa){
          case 0: //なし
            tuutei = 0;
            break;
          case 1: //5分定額
            tuutei = 880;
            break;
          case 2: //かけ放題
            tuutei = 1980;
            break;
          case 3: //月10分のやつ
            tuutei = 880;
            break;
          case 4: //月5分のやつ
            tuutei = 550;
            break;
          case 5: //over60
            tuutei = 880;
            break;
        }
        switch(plan){
          //使い放題Maxの場合
          case 0:
          //一ヶ月目は使い放題の日割り+通話オプション
          tuusin = (aumax*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は基本料金-家族割-光割ー支払い割+通話オプション代金
          tuusin = aumax - (family*550) - (BB*1100) - (pay*110);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;


          //翌ミニミニの場合
          case 1:
          //翌uqの差分表示をする
          yokuuq = 1;
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1100; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 550; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目は使い放題の日割り+通話オプション
          tuusin = (aumax*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目は,AU使い放題一日+UQ満額-割引ー支払い割+通話オプション代金で計算.実際初日にやったらデータ量少なくてもっと安いかもだけど...
          tuusin = ((aumax)/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1)))+mini - (pay*187);
          ryoukin[1,1] = tuusin;
          uqhiwari = (((aumax)-(mini - (pay*187)))/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1)));
          //三ヶ月目以降は,UQ満額-割引-支払い割+通話オプション
          tuusin = mini -yuqwari - (pay*187);
          ryoukin[2,1] = tuusin;
          break;


          //翌トクトクの場合
          case 2:
          //翌uqの差分表示をする
          yokuuq = 1;
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1100; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 550; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目は使い放題の日割り+通話オプション
          tuusin = (aumax*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目は,AU使い放題一日+UQ満額-割引ー支払い割+通話オプション代金で計算.実際初日にやったらデータ量少なくてもっと安いかもだけど...
          tuusin = ((aumax)/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1))) + toku - (pay*187);
          ryoukin[1,1] = tuusin;
          uqhiwari = (((aumax)-(toku - (pay*187)))/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1)));
          //三ヶ月目以降は,UQ満額-割引-支払い割+通話オプション
          tuusin = toku -yuqwari - (pay*187);
          ryoukin[2,1] = tuusin;
          break;


          //翌コミコミの場合
          case 3:
          //翌uqの差分表示をする
          yokuuq = 1;
          //コミコミの場合,カケホが1100円,5分は無料なので,調整する.
          if (tuutei == 880 ) tuutei = 0;
          if (tuutei == 1980)  tuutei = 1100;
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //一ヶ月目は使い放題の日割り+通話オプション
          tuusin = (aumax*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目は,AU使い放題一日+UQ満額+通話オプション代金で計算.実際初日にやったらデータ量少なくてもっと安いかもだけど...
          //コミコミプランは割引なし！
          tuusin = ((aumax)/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1))) + komi;
          ryoukin[1,1] = tuusin;
          uqhiwari = (((aumax)-komi)/DateTime.DaysInMonth(dt.Year, ((dt.Month%12)+1)));
          //三ヶ月目以降は,UQ満額+通話オプション
          //コミコミプランは割引なし！
          tuusin = komi;
          ryoukin[2,1] = tuusin;
          break;

          //u22応援の場合
          case 4:
          //学割の調整をする.一年間で割引額は変わらないので
          gakuwari[0] = 2838;
          gakuwari[1] = 2838;
          //一ヶ月目はスマホスタートプランの日割り
          tuusin = (auhazisuma*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降はスマホスタートプランが基本,一年は割引があるので通信費表示の方で調整
          tuusin = auhazisuma - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;


        }



        break;



        //softbankの場合
        case 2:
        //家族割が他と違って新みんな家族割っていうのに変わってる、複雑っすね
        if (family == 1){
          family = 660;
        }else{
          if (family == 2){
            family = 1210;
          }else{
            family = 0;
          }
        }

        //通話オプションの料金を決める
        switch(tuuwa){
          case 0: //なし
            tuutei = 0;
            break;
          case 1: //5分定額
            tuutei = 880;
            break;
          case 2: //かけ放題
            tuutei = 1980;
            break;
        }
        switch(plan){
          //メリハリ無制限の場合
          case 0:
          //一ヶ月目はメリハリの日割り+通話オプション
          tuusin = (merihari*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は基本料金-家族割-光割ー支払い割
          tuusin = merihari - family - (BB*1100) - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

          //スマホデビューの場合
          case 1:
          //学割の調整をする.一年間で割引額は変わらないので
          gakuwari[0] = 2838;
          gakuwari[1] = 1188;
          //一ヶ月目はスマホスタートプランの日割り
          tuusin = (sbhazisuma*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降はスマホスタートプランが基本,一年は割引があるので通信費表示の方で調整,sbは多分支払いによる割引はない？
          tuusin = sbhazisuma;
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

        }

        break;


        //UQの場合
        case 3:
        //通話オプションを決める
        switch(tuuwa){
          case 0: //なし
            tuutei = 0;
            break;
          case 1: //5分定額
            tuutei = 880;
            break;
          case 2: //かけ放題
            tuutei = 1980;
            break;
          case 3: //月10分のやつ
            tuutei = 880;
            break;
          case 4: //月5分のやつ
            tuutei = 550;
            break;
          case 5: //over60
            tuutei = 880;
            break;
        }
        switch(plan){
          //ミニミニの場合
          case 0:
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1100; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 550; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目はミニミニの日割り+通話オプション
          tuusin = (mini*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,UQ満額-割引ー支払い割+通話オプション代金で計算.
          tuusin = mini - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;



          //トクトクの場合
          case 1:
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1100; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 550; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目はトクトクの日割り+通話オプション
          tuusin = (toku*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,UQ満額-割引ー支払い割.
          tuusin = toku - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

          //コミコミの場合
          case 2:
          //コミコミの場合,カケホが1100円,5分は無料なので,調整する.
          if (tuutei == 880 ) tuutei = 0;
          if (tuutei == 1980)  tuutei = 1100;
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //一ヶ月目はコミコミの日割り+通話オプション
          tuusin = (komi*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,プラン満額,コミコミなので割引はなし.
          tuusin = komi;
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

          //uq親子応援割
          case 3:
          //コミコミの場合,カケホが1100円,5分は無料なので,調整する.
          if (tuutei == 880 ) tuutei = 0;
          if (tuutei == 1980)  tuutei = 1100;
          //uqの増量OPは550円
          zoryo = zoryo*550;
          //学割の調整をする.一年間で割引額は変わらないので
          gakuwari[0] = 1320;
          gakuwari[1] = 1320;
          //一ヶ月目はコミコミの日割り
          tuusin = (komi*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降はコミコミが基本,一年は割引があるので通信費表示の方で調整
          tuusin = komi;
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;
        }

        break;


        //YMの場合
        case 4:
        //通話オプションを決める
        switch(tuuwa){
          case 0: //なし
            tuutei = 0;
            break;
          case 1: //5分定額
            tuutei = 880;
            break;
          case 2: //かけ放題
            tuutei = 1980;
            break;
          case 3: //月10分のやつ
            tuutei = 880;
            break;
          case 5: //over60
            tuutei = 880;
            break;
        }

        switch(plan){
          //sプランの場合
          case 0:
          //ymの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1100; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 1100; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目はSプランの日割り+通話オプション
          tuusin = (spuran*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,UQ満額-割引ー支払い割+通話オプション代金で計算.
          tuusin = spuran - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;



          //mプランの場合
          case 1:
          //ymの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1650; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 1100; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目はSプランの日割り+通話オプション
          tuusin = (mpuran*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,UQ満額-割引ー支払い割+通話オプション代金で計算.
          tuusin = mpuran - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;



          //sプランの場合
          case 2:
          //ymの増量OPは550円
          zoryo = zoryo*550;
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1650; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 1100; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }

          //一ヶ月目はSプランの日割り+通話オプション
          tuusin = (lpuran*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降は,UQ満額-割引ー支払い割+通話オプション代金で計算.
          tuusin = lpuran - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

          //親子割mの場合
          case 3:
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1650; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 1100; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }
          //ymの増量OPは550円
          zoryo = zoryo*550;
          //学割の調整をする.一年間で割引額は変わらないので
          gakuwari[0] = 1100;
          gakuwari[1] = 1100;
          //一ヶ月目はMプランの日割り
          tuusin = (mpuran*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降はMプランが基本,一年は割引があるので通信費表示の方で調整,yの学割は色々ありき
          tuusin = mpuran - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

          //親子割lの場合
          case 4:
          //家族割と光割の額を決定する
          if (BB == 1){
            yuqwari = 1650; //自宅セット割りがあれば,それが優先
          }else{
            if (family != 0) {
              yuqwari = 1100; //家族がいれば,550円割引
            }else{yuqwari = 0;} //その他は0
          }
          //ymの増量OPは550円
          zoryo = zoryo*550;
          //学割の調整をする.一年間で割引額は変わらないので
          gakuwari[0] = 1100;
          gakuwari[1] = 1100;
          //一ヶ月目はLプランの日割り
          tuusin = (lpuran*(DateTime.DaysInMonth(dt.Year, dt.Month)-dt.Day+1))/DateTime.DaysInMonth(dt.Year, dt.Month);
          ryoukin[0,1] = tuusin;
          //二ヶ月目以降はLプランが基本,一年は割引があるので通信費表示の方で調整,yの学割は色々ありき
          tuusin = lpuran - yuqwari - (pay*187);
          ryoukin[1,1] = tuusin;
          ryoukin[2,1] = tuusin;
          break;

        }


        break;
      }














    }

}
