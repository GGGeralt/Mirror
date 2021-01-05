using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Movement : NetworkBehaviour
{
    public Vector3 control;

    public Color c;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NetworkIdentity>().hasAuthority)
        {
            GetComponent<Renderer>().material.color = c;

            control = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);

            GetComponent<PhysicsLink>().ApplyForce(control, ForceMode.VelocityChange);

            if (Input.GetAxis("Cancel") == 1)
            {
                GetComponent<PhysicsLink>().CmdResetPose();
            }
        }
    }
}
