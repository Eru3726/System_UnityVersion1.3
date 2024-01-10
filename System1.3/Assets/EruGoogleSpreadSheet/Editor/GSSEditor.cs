using UnityEngine;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EruGSS
{
    public class GSSEditor : EditorWindow
    {
        /// <summary>
        /// エディタの作成
        /// </summary>
        [MenuItem("Editor/GoogleSpreadSheetEditor")]
        private static void Create()
        {
            // 生成
            GSSEditor window = GetWindow<GSSEditor>("GoogleSpreadSheetEditor");
            // 最小サイズ設定
            window.minSize = new Vector2(240, 240);
        }

        //パス
        private const string Sheet_URL = "https://docs.google.com/spreadsheets/d/1vr8VyfVVljjuivK-7xWlzGjb2FkDj8xRFXQhiYROego/edit?usp=sharing";        //GoogleSpreadSheetのURL

        private string[] Scripts_PATH = { "Assets/EruGoogleSpreadSheet/Scripts/GeneralParameter.cs",    //ScriptableObjectのスクリプトのパス
                                      "Assets/EruGoogleSpreadSheet/Editor/GSSEditor.cs",            //Editorのスクリプトのパス
                                      "Assets/EruGoogleSpreadSheet/Scripts/WebData.cs"              //WebDataのスクリプトのパス
                                    };

        //スクロール
        private Vector2 scrollPos;

        /// <summary>
        /// レイアウト
        /// </summary>
        private void OnGUI()
        {
            using var scrollView = new EditorGUILayout.ScrollViewScope(scrollPos, GUILayout.Height(position.size.y));
            scrollPos = scrollView.scrollPosition;

            Color defaultColor = GUI.backgroundColor;

            //GoogleSpreadSheetを開くボタン
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.green;

                    if (GUILayout.Button("シートを開く"))
                    {
                        //パスのサイトを開く
                        Application.OpenURL(Sheet_URL);
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }

            //変数を追加する場所のスクリプトを開くボタン
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.cyan;

                    if (GUILayout.Button("変数追加"))
                    {
                        for (int i = 0; i < Scripts_PATH.Length; i++)
                        {
                            Object o = AssetDatabase.LoadAssetAtPath(Scripts_PATH[i], typeof(Object)) as Object;
                            if (o != null)
                            {
                                // ファイルを選択(Projectウィンドウでファイルが選択状態になる)
                                Selection.activeObject = o;

                                // ファイルを開く(Visual Studioでファイルが開く)
                                AssetDatabase.OpenAsset(o);
                            }
                        }
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }

            //GoogleSpreadSheetのデータを反映させるボタン
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.magenta;

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
        }
    }

    /// <summary>
    /// データを反映させるクラス
    /// </summary>
    class Load
    {
        private GeneralParameter generalParameter;
        private const string GeneralParameter_PATH = "Assets/EruGoogleSpreadSheet/Resources/GeneralParameter.asset";     //ScriptableObjectのパス
        private const string GAS_URL = "https://script.google.com/macros/s/AKfycbxPNZ55uREmAdtvbiR6gUnKN3O3M4tchRBwuFq85mDV2CrKepif7SQqwNNb6Wg2nwrH5g/exec";       //シートのGoogleAddScriptのURL

        public void DataLoad()
        {
            generalParameter = AssetDatabase.LoadAssetAtPath<GeneralParameter>(GeneralParameter_PATH);
            UnityWebRequest req = UnityWebRequest.Get(GAS_URL);
            req.SendWebRequest();

            while (!req.isDone)
            {
                // リクエストが完了するのを待機
            }

            if (IsWebRequestSuccessful(req))
            {
                //データを変換
                var data = JsonUtility.FromJson<WebData>(req.downloadHandler.text);

                //変数に反映
                generalParameter.param_0 = (int)float.Parse(data.key_0);
                generalParameter.param_1 = float.Parse(data.key_1);
                generalParameter.param_2 = float.Parse(data.key_2);
                generalParameter.param_3 = float.Parse(data.key_3);
                generalParameter.param_4 = float.Parse(data.key_4);
            }
            else
            {
                Debug.Log("error");
            }
        }

        //リクエストが成功したかどうか判定する関数
        bool IsWebRequestSuccessful(UnityWebRequest req)
        {
            //プロトコルエラーとコネクトエラーではない場合はtrueを返す
            return req.result != UnityWebRequest.Result.ProtocolError &&
                   req.result != UnityWebRequest.Result.ConnectionError;
        }
    }
}