using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public ChampionData[] data;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        data = Load();         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Save(ChampionData[] data)
    {
        //이진수화 시켜서 저장
        var formatter = new BinaryFormatter();
        //안드로이드,ios 상관없이 저장가능, FileStream(경로, 동작)
        using(var stream = new FileStream(Application.persistentDataPath + "/Save.myData",FileMode.Create))
        {
            //스트림에다가 data를 써준다.
            formatter.Serialize(stream, data);
            stream.Close();    
        }

    }

    static public ChampionData[] Load()
    {
        if(File.Exists(Application.persistentDataPath +"/Save.myData")==false)
        {
            return null;
        }
        
        var formatter = new BinaryFormatter();

        using(var stream = new FileStream(Application.persistentDataPath +"/Save.myData",FileMode.Open))
        {
            var result = formatter.Deserialize(stream) as ChampionData[];
            return result;
        }
    }
}
