using UnityEngine;

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
            GSSEditor window = GetWindow<GSSEditor>("GSSEditor");
            // 最小サイズ設定
            window.minSize = new Vector2(120, 140);
        }

        private PathScriptableObject pathScriptableObject;

        //パスをまとめたスクリプタブルオブジェクトのパス
        private string PathScriptableObject_PATH = "Assets/EruGoogleSpreadSheet/Resources/PathScriptableObject.asset";

        //スクロール
        private Vector2 scrollPos;

        /// <summary>
        /// レイアウト
        /// </summary>
        private void OnGUI()
        {
            //スクロール
            using var scrollView = new EditorGUILayout.ScrollViewScope(scrollPos, GUILayout.Height(position.size.y));
            scrollPos = scrollView.scrollPosition;

            LoadGSS loadGSS = new LoadGSS();

            Color defaultColor = GUI.backgroundColor;

            //GoogleSpreadSheetを開くボタン
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.green;

                    if (GUILayout.Button("GSSを開く"))
                    {
                        //パスの更新
                        pathScriptableObject = AssetDatabase.LoadAssetAtPath<PathScriptableObject>(PathScriptableObject_PATH);

                        //パスのサイトを開く
                        Application.OpenURL(pathScriptableObject.Sheet_URL);
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
                        //パスの更新
                        pathScriptableObject = AssetDatabase.LoadAssetAtPath<PathScriptableObject>(PathScriptableObject_PATH);

                        for (int i = 0; i < pathScriptableObject.Scripts_PATH.Length; i++)
                        {
                            Object o = AssetDatabase.LoadAssetAtPath(pathScriptableObject.Scripts_PATH[i], typeof(Object)) as Object;
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

            //パスの変更をするためのボタン
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                using (new GUILayout.HorizontalScope(GUI.skin.box))
                {
                    GUI.backgroundColor = Color.blue;

                    if (GUILayout.Button("パスの変更"))
                    {
                        //パスの更新
                        pathScriptableObject = AssetDatabase.LoadAssetAtPath<PathScriptableObject>(PathScriptableObject_PATH);

                        Object o = AssetDatabase.LoadAssetAtPath(PathScriptableObject_PATH, typeof(Object)) as Object;
                        if (o != null)
                        {
                            // ファイルを選択(Projectウィンドウでファイルが選択状態になる)
                            Selection.activeObject = o;

                            // ファイルを開く(Visual Studioでファイルが開く)
                            AssetDatabase.OpenAsset(o);
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
                        loadGSS.DataLoad();

                        // エディタを最新の状態にする
                        AssetDatabase.Refresh();
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }
        }
    }
}