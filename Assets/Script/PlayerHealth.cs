using System.Collections;
using UnityEngine;
using UnityEngine.Events; // For UnityEvent

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    public float currentHealth;

    public UnityEvent OnDeath; // Event for when health reaches zero
    public UnityEvent<float> OnHealthChanged; // Event for when health changes (optional)
    public GameObject HurtSound;
    public GameObject HurtText;

    public Healthbar Healthbar;

    void Awake()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        OnHealthChanged?.Invoke(currentHealth); // Invoke health changed event
        Healthbar.SetHealth(currentHealth);
        StartCoroutine(PlayHurtSound());
        StartCoroutine(PlayHurtText());

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the player object
            OnDeath?.Invoke(); // Invoke death event
            // Optionally, destroy the GameObject here
            // Destroy(gameObject); 
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    IEnumerator PlayHurtSound()
    {
        
        HurtSound.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        HurtSound.SetActive(false);
    }
    IEnumerator PlayHurtText()
    {
        HurtText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        HurtText.SetActive(false);
    }
}
