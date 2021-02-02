using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CurrencyManager>();
            }
            return instance;
        }
    }

    public int Currency { get; private set; }

    public void ModifyCurrency(int amount)
    {
        Currency += amount;
    }
}

