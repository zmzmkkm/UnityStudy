// ========================================================
// 描 述：批量添加脚本
// 作 者：SW
// 创建时间：2017/10/30 09:38:46
// 版 本：v 1.0
// ========================================================

using UnityEngine;
using UnityEditor;

public class AddComponents : EditorWindow
{
    [MenuItem("SW/批量处理/批量添加脚本")]
    public static void CreateWindow()
    {
        AddComponents window = GetWindow<AddComponents>();
        window.Show();
    }

    private string tag = Tags.player;
    private MonoScript _scriptObj = null;



    private void OnGUI()
    {
        Repaint();
        //EditorGUILayout.LabelField("当前选择了 " + tip + " 个对象");
        //needAddComponent = EditorGUILayout.ObjectField("要替换成的对象：", needAddComponent, typeof(GameObject), true) as GameObject;
        //component = EditorGUILayout.ObjectField("要替换成的对象：", component, typeof(Component), true) as Component;
        _scriptObj = (MonoScript)EditorGUILayout.ObjectField("脚本类型:", _scriptObj, typeof(MonoScript), true);
        if (GUILayout.Button("批量添加"))
        {
            AddThisTagComponents();
        }
        if (GUILayout.Button("批量删除"))
        {
            DeleteThisTagComponents();
        }
    }


    /// <summary>
    /// 批量添加组件
    /// </summary>
    public void AddThisTagComponents()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag(tag);
        foreach (var item in a)
        {
            if (item.GetComponent(_scriptObj.GetClass()) == null)
            {
                item.AddComponent(_scriptObj.GetClass());
            }
        }
    }

    /// <summary>
    /// 批量删除组件
    /// </summary>
    public void DeleteThisTagComponents()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag(tag);
        foreach (var item in a)
        {
            if (item.GetComponent(_scriptObj.GetClass()) != null)
            {
                DestroyImmediate(item.GetComponent(_scriptObj.GetClass()));
            }
        }
    }
}

