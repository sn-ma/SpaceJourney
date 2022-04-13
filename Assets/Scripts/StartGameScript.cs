using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Constants.Scenes.GameScene);
        Debug.Log("I'm still alive!");
    }
}
