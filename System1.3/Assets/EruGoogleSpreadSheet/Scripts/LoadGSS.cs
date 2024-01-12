using UnityEngine;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EruGSS
{
    public class LoadGSS
    {
        private GeneralParameter generalParameter;
        private PathScriptableObject pathScriptableObject;

        //パスをまとめたスクリプタブルオブジェクトのパス
        private string PathScriptableObject_PATH = "Assets/EruGoogleSpreadSheet/Resources/PathScriptableObject.asset";

        public void DataLoad(string sheetName)
        {
            pathScriptableObject = AssetDatabase.LoadAssetAtPath<PathScriptableObject>(PathScriptableObject_PATH);
            generalParameter = AssetDatabase.LoadAssetAtPath<GeneralParameter>(pathScriptableObject.GeneralParameter_PATH);

            //URLへアクセス
            UnityWebRequest req = UnityWebRequest.Get(pathScriptableObject.GAS_URL + "?sheetName=" + sheetName);
            req.SendWebRequest();

            while (!req.isDone)
            {
                // リクエストが完了するのを待機
            }

            //変数に反映
            if (IsWebRequestSuccessful(req)) ReflectData(JsonUtility.FromJson<WebData>(req.downloadHandler.text));
            //リクエスト失敗
            else Debug.Log("Error Request Failed");
        }

        //リクエストが成功したかどうか判定する関数
        private bool IsWebRequestSuccessful(UnityWebRequest req)
        {
            //プロトコルエラーとコネクトエラーではない場合はtrueを返す
            return req.result != UnityWebRequest.Result.ProtocolError &&
                   req.result != UnityWebRequest.Result.ConnectionError;
        }

        /// <summary>
        /// 変数の反映
        /// </summary>
        /// <param name="data"></param>
        private void ReflectData(WebData data)
        {
            generalParameter.param_0 = (int)float.Parse(data.key_0);
            generalParameter.param_1 = float.Parse(data.key_1);
            generalParameter.param_2 = float.Parse(data.key_2);
            generalParameter.param_3 = float.Parse(data.key_3);
            generalParameter.param_4 = float.Parse(data.key_4);
            Debug.Log("GSS反映完了");
        }
    }
}