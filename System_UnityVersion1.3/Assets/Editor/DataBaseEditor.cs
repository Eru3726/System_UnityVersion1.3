using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataBaseEditor : EditorWindow
{
    /// <summary>
    /// エディタの作成
    /// </summary>
    [MenuItem("Editor/DataBase")]
    private static void Create()
    {
        // 生成
        DataBaseEditor window = GetWindow<DataBaseEditor>("データベース");
        // 最小サイズ設定
        window.minSize = new Vector2(240, 240);
    }

    //パス
    private const string ASSET_PATH = "Assets/Resources/DataBase.asset";


    //スクロール
    private Vector2 scrollPos;

    //折り畳み判定
    private bool enemyOpen;
    private bool itemOpen;

    //DataBase
    private DataBase dataBase;

    /// <summary>
    /// レイアウト
    /// </summary>
    private void OnGUI()
    {
        dataBase = AssetDatabase.LoadAssetAtPath<DataBase>(ASSET_PATH);

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
                    if (GUILayout.Button("書き込み"))
                    {
                        Export();
                    }

                    GUI.backgroundColor = defaultColor;
                }
            }

            //折り畳み


            if (dataBase.enemys != null)
            {
                enemyOpen = EditorGUILayout.BeginFoldoutHeaderGroup(enemyOpen, "Enemys");
                if (enemyOpen)
                {
                    for (int i = 0; i < dataBase.enemys.Count; i++)
                    {
                        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
                        {
                            if (dataBase.enemys[i] != null)
                            {
                                GUI.backgroundColor = Color.gray;
                                using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
                                {
                                    //ラベル
                                    GUILayout.Label(dataBase.enemys[i].enemyName);
                                }
                                GUI.backgroundColor = defaultColor;

                                dataBase.enemys[i].enemyMaxHp = EditorGUILayout.IntField("MaxHp", dataBase.enemys[i].enemyMaxHp);
                                dataBase.enemys[i].enemyOffensivePower = EditorGUILayout.IntField("Offens", dataBase.enemys[i].enemyOffensivePower);
                                dataBase.enemys[i].enemyDefensePower = EditorGUILayout.IntField("Defnse", dataBase.enemys[i].enemyDefensePower);
                            }
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
            if (dataBase.items != null)
            {
                itemOpen = EditorGUILayout.BeginFoldoutHeaderGroup(itemOpen, "Items");
                if (itemOpen)
                {
                    for (int i = 0; i < dataBase.items.Count; i++)
                    {
                        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
                        {
                            if (dataBase.items[i] != null)
                            {
                                GUI.backgroundColor = Color.gray;
                                using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
                                {
                                    //ラベル
                                    GUILayout.Label(dataBase.items[i].itemName);
                                }
                                GUI.backgroundColor = defaultColor;

                                dataBase.items[i].itemResilience = EditorGUILayout.IntField("Resilience", dataBase.items[i].itemResilience);
                            }
                        }
                    }
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
        }
    }

    private void Export()
    {
        // Enemy更新通知
        for (int i = 0; i < dataBase.enemys.Count; i++)
        {
            EditorUtility.SetDirty(dataBase.enemys[i]);
        }

        // Item更新通知
        for (int i = 0; i < dataBase.items.Count; i++)
        {
            EditorUtility.SetDirty(dataBase.items[i]);
        }

        // 保存
        AssetDatabase.SaveAssets();

        // エディタを最新の状態にする
        AssetDatabase.Refresh();
    }
}