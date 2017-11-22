using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class Core : DataNode
{
    [XmlIgnore] public bool Generate;
    [XmlIgnore] float StartTime;
    [XmlIgnore] float TimesTamp;
    [XmlIgnore] float GenerationTime;

    public void Generating(float time)
    {
        TimesTamp = time - StartTime;
        if (TimesTamp > GenerationTime)
        {
            Generate = true;
            StartTime = time;
        }
        else
        {
            Generate = false;
            StartTime = 0;
        }
    }

    public void StartToGenerate()
    {
        this.StartTime = Time.time;
    }

}
