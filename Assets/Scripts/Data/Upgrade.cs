using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class Upgrade : DataNode
{
    [XmlElement] public string UpgradeType;
    [XmlElement] public float upgradeToApply;

    public Upgrade()
    {

    }
}
