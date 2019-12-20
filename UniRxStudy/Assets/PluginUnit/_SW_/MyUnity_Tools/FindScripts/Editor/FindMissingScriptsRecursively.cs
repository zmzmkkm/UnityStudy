using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class FindMissingScriptsRecursively : EditorWindow
{
    static int go_count = 0, components_count = 0, missing_count = 0;

    [MenuItem("SW/查找脚本/查找丢失脚本的物体")]
    public static void ShowWindow()
    {
        //FindMissingScriptsRecursively window = GetWindow<FindMissingScriptsRecursively>();
        //window.Show();
        EditorWindow.GetWindow(typeof(FindMissingScriptsRecursively));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))
        {
            FindInSelected();
        }
    }
    private static void FindInSelected()
    {
        GameObject[] go = Selection.gameObjects;
        go_count = 0;
        components_count = 0;
        missing_count = 0;
        foreach (GameObject g in go)
        {
            FindInGO(g);
        }
        Debug.Log(string.Format("找到{0}个物体 , {1}个组件 , 找到{2}个missing", go_count, components_count, missing_count));
    }

    private static void FindInGO(GameObject g)
    {
        go_count++;
        Component[] components = g.GetComponents<Component>();
        for (int i = 0; i < components.Length; i++)
        {
            components_count++;
            if (components[i] == null)
            {
                missing_count++;
                string s = g.name;
                Transform t = g.transform;
                while (t.parent != null)
                {
                    s = t.parent.name + "/" + s;
                    t = t.parent;
                }
                Debug.Log(s + "物体上有一个脚本丢失:\n位置索引为:" + i, g);
            }
        }
        // Now recurse through each child GO (if there are any):  
        foreach (Transform childT in g.transform)
        {
            Debug.Log("Searching " + childT.name + " ");
            FindInGO(childT.gameObject);
        }
    }
}