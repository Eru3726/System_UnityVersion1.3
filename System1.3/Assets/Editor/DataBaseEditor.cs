using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataBaseEditor : EditorWindow
{
    /// <summary>
    /// エディタの作成
    /// </summary>
    [MenuItem("Editor/GoogleSpreadSheetEditor")]
    private static void Create()
    {
        // 生成
        DataBaseEditor window = GetWindow<DataBaseEditor>("GoogleSpreadSheetEditor");
        // 最小サイズ設定
        window.minSize = new Vector2(240, 240);
    }

    //パス


    //スクロール
    private Vector2 scrollPos;

    /// <summary>
    /// レイアウト
    /// </summary>
    private void OnGUI()
    {
        using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPos, GUILayout.Height(position.size.y)))
        {
            scrollPos = scrollView.scrollPosition;

            Color defaultColor = GUI.backgroundColor;

            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.magenta;

                    // 書き込みボタン
                    if (GUILayout.Button("データ反映"))
                    {
                        //読み込み
                        Load load = new Load();
                        load.DataLoad();

                        // エディタを最新の状態にする
                        AssetDatabase.Refresh();
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }

            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.green;

                    // 書き込みボタン
                    if (GUILayout.Button("シートを開く"))
                    {
                        string sheetURL = "https://docs.google.com/spreadsheets/d/1vr8VyfVVljjuivK-7xWlzGjb2FkDj8xRFXQhiYROego/edit?usp=sharing";
                        Application.OpenURL(sheetURL);
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }
        }
    }
}

class Load
{
    GeneralParameter generalParameter;
    string GeneralParameter_PATH = "Assets/Resources/GeneralParameter.asset";
    string gasUrl = "https://script.google.com/macros/s/AKfycbxPNZ55uREmAdtvbiR6gUnKN3O3M4tchRBwuFq85mDV2CrKepif7SQqwNNb6Wg2nwrH5g/exec";

    public void DataLoad()
    {
        generalParameter = AssetDatabase.LoadAssetAtPath<GeneralParameter>(GeneralParameter_PATH);
        FetchData();
    }

    void FetchData()
    {
        UnityWebRequest req = UnityWebRequest.Get(gasUrl);
        req.SendWebRequest();

        while (!req.isDone)
        {
            // リクエストが完了するのを待機
        }

        if (IsWebRequestSuccessful(req))
        {
            var data = JsonUtility.FromJson<WebData>(req.downloadHandler.text);
            generalParameter.param_0 = (int)float.Parse(data.key_0);
            generalParameter.param_1 = float.Parse(data.key_1);
        }
        else
        {
            Debug.Log("error");
        }
    }

    bool IsWebRequestSuccessful(UnityWebRequest req)
    {
        return req.result != UnityWebRequest.Result.ProtocolError &&
               req.result != UnityWebRequest.Result.ConnectionError;
    }
}
