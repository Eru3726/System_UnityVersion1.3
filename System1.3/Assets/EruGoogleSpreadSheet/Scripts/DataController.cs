using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //ネットワーク用のネームスペース
using System;

public class DataController : MonoBehaviour
{
    [SerializeField] Text viewText;
    [SerializeField] GeneralParameter generalParameter;

    string url = "https://docs.google.com/spreadsheets/d/1vr8VyfVVljjuivK-7xWlzGjb2FkDj8xRFXQhiYROego/gviz/tq?tqx=out:csv&sheet=test";
    List<string> datas = new List<string>(); //データ格納用のStgring型のList

    //追加　後ほど使う書き込み用URLの変数
    string gasUrl = "https://script.google.com/macros/s/AKfycbxPNZ55uREmAdtvbiR6gUnKN3O3M4tchRBwuFq85mDV2CrKepif7SQqwNNb6Wg2nwrH5g/exec";

    public static DataController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Load()
    {
        StartCoroutine(GetData());
    }


    IEnumerator GetData()
    {
        //追加　listとtextを空にする
        datas.Clear();
        viewText.text = "";

        using (UnityWebRequest req = UnityWebRequest.Get(gasUrl)) //UnityWebRequest型オブジェクト
        {
            yield return req.SendWebRequest(); //URLにリクエストを送る

            if (IsWebRequestSuccessful(req)) //成功した場合
            {
                var data = JsonUtility.FromJson<WebData>(req.downloadHandler.text);
                generalParameter.param_0 = (int)float.Parse(data.key_0);
                generalParameter.param_1 = float.Parse(data.key_1);
                DisplayText(); //データを表示する
            }
            else                            //失敗した場合
            {
                Debug.Log("error");
            }
        }
    }

    //文字を表示させる関数
    void DisplayText()
    {
        viewText.text += generalParameter.param_0 + "\n" + generalParameter.param_1;
    }

    //リクエストが成功したかどうか判定する関数
    bool IsWebRequestSuccessful(UnityWebRequest req)
    {
        /*プロトコルエラーとコネクトエラーではない場合はtrueを返す*/
        return req.result != UnityWebRequest.Result.ProtocolError &&
               req.result != UnityWebRequest.Result.ConnectionError;
    }
}

[Serializable]
public class WebData
{
    public string key_0;
    public string key_1;
}