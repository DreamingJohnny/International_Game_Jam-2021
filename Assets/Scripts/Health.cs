using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Properties")]
    public float startingHealth;
    public float internalHealth;

    private void Awake()
    {
        internalHealth = startingHealth;
    }

    public void ModifyHealth(float damage)
    {
        internalHealth -= damage;

        internalHealth = Mathf.Clamp(internalHealth, 0, startingHealth);

        if (internalHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}