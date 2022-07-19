using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 100;
    [SerializeField] float roation = 100;
    // Start is called before the first frame update

    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRoatation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
            audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRoatation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApllyRotation(roation); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApllyRotation(-roation);
        }
    }

    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation when we can manually rotate
        transform.Rotate(Vector3.forward*Time.deltaTime*rotationThisFrame);
        rb.freezeRotation = false; //unfreeze rotation for physx system
    }
    
}
