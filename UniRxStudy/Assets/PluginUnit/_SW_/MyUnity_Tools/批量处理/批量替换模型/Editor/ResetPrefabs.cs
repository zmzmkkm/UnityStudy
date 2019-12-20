// ========================================================
// 描 述：批量替换模型
// 作 者：SW
// 创建时间：2017/10/30 09:38:46
// 版 本：v 1.0
// ========================================================


using UnityEngine;
using UnityEditor;



public class ResetPrefabs : EditorWindow
{
    private GameObject _prefab;
    private Transform[] _objs;
    private string _tip = string.Empty;

    [MenuItem("SW/批量处理/批量替换模型")]
    public static void CreateWindow()
    {
        ResetPrefabs window = GetWindow<ResetPrefabs>();
        window.Show();
    }

    private void OnGUI()
    {
        Repaint();
        EditorGUILayout.LabelField("当前选择了 " + _tip + " 个对象");
        _prefab = EditorGUILayout.ObjectField("要替换成的对象：", _prefab, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("批量替换!"))
        {
            OnResetButtonClick();
        }
    }

    private void OnResetButtonClick()
    {
        foreach (var item in Selection.gameObjects)
        {
            GameObject pre = Instantiate(_prefab) as GameObject;
            pre.name = item.name;
            pre.transform.SetParent(item.transform.parent);
            pre.transform.position = item.transform.position;
            pre.transform.rotation = item.transform.rotation;
            pre.transform.localScale = item.transform.localScale;
            Undo.RegisterCreatedObjectUndo(pre, "Create pre");
            Undo.DestroyObjectImmediate(item);
        }
    }

    void OnSelectionChange()
    {
        _tip = Selection.gameObjects.Length.ToString();
        if (Selection.gameObjects.Length > 0)
        {
            _objs = new Transform[Selection.gameObjects.Length];
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                _objs[i] = Selection.gameObjects[i].transform;
            }
        }
    }
}