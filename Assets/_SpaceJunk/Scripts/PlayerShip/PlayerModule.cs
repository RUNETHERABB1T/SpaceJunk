using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModule : MonoBehaviour
{
    public string moduleName = "Standard Name";
    public string moduleDescription = "Standard desc";

    public List<Transform> Ports;
    public List<PlayerStation> Stations;
    public List<PlayerModule> ModulesConnected;

    public float structureHP = 100f;
    public float structureMaxHP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
