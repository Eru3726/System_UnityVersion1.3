using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //ネットワーク用のネームスペース


public class DataController : MonoBehaviour
{
    [SerializeField] Text viewText;
    [SerializeField] Button dataButton;　//追加
    [SerializeField] InputField nameField, commentField; //追加

    string url = "https://docs.google.com/spreadsheets/d/1vr8VyfVVljjuivK-7xWlzGjb2FkDj8xRFXQhiYROego/gviz/tq?tqx=out:csv&sheet=test";
    List<string> datas = new List<string>(); //データ格納用のStgring型のList

    //追加　後ほど使う書き込み用URLの変数
    string gasUrl = "https://script.google.com/macros/s/AKfycbyiTvT_Dzq4__w-1v9wQGK74Tu7dm8rS3_vK3XvvQtcc4WYnKcvrTZAtYsNe93CEj5HIQ/exec";

    void Start()
    {
        StartCoroutine(GetData()); //データ取得用のコルーチン

        //追加　ボタンクリック時の挙動
        dataButton.onClick.AddListener(() => StartCoroutine(PostData()));
    }


    IEnumerator GetData()
    {
        //追加　listとtextを空にする
        datas.Clear();
        viewText.text = "";

        using (UnityWebRequest req = UnityWebRequest.Get(url)) //UnityWebRequest型オブジェクト
        {
            yield return req.SendWebRequest(); //URLにリクエストを送る

            if (IsWebRequestSuccessful(req)) //成功した場合
            {
                ParseData(req.downloadHandler.text); //受け取ったデータを整形する関数に情報を渡す
                DisplayText(); //データを表示する
            }
            else                            //失敗した場合
            {
                Debug.Log("error");
            }
        }
    }

    //データを整形する関数
    void ParseData(string csvData)
    {
        string[] rows = csvData.Split(new[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries); //スプレッドシートを1行ずつ配列に格納
        foreach (string row in rows)
        {
            string[] cells = row.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);//一行ずつの情報を1セルずつ配列に格納
            foreach (string cell in cells)
            {
                string trimCell = cell.Trim('"'); //セルの文字列からダブルクォーテーションを除去
                if (!string.IsNullOrEmpty(trimCell)) //除去した文字列が空白でなければdatasに追加していく
                {
                    datas.Add(trimCell);
                }
            }
        }
    }

    //文字を表示させる関数
    void DisplayText()
    {
        foreach (string data in datas)
        {
            viewText.text += data + "\n";
        }
    }

    //リクエストが成功したかどうか判定する関数
    bool IsWebRequestSuccessful(UnityWebRequest req)
    {
        /*プロトコルエラーとコネクトエラーではない場合はtrueを返す*/
        return req.result != UnityWebRequest.Result.ProtocolError &&
               req.result != UnityWebRequest.Result.ConnectionError;
    }

    //送信ボタンをクリックされたときの処理
    IEnumerator PostData()
    {
        Debug.Log("posdata");
        //WWWForm型のインスタンスを生成
        WWWForm form = new WWWForm();

        //それぞれのInputFieldから情報を取得
        string nameText = nameField.text;
        string commentText = commentField.text;

        //値が空の場合は処理を中断
        if (string.IsNullOrEmpty(nameText) || string.IsNullOrEmpty(commentText))
        {
            Debug.Log("empty!");
            yield break;
        }

        //それぞれの値をカンマ区切りでcombinedText変数に代入
        string combinedText = string.Join(",", nameText, commentText);

        //formにPostする情報をvalというキー、値はcombinedTextで追加する
        form.AddField("val", combinedText);

        //UnityWebRequestを使ってGoogle Apps Script用URLにform情報をPost送信する
        using (UnityWebRequest req = UnityWebRequest.Post(gasUrl, form))
        {
            //情報を送信
            yield return req.SendWebRequest();

            //リクエストが成功したかどうかの判定
            if (IsWebRequestSuccessful(req))
            {
                Debug.Log("success");

                //追加　InputFieldを空にする
                ResetInputFields();
            }
            else
            {
                Debug.Log("error");
            }

            //追加　スプレッドシートから情報を取得する
            StartCoroutine(GetData());
        }

        //追加　InputFieldを空にする関数
        void ResetInputFields()
        {
            nameField.text = "";
            commentField.text = "";
        }
    }
}