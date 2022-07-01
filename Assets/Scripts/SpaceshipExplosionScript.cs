using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipExplosionScript : MonoBehaviour
{
    [SerializeField]
    private float deathDelayTime = 2f;

    public void OnParticleSystemStopped()
    {
        StartCoroutine(DelayedLoadMenu());
    }

    private IEnumerator DelayedLoadMenu()
    {
        yield return new WaitForSeconds(deathDelayTime);
        SceneManager.LoadScene(Constants.Scenes.PauseScene);
    }
}
