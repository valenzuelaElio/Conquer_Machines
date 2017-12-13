using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

[Serializable]
public class Upgrade : DataNode
{
    [XmlElement("UpgradeType")] public string UpgradeType;
    [XmlElement("upgradeToApply")] public float upgradeToApply;

    public Upgrade()
    {

    }

    public void ApplyUpgrade(DataRobot robot)
    {
        switch (UpgradeType)
        {
            case "Duration":
                robot.Robotstats["Duration"] += upgradeToApply;
                break;

            case "LifePoints":
                robot.Robotstats["LifePoints"] += upgradeToApply;
                break;

            case "Attack":
                robot.Robotstats["Attack"] += upgradeToApply;
                break;

            case "Speed":
                robot.Robotstats["Speed"] += upgradeToApply;
                break;
        }
    }
}
