// ========================================================
// 描 述：自定创建文件夹
// 作 者：SW
// 创建时间：2019/12/16 15:55:19
// 版 本：v 1.0
// ========================================================

using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GenerateFolders
{
#if UNITY_EDITOR
    [MenuItem("SW/添加工程文件夹/All")]
    private static void CreateALLBasicFolder()
    {
        GenerateALLFolder();
    }

    private static void GenerateALLFolder()
    {
        // 文件路径
        string prjPath = Application.dataPath + "/";
        Directory.CreateDirectory(prjPath + "Audio");
        Directory.CreateDirectory(prjPath + "Editor");
        Directory.CreateDirectory(prjPath + "GUI");
        Directory.CreateDirectory(prjPath + "Materials");
        Directory.CreateDirectory(prjPath + "Meshes");
        Directory.CreateDirectory(prjPath + "Plugins");
        Directory.CreateDirectory(prjPath + "Prefabs");
        Directory.CreateDirectory(prjPath + "Resources");
        Directory.CreateDirectory(prjPath + "Scenes");
        Directory.CreateDirectory(prjPath + "Scripts");
        Directory.CreateDirectory(prjPath + "Shaders");
        Directory.CreateDirectory(prjPath + "Textures/Sprites");
        Directory.CreateDirectory(prjPath + "StreamingAssets");
        Directory.CreateDirectory(prjPath + "PluginUnit");

        Directory.CreateDirectory(prjPath + "_Other");

        AssetDatabase.Refresh();
    }

    #region Once

    [MenuItem("SW/添加工程文件夹/One/Audio")]
    private static void Audio()
    {
        GenerateFolderOneByOne(0);
    }

    [MenuItem("SW/添加工程文件夹/One/Prefabs")]
    private static void Prefabs()
    {
        GenerateFolderOneByOne(1);
    }

    [MenuItem("SW/添加工程文件夹/One/Materials")]
    private static void Materials()
    {
        GenerateFolderOneByOne(2);
    }

    [MenuItem("SW/添加工程文件夹/One/Resources")]
    private static void Resources()
    {
        GenerateFolderOneByOne(3);
    }

    [MenuItem("SW/添加工程文件夹/One/Scripts")]
    private static void Scripts()
    {
        GenerateFolderOneByOne(4);
    }

    [MenuItem("SW/添加工程文件夹/One/Textures")]
    private static void Textures()
    {
        GenerateFolderOneByOne(5);
    }

    [MenuItem("SW/添加工程文件夹/One/Scenes")]
    private static void Scenes()
    {
        GenerateFolderOneByOne(6);
    }

    [MenuItem("SW/添加工程文件夹/One/Editor")]
    private static void Editor()
    {
        GenerateFolderOneByOne(7);
    }

    [MenuItem("SW/添加工程文件夹/One/Plugins")]
    private static void Plugins()
    {
        GenerateFolderOneByOne(8);
    }

    [MenuItem("SW/添加工程文件夹/One/Meshes")]
    private static void Meshes()
    {
        GenerateFolderOneByOne(9);
    }

    [MenuItem("SW/添加工程文件夹/One/Shaders")]
    private static void Shaders()
    {
        GenerateFolderOneByOne(10);
    }

    [MenuItem("SW/添加工程文件夹/One/GUI")]
    private static void GUI()
    {
        GenerateFolderOneByOne(11);
    }

    [MenuItem("SW/添加工程文件夹/One/StreamingAssets")]
    private static void StreamingAssets()
    {
        GenerateFolderOneByOne(12);
    }

    [MenuItem("SW/添加工程文件夹/One/PluginUnit")]
    private static void PluginUnit()
    {
        GenerateFolderOneByOne(13);
    }

    [MenuItem("SW/添加工程文件夹/One/_Others")]
    private static void Others()
    {
        GenerateFolderOneByOne(100);
    }

    #endregion

    private static void GenerateFolderOneByOne(int flag)
    {
        // 文件路径
        string prjPath = Application.dataPath + "/";

        if (flag == 0)
        {
            Directory.CreateDirectory(prjPath + "Audio");
        }

        if (flag == 1)
        {
            Directory.CreateDirectory(prjPath + "Prefabs");
        }

        if (flag == 2)
        {
            Directory.CreateDirectory(prjPath + "Materials");
        }

        if (flag == 3)
        {
            Directory.CreateDirectory(prjPath + "Resources");
        }

        if (flag == 4)
        {
            Directory.CreateDirectory(prjPath + "Scripts");
        }

        if (flag == 5)
        {
            Directory.CreateDirectory(prjPath + "Textures/Sprites");
        }

        if (flag == 6)
        {
            Directory.CreateDirectory(prjPath + "Scenes");
        }

        if (flag == 7)
        {
            Directory.CreateDirectory(prjPath + "Editor");
        }

        if (flag == 8)
        {
            Directory.CreateDirectory(prjPath + "Plugins");
        }

        if (flag == 9)
        {
            Directory.CreateDirectory(prjPath + "Meshes");
        }

        if (flag == 10)
        {
            Directory.CreateDirectory(prjPath + "Shaders");
        }

        if (flag == 11)
        {
            Directory.CreateDirectory(prjPath + "GUI");
        }

        if (flag == 12)
        {
            Directory.CreateDirectory(prjPath + "StreamingAssets");
        }

        if (flag == 13)
        {
            Directory.CreateDirectory(prjPath + "PluginUnit");
        }


        if (flag == 100)
        {
            Directory.CreateDirectory(prjPath + "_Other");
        }
        AssetDatabase.Refresh();
    }
#endif
}