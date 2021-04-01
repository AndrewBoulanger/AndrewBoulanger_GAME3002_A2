using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    //lives/respawn variables
    [SerializeField]
    Transform spawnPoint = null;
    public delegate void OnRespawnDelegate(int lives);
    public static OnRespawnDelegate OnRespawn;
    private int lives = 3;

    //physics variables
    private Rigidbody m_rb = null;
    private Vector3 reflectedVelocity = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //respawn if ball falls off the screen
        if (transform.position.y <= -10)
        {
            transform.position = spawnPoint.position;
            lives--; 
            //send number of lives to the UI
            OnRespawn(lives);
        }
    }
    private void FixedUpdate()
    {
        //saving velocity before its cancelled out by the collision
        _velocity = m_rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ActiveBumper"))
        {
            //reflecting velocity
            reflectedVelocity = Vector3.Reflect( _velocity, collision.GetContact(0).normal);
            m_rb.velocity = reflectedVelocity;
        }
    }

    private void OnDrawGizmos()
    {
        if(m_rb)
            Gizmos.DrawRay(transform.position, m_rb.velocity);
    }
}
