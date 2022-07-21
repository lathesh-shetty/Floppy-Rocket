
using UnityEngine;
using UnityEngine.SceneManagement;


public class collisonHandler : MonoBehaviour
{
   [SerializeField] float loadLevelDelay = 2f;
   [SerializeField] AudioClip win;
   [SerializeField] AudioClip crash;

   [SerializeField] ParticleSystem winParticles;
   [SerializeField] ParticleSystem crashParticles;

   bool isTransitioning = false;
   bool collisionDisable = false;

   void Update()
   {
    cheats();
   }
   
   void cheats()
   {
    if(Input.GetKeyDown(KeyCode.L))
    {
     loadNextlevel();
    }
    else if(Input.GetKeyDown(KeyCode.C))
    {
    collisionDisable = !collisionDisable;
    }
   }

   private void OnCollisionEnter(Collision other)
   {
    if(isTransitioning || collisionDisable)
    {
        return;
    }
    switch (other.gameObject.tag)
    {
        case "Friendly":
            Debug.Log("Friendly");
            break;
        case "Finish":
            StartWinSequence();
            break; 
        default:
            StartCrashSequence();
            break;
    }
   }


void StartWinSequence()
{
isTransitioning = true;
GetComponent< AudioSource>().Stop();
GetComponent< AudioSource>().PlayOneShot(win);
winParticles.Play();
GetComponent<movement>().enabled=false;
Invoke("loadNextlevel",loadLevelDelay);

}

void StartCrashSequence()
{
isTransitioning = true;
GetComponent< AudioSource>().Stop();
GetComponent< AudioSource>().PlayOneShot(crash);
crashParticles.Play();
GetComponent<movement>().enabled=false;
Invoke("Relodlevel",loadLevelDelay);
}


void Relodlevel()
{
int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
SceneManager.LoadScene(currentSceneIndex);
}


void loadNextlevel()
{
int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
int nextSceneIndex = currentSceneIndex+1;
 if(nextSceneIndex>3)
{
    nextSceneIndex = 0;
}
SceneManager.LoadScene(nextSceneIndex);
}

}

