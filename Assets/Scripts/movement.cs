using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] float thrust = 100;
    [SerializeField] float roation = 100;
    [SerializeField] AudioClip mainEngine;
   

    [SerializeField] ParticleSystem boostParticles;
    [SerializeField] ParticleSystem leftBoostParticles;
    [SerializeField] ParticleSystem rightBoostParticles;

    Rigidbody rb;
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
            audioSource.PlayOneShot(mainEngine);
            }
            if(!boostParticles.isPlaying)
            {
            boostParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            boostParticles.Stop();   
        }

           
               
          
    }

    void ProcessRoatation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApllyRotation(roation); 
            

            if(!leftBoostParticles.isPlaying)
            {
            leftBoostParticles.Play();
            }


        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApllyRotation(-roation);

            if(!rightBoostParticles.isPlaying)
            {
             rightBoostParticles.Play();
            }
        }
        else
        {
            rightBoostParticles.Stop();
            leftBoostParticles.Stop();

        }
    }

    void ApllyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation when we can manually rotate
        transform.Rotate(Vector3.forward*Time.deltaTime*rotationThisFrame);
        rb.freezeRotation = false; //unfreeze rotation for physx system
    }
    
}
