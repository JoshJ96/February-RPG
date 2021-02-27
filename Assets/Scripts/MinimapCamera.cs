using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.pushDungeonData += PushDungeonData;
    }

    private void PushDungeonData(DungeonData data)
    {
        transform.position = new Vector3(data.mapWidth, 0, data.mapHeight);
        GetComponent<Camera>().orthographicSize = data.mapWidth;
    }

}
