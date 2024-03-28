using TMPro;
using UnityEngine;

/// <summary>
/// Affichage et gestion de l'argent total du joueur.
/// </summary>
public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _moneyUI;

    public static MoneyManager Instance { get; private set; }

    [field: SerializeField]
    public float Money { get; private set; }

    public void Depense(float depense)
    {
        if (Money >= depense)
        {
            Money -= depense;
        }
    }

    public void Sell(float receipt)
    {
        Money += receipt;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        _moneyUI.text = Money.ToString();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
