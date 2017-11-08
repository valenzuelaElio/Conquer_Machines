using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System.Xml;
using UnityEditor;

public class XMLOperator
{
    private static XmlDocument dataDoc = new XmlDocument();
    private static TextAsset dataText;

    public static void Serialize(object item, string path)
    {
        //TextAsset data = Resources.Load<TextAsset>(path); // data = Type TextAsset
        //XmlDocument doc = new XmlDocument(); 
        //doc.LoadXml(data.text); //Archivo Xml con la info de data
        XmlSerializer serializer = new XmlSerializer(item.GetType());  // item.GetType() = Data
        StreamWriter streamWriter = new StreamWriter("Assets/Resources/" + path);
        //StreamWriter streamWriter = new StreamWriter(data.text);
        serializer.Serialize(streamWriter.BaseStream, item);
        streamWriter.Close();

        dataDoc.Save(AssetDatabase.GetAssetPath(dataText));
        Debug.Log(AssetDatabase.GetAssetPath(dataText));

    }

    public static void SerializeOnPC(object item, string path)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        StreamWriter streamWriter = new StreamWriter(path);
        serializer.Serialize(streamWriter.BaseStream, item);
        streamWriter.Close();
    }

    public static T Deserialize<T>(string path)
    {
        dataText = Resources.Load<TextAsset>(path);
        dataDoc.LoadXml(dataText.text);

        Debug.Log(dataText.text);
        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(dataText.text));

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //StreamReader reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(stream);
        //reader.Close();
        stream.Close();
        return deserialized;

    }
}
