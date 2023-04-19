using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using TMPro;

public class DataController : MonoBehaviour
{
    /// <summary>
    /// </summary>

    // public static TowerListData _towerDataList = new TowerListData();
    // public static PlayerListData _playerDataList = new PlayerListData();
    // public static StageListData _stageDataList = new StageListData();
    // public static UserData _userData = new UserData();
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        // _towerDataList = XMLControler.LoadXML<TowerListData>("XML/Tower");
        // // WriteDownXML("TowerWrite.xml",_towerDataList);
       
        // _playerDataList = XMLControler.LoadXML<PlayerListData>("XML/Player");
        // // WriteDownXML("PlayerWrite.xml",_playerDataList);

        // _stageDataList = XMLControler.LoadXML<StageListData>("XML/Stage");
        // // WriteDownXML("StageWrite.xml",_stageDataList);

        // _userData = XMLControler.LoadXML<UserData>("XML/User");
        // // WriteDownXML("UserWrite.xml",_userData);
    }


    // public static T LoadXML<T>(string path){
    //     try{
    //         XmlSerializer serializer = new XmlSerializer(typeof(T));
    //         TextAsset textAsset = (TextAsset) Resources.Load(path);  
    //         using  (var reader = new System.IO.StringReader(textAsset.text)){
    //             return (T)serializer.Deserialize(reader);
    //         }
    //     }
    //     catch(Exception e){
    //         Debug.LogError("Exception importing xml file " + path + " :" + e);
    //         return default;
    //     }
    // }
    // public static bool WriteDownXML<T>(string filename, T dataList){
    //     try{
    //         XmlSerializer xs = new XmlSerializer(typeof(T));
    //         TextWriter tw = new StreamWriter(Application.persistentDataPath + "/" + filename);
    //         xs.Serialize(tw, dataList);
    //         tw.Close();
    //         return true;
    //     }
    //     catch(Exception e){
    //         Debug.LogError("Exception write  down xml file " + filename +": " + e);
    //     }
    //     return false;
    // }
    //khoi update
     public static bool LocalWriteXML<T>(string filename, T dataList){
        try{
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(Application.persistentDataPath + "/" + filename, FileMode.Create);
            TextWriter tw = new StreamWriter(stream);
            xs.Serialize(tw, dataList);
            stream.Close();
            return true;
        }
        catch(Exception e){
            Debug.LogError("Exception write  down xml file " + filename +": " + e);
        }
        return false;
    }

    public static T LocalLoadXML<T>(string filename){
        try{
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using  (var reader = XmlReader.Create(Application.persistentDataPath + "/" + filename)){
                return (T)serializer.Deserialize(reader);
            }
        }
        catch(Exception e){
            Debug.LogError("Exception importing xml file " + filename + " :" + e);
            return default;
        }
    }
    //=====
}

