using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneChangerMaintoIngame : MonoBehaviour
{
    public Text txt;
    public Button bt;
    string ResourcePath = "";
    string InfoPath = "";
    ImportImage i2;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickTopicButton()
    {
        
        if (txt.text != "")
        {
            loadTopic.NOW_TOPIC = txt.text;
            Debug.Log(txt.text);
            ResourcePath = Application.persistentDataPath + "/quiz/" + loadTopic.NOW_TOPIC;
            WriteInfo_eachTopic();
            if (ImportImage.lineCount <= 0)
            {
                Debug.Log("사진없음");

                return;
            }
            ImportImage.ResourcePath = ResourcePath;
            ImportImage.InfoPath = ResourcePath + "/info.txt";
            SceneManager.LoadScene("CountDown");
        }

       

    }
    public void WriteInfo_eachTopic()
    {
        ImportImage.lineCount = 0;
        InfoPath = ResourcePath + "/info.txt";
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(InfoPath));
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(InfoPath, FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);


        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(ResourcePath);


        foreach (System.IO.FileInfo Dir in di.GetFiles())
        {
            if (!Dir.Name.Contains("meta") && !Dir.Name.Contains("info"))
            {
                writer.WriteLine(Dir.Name);
                ImportImage.lineCount++;
            }

        }
        writer.Close();
    }
}
