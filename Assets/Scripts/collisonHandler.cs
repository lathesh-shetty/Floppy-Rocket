
using UnityEngine;
using UnityEngine.SceneManagement;


public class collisonHandler : MonoBehaviour
{
   
   private void OnCollisionEnter(Collision other)
   {
    switch (other.gameObject.tag)
    {
        case "Friendly":
            Debug.Log("Friendly");
            break;
        case "Finish":
            Invoke("loadNextlevel",1f);
            break; 
        default:
            Invoke("Relodlevel",1f);
            break;
    }
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
if(nextSceneIndex == SceneManager.sceneCountInBuildSettings);
{
    nextSceneIndex = 0;
}
SceneManager.LoadScene(nextSceneIndex);
}

}

