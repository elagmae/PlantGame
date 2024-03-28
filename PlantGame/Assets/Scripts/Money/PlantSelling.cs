using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de vendre ses plantes.
/// </summary>
public class PlantSelling : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private GameObject _coinPrefab;

    /* Quand le joueur cliquera sur la plante déjà poussée, il gagnera de l'argent
    (système de vente) */
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var plant = this.GetComponent<PlantGrow>();

        if (plant.HasGrew)
        {
            var coin = Instantiate(_coinPrefab, this.transform.position, this.transform.rotation);
            coin.GetComponent<CoinBehaviour>().CoinMovement();

            MoneyManager.Instance.Sell(_plantData.PriceSell);
            Destroy(this.gameObject);
        }
    }
}
