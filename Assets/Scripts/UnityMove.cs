using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Move/Create Move")]
public class UnityMove : ScriptableObject {
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField]  EnemyType Type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name{
        get{return name;}
    }

    public string Description{
        get {return description;}
    }

    public EnemyType type{
        get {return Type;}
    }
    public int Power{
        get {return power;}
    }
    public int Accuracy{
        get {return accuracy;}
    }
    public int PP{
        get {return pp;}
    }
    
}
