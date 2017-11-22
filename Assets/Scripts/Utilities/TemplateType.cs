using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateType : MonoBehaviour {
    public enum TemplateTypeEx
    {
        Extractor,
        Robot,
        Mision,
        AssemblyLine,
        Node,
        RawMaterial,
        NodeCore,
        NodeUpgrade,

    }
    public TemplateTypeEx Type;
}
