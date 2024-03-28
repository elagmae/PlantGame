using TMPro;
using UnityEngine;

/// <summary>
/// Affichage et gestion de l'argent total du joueur.
/// </summary>
public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _moneyUI;

    /* Singleton utilisé pour la gestion d'argent (variable Money) : sa valeur est modifiée
    différemment par plusieurs scripts */
    public static MoneyManager Instance { get; private set; }

    [field: SerializeField]
    public float Money { get; private set; }

    // Retire de l'argent au joueur à chaque achat de graine
    public void Depense(float depense)
    {
        if (Money >= depense)
        {
            Money -= depense;
        }
    }

    // Ajoute de l'argent au joueur à chaque vente de plante
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
        // gère la valeur de l'argent dans l'UI
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
