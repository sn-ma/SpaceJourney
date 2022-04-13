using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndGameoverController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float unitDamage = 1f;
    public float healAmount = 30f;
    public bool resetHealthOnStart = true;
    public float currentHealth;
    public SliderController healthSlider;

    public void Start()
    {
        if (resetHealthOnStart)
        {
            AddAndDisplayHealth(maxHealth);
        } else
        {
            AddAndDisplayHealth(currentHealth);
        }
    }

    public void TakeDamageOnCollision(float impulse)
    {
        AddAndDisplayHealth(- impulse * unitDamage);
    }

    public void TakeHeal()
    {
        AddAndDisplayHealth(healAmount);
    }

    private void AddAndDisplayHealth(float deltaHealth)
    {
        currentHealth += deltaHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.SetNormalizedValue(currentHealth / maxHealth);

        // TODO: play heal, damage or death sounds

        if (currentHealth <= 0f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game over");
        // TODO: play some death animation
        // TODO: show the end-of-game screen instead of reloading level immediately
        SceneManager.LoadScene(Constants.Scenes.PauseScene);
    }
}
