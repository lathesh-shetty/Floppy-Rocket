
using UnityEngine;
using UnityEngine.SceneManagement;


public class collisonHandler : MonoBehaviour
{
   [SerializeField] float loadLevelDelay = 2f;
   [SerializeField] AudioClip win;
   [SerializeField] AudioClip crash;

   bool isTransitioning = false;

   private void OnCollisionEnter(Collision other)
   {
    if(isTransitioning)
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
GetComponent<movement>().enabled=false;
Invoke("loadNextlevel",loadLevelDelay);

}

void StartCrashSequence()
{
isTransitioning = true;
GetComponent< AudioSource>().Stop();
GetComponent< AudioSource>().PlayOneShot(crash);
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
 if(nextSceneIndex>SceneManager.sceneCount)
{
    nextSceneIndex = 0;
}
SceneManager.LoadScene(nextSceneIndex);
}

}

