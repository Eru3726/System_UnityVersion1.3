using UnityEngine;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EruGSS
{
    public class LoadGSS
    {
        private Sample1Data sample1Data;
        private Sample2Data sample2Data;
        private PathScriptableObject pathScriptableObject;

        public void DataLoad(string pso)
        {
            pathScriptableObject = AssetDatabase.LoadAssetAtPath<PathScriptableObject>(pso);
            sample1Data = AssetDatabase.LoadAssetAtPath<Sample1Data>(pathScriptableObject.DataScriptableObject_PATH[0]);
            sample2Data = AssetDatabase.LoadAssetAtPath<Sample2Data>(pathScriptableObject.DataScriptableObject_PATH[1]);

            //URLへアクセス
            UnityWebRequest req = UnityWebRequest.Get(pathScriptableObject.GAS_URL);
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
            //変数の型によって変える必要あり
            //Sample1シートのデータを反映
            sample1Data.int1Param = (int)float.Parse(data.Sample1_0);              //int型の場合
            sample1Data.float1Param = float.Parse(data.Sample1_1);                 //float型の場合
            sample1Data.string1Param = data.Sample1_2;                             //string型の場合
            sample1Data.bool1Param = data.Sample1_3 == "true" ? true : false;      //bool型の場合

            //Sample2シートのデータを反映
            sample2Data.int2Param = (int)float.Parse(data.Sample2_0);
            sample2Data.float2Param = float.Parse(data.Sample2_1);
            sample2Data.string2Param = data.Sample2_2;
            sample2Data.bool2Param = data.Sample2_3 == "true" ? true : false;

            Debug.Log("GSS反映完了");
        }
    }
}