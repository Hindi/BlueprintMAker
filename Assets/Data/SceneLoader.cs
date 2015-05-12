using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class SceneLoader : MonoBehaviour 
{
    [SerializeField]
    private Scene scene;

    [SerializeField]
    private GameObject confirmPanel;

    [SerializeField]
    private Transform fileListContainer;

    [SerializeField]
    private GameObject fileNamePrefab;

    [SerializeField]
    private RectTransform canvasRect;

    private string path;

    void Awake()
    {
         path = Application.persistentDataPath + "/save/";
         loadFilleList();
    }

    public void saveScene(string filename)
    {
        checkPath(path);
        doSave(path + filename);
    }

    public void saveAsScene(string filename)
    {
        checkPath(path);
        if (File.Exists(path + filename))
        {

        }
        else
            doSave(path + filename);
    }

    public void doSave(string fullpath)
    {
        using (StreamWriter sw = new StreamWriter(fullpath))
        {
            string save = scene.save();
            sw.WriteLine(save);
        }
    }

    public void loadScene(string filename)
    {
        try
        {
            checkPath(path);
            if (File.Exists(path + filename))
            {
                string save = "";
                using (StreamReader sr = new StreamReader(path + filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        save += line;
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private void checkPath(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private void addFileName(string name)
    {
        GameObject obj = Instantiate(fileNamePrefab);
        obj.transform.SetParent(fileListContainer);
        obj.transform.GetChild(0).GetComponent<Text>().text = name;
        obj.GetComponent<RectTransform>().localScale *= canvasRect.localScale.x;
#if UNITY_EDITOR
        obj.name = "[Filename]" + name;
#endif
    }

    private void loadFilleList()
    {
        fileListContainer.gameObject.SetActive(true);
        foreach(string s in Directory.GetFiles(path))
        {
            addFileName(Path.GetFileName(s));
        }
    }
}
