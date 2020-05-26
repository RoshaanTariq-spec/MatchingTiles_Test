using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Collector
{

    public string username = "";
    public string profile_pic_url = "";
}

[System.Serializable]
public class data
{

    public Collector[] collector;
}


public class SerializeClassesContainer : MonoBehaviour
{

}
