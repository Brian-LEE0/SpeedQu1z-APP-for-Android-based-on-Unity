using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class loadTopic : MonoBehaviour
{
    public static string NOW_TOPIC = "";
    int track_num;
    int track_num2;

    public ChgTextTopic[] c;


    public static int level = 0;
    int dirnum = 0;

    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
        public float volume;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";

    // Start is called before the first frame update
    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.volume = 0.3f;
        BGM.loop = true;

        track_num = Random.Range(0, BGMList.Length);
        Debug.Log(track_num + 1);

        if (BGMList.Length > 0) PlayBGM(BGMList[track_num].name);
        else Debug.Log(BGMList.Length);

        WriteInfo();
        ChangeTopic();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))

        {

            // 

            Application.Quit();


        }


    }

    void WriteInfo()
    {
        string InfoPath = Application.persistentDataPath + "/info.txt";
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(InfoPath));
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(InfoPath, FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);


        string GamePath = Application.persistentDataPath + "/quiz";

        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(GamePath);

        dirnum = di.GetDirectories().Length;

        foreach (System.IO.DirectoryInfo Dir in di.GetDirectories())
        {
            writer.WriteLine(Dir.Name);
        }
        writer.Close();
    }


    void ChangeTopic()
    {
        string InfoPath = Application.persistentDataPath + "/info.txt";

        FileInfo fileInfo = new FileInfo(InfoPath);

        ChgTextTopic[] chgTextTopics = new ChgTextTopic[8];

        for(int i = 0; i < 8; i++)
        {
            chgTextTopics[i] = c[i];
        }

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(InfoPath);

            int lop = level*8;
            for (int j = 0;j < lop;j++)
            {
                reader.ReadLine();
            }
            foreach (ChgTextTopic ctt in chgTextTopics)
            {
                ctt.textChange(reader.ReadLine());
            }
        }

    }

    public void upLevel()
    {
        if (level < (int)(dirnum / 8))
        {
            level += 1;
        }
        Debug.Log(level);
        ChangeTopic();

    }

    public void downLevel()
    {
        
        if(!(level == 0))
        {
            level -= 1;
        }
        Debug.Log(level);
        ChangeTopic();
    }

    public void ChangeBGM()
    {

        Destroy(BGM);
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        BGM.volume = 0.3f;

        int track_num2 = Random.Range(0, BGMList.Length);
        while(track_num == track_num2)
        {
            track_num2 = Random.Range(0, BGMList.Length);
        }
        track_num = track_num2;
        Debug.Log(track_num2 +1);


        if (BGMList.Length > 0) PlayBGM(BGMList[track_num2].name);
        else Debug.Log(BGMList.Length);
    }
    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;
        for(int i = 0;i < BGMList.Length; ++i)
        {
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                BGM.volume = BGMList[i].volume;
                NowBGMname = name;
            }
        }
    }

    public void StopBGM(string name)
    {
        Destroy(gameObject.GetComponent<AudioSource>());
    }

}
