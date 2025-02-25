using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public Transform turretSwivel;
    public Transform[] barrelEnds;
    private int currentBarrel = 0;
    private float shootDelay = 0f;
    public GameObject AmmoPrefab;

    public float maxDegreesPerSecond = 35f;

    private PlayerStation MyStation;
    private AudioSource myAS;
    private PhotonView myPV;
    private float updateTimer = 0f;

    private Quaternion aim;

    [PunRPC]
    public void updateTurret(Quaternion swivel)
    {
        if (MyStation.thisPlayer == null)
            turretSwivel.rotation = swivel;
    }

    [PunRPC]
    public void FireTurret()
    {
        if (MyStation.thisPlayer == null)
        {
            fireTheTurret();
        }
    }

    [PunRPC]
    private void fireTheTurret()
    {
        var shot = Instantiate(AmmoPrefab, barrelEnds[currentBarrel].position, barrelEnds[currentBarrel].rotation);
        shot.GetComponent<Rigidbody>().AddForce(barrelEnds[currentBarrel].forward * 10000f);
        Destroy(shot, 3000);
        myAS.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        MyStation = GetComponent<PlayerStation>();
        myAS = GetComponent<AudioSource>();
        myPV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( MyStation.thisPlayer != null)
        { // current player is seated in this turret right now
            turretSwivel.rotation = Quaternion.Lerp(MyStation.thisPlayer.leftController.transform.rotation, MyStation.thisPlayer.rightController.transform.rotation, 0.5f);
            turretSwivel.Rotate(Vector3.left, -90);
            if ( updateTimer < 0f )
            {
                myPV.RPC("updateTurret", RpcTarget.All, turretSwivel.rotation);
                updateTimer = 0.2f;
            }
            updateTimer -= Time.deltaTime;
            shootDelay -= Time.deltaTime;
            if ( shootDelay < 0f && (MyStation.thisPlayer.playerLeftTrigger || MyStation.thisPlayer.playerRightTrigger))
            {
                MyStation.thisPlayer.SendRightHaptics(0,.25f, 0.25f);
                MyStation.thisPlayer.SendLeftHaptics(0,.25f, 0.25f);
                //fireTheTurret();
                myPV.RPC("fireTheTurret", RpcTarget.All);
                shootDelay = 0.5f;
            }
        }
    }
}
