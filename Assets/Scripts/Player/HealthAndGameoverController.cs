using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HealthAndGameoverController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float unitDamage = 1f;
    public float healAmount = 30f;
    public bool resetHealthOnStart = true;
    public float currentHealth;
    public SliderController healthSlider;
    public ScoreController scoreController;
    public float deathDelayTime = 2f;
    public GameObject postDestroyObject;

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
        StaticValuesHolder.lastScore = scoreController.GetScore();
        scoreController.enabled = false;

        Instantiate(postDestroyObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
