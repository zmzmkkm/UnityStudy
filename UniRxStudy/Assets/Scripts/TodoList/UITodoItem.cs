// ========================================================
// 描 述：数据显示模板
// 作 者：SW
// 创建时间：2019/12/17 16:02:12
// 版 本：v 1.0
// ========================================================

using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UITodoItem : MonoBehaviour
{
    private TodoItem _todoItem;

    public Button completedButton;
    public Text connectText;
    public Button thisButton;

    private void Start()
    {
        completedButton.OnClickAsObservable()
            .Subscribe(_ => { _todoItem.isCompleted.Value = true; });
        thisButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                print("aaaa");
            });
    }

    public void SetModel(TodoItem temp)
    {
        _todoItem = temp;
        UpdateView();
    }

    private void UpdateView()
    {
        connectText.text = _todoItem.content.Value;
    }
}