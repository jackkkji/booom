using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Player : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private World_interaction pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Colddown")]
    public float dashCd;
    public float dashCdTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<World_interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash();
        }


        if (dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }
    }

    void Dash()
    {

        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        rb.AddForce(forceToApply, ForceMode.Impulse);
        Invoke(nameof(ResetDash), dashDuration);

    }

    void ResetDash()
    {

    }



}
