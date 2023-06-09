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
    public static T LoadFromResourceXML<T>(string path)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextAsset textAsset = (TextAsset)Resources.Load(path);
            using (var reader = new System.IO.StringReader(textAsset.text))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Exception importing xml file " + path + " :" + e);
            return default;
        }
    }
    public static bool LocalWriteXML<T>(string filename, T dataList)
    {
        try
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(Application.persistentDataPath + "/" + filename, FileMode.Create);
            TextWriter tw = new StreamWriter(stream);
            xs.Serialize(tw, dataList);
            stream.Close();
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError("Exception write down xml file " + filename + ": " + e);
        }
        return false;
    }

    public static T LocalLoadXML<T>(string filename)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(Application.persistentDataPath + "/" + filename))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Exception importing xml file " + filename + " :" + e);
            return default;
        }
    }
}

