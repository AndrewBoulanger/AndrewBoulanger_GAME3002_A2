using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleFlipper : MonoBehaviour
{
    [SerializeField]
    KeyCode inputKey = 0;

    [SerializeField] 
    private float paddleSpeed = 5f;
    [SerializeField] 
    private float restoreSpeed = 5f;

    private Rigidbody m_rb = null;
    private HingeJoint m_hinge = null;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(inputKey) )
        {
            if(m_hinge.angle < m_hinge.limits.max)
            {
                Vector3 accel = m_hinge.axis * paddleSpeed * Time.deltaTime;
            m_rb.AddTorque(accel, ForceMode.Acceleration);
            }
        }
        else
        {
            if(m_hinge.angle > m_hinge.limits.min)
            { 
                Vector3 accel = -m_hinge.axis * restoreSpeed * Time.deltaTime;
                m_rb.AddTorque(accel, ForceMode.Acceleration);
            }
        }
    }
}
