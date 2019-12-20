using UnityEngine;
using UnityEditor;

public class GreatUI : MonoBehaviour
{

    [MenuItem("GameObject/SW_UI/Calendar", false, 10)]
    public static void creatCalendar()
    {
        GameObject go = Instantiate(Resources.Load("SW_MyPrefabs/Calendar", typeof(GameObject))) as GameObject;
        go.name = "Calendar";
        GameObject parent = Selection.activeGameObject;
        if (parent)
        {
            go.transform.parent = parent.transform;
        }
        else
        {
            Transform CanvasTransform = GameObject.Find("Canvas").transform;
            if (CanvasTransform)
            {
                go.transform.parent = CanvasTransform;
            }
        }
        go.transform.localPosition = new Vector3(0, 0, 0);
    }
    

    [MenuItem("GameObject/SW_UI/SW_Text", false, 11)]
    public static void creatText()
    {
        GameObject go = Instantiate(Resources.Load("SW_MyPrefabs/SW_Text", typeof(GameObject))) as GameObject;
        go.name = "SW_Text";
        GameObject parent = Selection.activeGameObject;
        if (parent)
        {
            go.transform.parent = parent.transform;
        }
        else
        {
            Transform CanvasTransform = GameObject.Find("Canvas").transform;
            if (CanvasTransform)
            {
                go.transform.parent = CanvasTransform;
            }
        }
        go.transform.localPosition = new Vector3(0, 0, 0);
    }



    [MenuItem("GameObject/SW_UI/SW_InputField_Time", false, 12)]
    public static void creatInputField()
    {
        GameObject go = Instantiate(Resources.Load("SW_MyPrefabs/SW_InputField_Time", typeof(GameObject))) as GameObject;
        go.name = "SW_InputField_Time";
        GameObject parent = Selection.activeGameObject;
        if (parent)
        {
            go.transform.parent = parent.transform;
        }
        else
        {
            Transform CanvasTransform = GameObject.Find("Canvas").transform;
            if (CanvasTransform)
            {
                go.transform.parent = CanvasTransform;
            }
        }
        go.transform.localPosition = new Vector3(0, 0, 0);
    }
}
