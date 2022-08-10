using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCockpit : MonoBehaviour
{

    public bool isPlayerInSeat = false;
    public bool isPlayerGameHost = false;
    public float checkPlayerSeatTimer = 1f;

    private PlayerStation myStation;

    void checkPlayerSeat()
    {

        checkPlayerSeatTimer = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        myStation = GetComponent<PlayerStation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayerSeatTimer < 0f) checkPlayerSeat();
    }
}
