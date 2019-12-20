// ========================================================
// 描 述：数据源
// 作 者：SW
// 创建时间：2019/12/17 15:27:04
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

[Serializable]
public class TodoList
{
    public int topid = 4;


    public List<TodoItem> todoItemsList = new List<TodoItem>()
   {
       new TodoItem(){id = 0,content = new StringReactiveProperty("去买胡萝卜..."),isCompleted = new BoolReactiveProperty(false)},
       new TodoItem(){id = 1,content = new StringReactiveProperty("去买黄瓜..."),isCompleted = new BoolReactiveProperty(false)},
       new TodoItem(){id = 2,content = new StringReactiveProperty("去买鸡胸脯..."),isCompleted = new BoolReactiveProperty(false)},
       new TodoItem(){id = 3,content = new StringReactiveProperty("做一份香喷喷的“宫保鸡丁”..."),isCompleted = new BoolReactiveProperty(false)}
   };


    public void Add(string content)
    {
        todoItemsList.Add(new TodoItem()
        {
            id = topid,
            content = new StringReactiveProperty(content),
            isCompleted = new BoolReactiveProperty(false)
        });
        topid++;
    }

    public void Save()
    {
        todoItemsList
            .Where(q => q.isCompleted.Value)
            .ToList()
            .ForEach(temp => todoItemsList.Remove(temp));

        var jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("TestData01", jsonData);
    }


    public static TodoList Load()
    {
        var jsonData = PlayerPrefs.GetString("TestData01", String.Empty);

        if (string.IsNullOrEmpty(jsonData))
        {
            return new TodoList();
        }
        else
        {
            return JsonUtility.FromJson<TodoList>(jsonData);
        }
    }
}


/// <summary>
/// 待办事项
/// </summary>
[Serializable]
public class TodoItem
{
    /// <summary>
    /// id
    /// </summary>
    public int id;

    /// <summary>
    /// 内容
    /// </summary>
    public StringReactiveProperty content;

    /// <summary>
    /// 是否完成
    /// </summary>
    public BoolReactiveProperty isCompleted;
}
