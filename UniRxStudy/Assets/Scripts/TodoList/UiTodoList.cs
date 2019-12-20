// ========================================================
// 描 述：TodoList功能实现
// 作 者：SW
// 创建时间：2019/12/17 16:07:57
// 版 本：v 1.0
// ========================================================

using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UiTodoList : MonoBehaviour
{
    public UITodoItem uiTodoItemPrefab;
    public Transform parent;
    public InputField inputContent;
    public Button addBtn;

    public TodoList _model;

    void Start()
    {

        _model = TodoList.Load();
        //Debug.Log(JsonUtility.ToJson(_model));

        AddContent();

        OnDataChanged();
    }

    /// <summary>
    /// 添加数据
    /// </summary>
    private void AddContent()
    {
        inputContent.OnValueChangedAsObservable()
            .Select(valueText => !string.IsNullOrEmpty(valueText))
            .SubscribeToInteractable(addBtn);

        addBtn.OnClickAsObservable()
            .Select(valueText => inputContent.text)
            .Subscribe(valueText =>
            {
                if (!string.IsNullOrEmpty(valueText))
                {
                    _model.Add(valueText);
                    inputContent.text = string.Empty;
                }
            });

        //_model.todoItemsList.ObserveCountChanged().Subscribe(q => { OnDataChanged(); });
        //_model.todoItemsList.ToReactiveCollection().ObserveCountChanged().Subscribe(q => { OnDataChanged(); });
        _model.todoItemsList.ObserveEveryValueChanged(q => q.Count).Subscribe(q => { OnDataChanged(); });
    }


    private void OnDataChanged()
    {
        var childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        //var todoItems = _model.todoItemsList;
        //foreach (var item in todoItems)
        //{
        //    if (!item.isCompleted.Value)
        //    {
        //        item.isCompleted.Subscribe(isCompleted =>
        //        {
        //            if (isCompleted)
        //            {
        //                OnDataChanged();
        //            }
        //        });

        //        var go = Instantiate(uiTodoItemPrefab);
        //        go.transform.SetParent(parent, false);

        //        go.SetModel(item);
        //    }
        //}


        _model.todoItemsList
            .Where(temp => !temp.isCompleted.Value)
            .ToList()
            .ForEach(temp =>
            {
                temp.isCompleted.Subscribe(q =>
                {
                    //OnDataChanged();
                    if (q)
                    {
                        OnDataChanged();
                    }
                });

                var go = Instantiate(uiTodoItemPrefab);
                go.transform.SetParent(parent, false);

                go.SetModel(temp);
            });

        _model.Save();
    }
}
