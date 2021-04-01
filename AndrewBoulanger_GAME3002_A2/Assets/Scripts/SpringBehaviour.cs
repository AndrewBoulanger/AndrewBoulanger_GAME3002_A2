using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehaviour : MonoBehaviour
{
    [SerializeField]
    private float m_fSpringConstant;
    [SerializeField]
    private float m_fDampingConstant;
    private Vector3 m_restPos;
    [SerializeField]
    private Rigidbody m_attachedBody = null;
    [SerializeField] 
    private float m_fPullSpeed = 2;

    private Vector3 m_vForce;
    private Vector3 m_vPrevVel;

    private bool isPlungerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        m_restPos = transform.position - m_attachedBody.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlungerActive = false;
            m_attachedBody.velocity = -m_restPos.normalized * m_fPullSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //stop moving down, allow the spring force to update movement
            m_attachedBody.velocity = Vector3.zero;
            isPlungerActive = true;
        }
   
    }

    void FixedUpdate()
    {
        //only update the spring movement when input is released
        if (isPlungerActive)
        {
            UpdateSpringForce();
        }
    }

    private void UpdateSpringForce()
    {
        m_vForce = -m_fSpringConstant * (transform.position - m_attachedBody.transform.position);// -
                //   m_fDampingConstant * (m_attachedBody.velocity - m_vPrevVel);

        m_attachedBody.AddForce(m_vForce, ForceMode.Acceleration);

        m_vPrevVel = m_attachedBody.velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + m_restPos, Vector3.one);

        if (m_attachedBody)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_attachedBody.transform.position, 1f);

            Gizmos.DrawLine(transform.position, m_attachedBody.transform.position);
        }
    }
}
