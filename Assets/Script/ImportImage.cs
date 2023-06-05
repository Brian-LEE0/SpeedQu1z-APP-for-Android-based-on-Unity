using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ImportImage : MonoBehaviour
{

    public Text mainImageTitle;
    public static string ResourcePath = "";
    public static string InfoPath = "";
    string imagePath = "";
    Texture2D t2d;
    public AudioSource bgm;
    public GameObject end;

    public Button up;
    public Button dw;
    public Button re1;
    public Button re2;

    public Image BG;

    int[] arr;
    public static int lineCount;

    int std;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        up.enabled = true;
        dw.enabled = true;
        BG.enabled = true;
        re1.enabled = true;
        re2.enabled = true;

        std = 0;
        
        arr = new int[lineCount];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        ShuffleArray<int>(arr);
        importImage(arr[0]);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public static void ShuffleArray<T>(T[] array)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < array.Length; ++index)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;
        }
    }

    

    void importImage(int a)
    {
        StreamReader reader = new StreamReader(InfoPath);
        for(int i = 0; i < a; i++)
        {
            reader.ReadLine();
        }

        imagePath = reader.ReadLine();
        imagePath = ResourcePath +"/" +imagePath;
        mainImageTitle.text = System.IO.Path.GetFileNameWithoutExtension(imagePath);

        if (System.IO.File.Exists(imagePath))
        {
            byte[] byteTexture = System.IO.File.ReadAllBytes(imagePath);
            if (byteTexture.Length > 0)
            {
                t2d = new Texture2D(0, 0);
                t2d.LoadImage(byteTexture);
            }

            Rect rect = new Rect(0, 0, t2d.width, t2d.height);
            BG.sprite = Sprite.Create(t2d, rect, new Vector2(0.5f, 0.5f));
        }




    }

    public void nextImage()
    {
        if((std < lineCount-1) && (std < 15 - 1))
        {
            std++;
            importImage(arr[std]);            
        }
        else
        {
            BG.sprite = null;
            time = Timer.Std_TIME;
            up.enabled = false;
            dw.enabled = false;
            re1.enabled = false;
            re2.enabled = false;
            BG.enabled = false;
            bgm.Stop();
            mainImageTitle.text = "GameOver";
            GameObject ed = Instantiate(end);
            Destroy(ed, 2);
        }
        
    }

    public void redoImage()
    {
        if (0 < std)
        {
            std--;
            importImage(arr[std]);
        }

    }

    void GameOver()
    {
        if(Timer.left_TIME < 0)
        {
            BG.sprite = null;
            time = Timer.Std_TIME;
            up.enabled = false;
            dw.enabled = false;
            re1.enabled = false;
            re2.enabled = false;
            BG.enabled = false;
            bgm.Stop();
            mainImageTitle.text = "TimeOver";
            GameObject ed = Instantiate(end);
            Destroy(ed,2);
            
        }
        
    }


}
