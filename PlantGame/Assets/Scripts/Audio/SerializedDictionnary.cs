using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de créer des dictionnaires sérialisés avec les types de clés et de valeurs voulues
/// Dans ce contexte, ce script sera relié à l'audio Manager afin de lui permettre de gérer
/// les sons. (Merci à Lyta pour le code et l'explication).
/// </summary>
/// <typeparam name="TKey"> Type de clé. </typeparam>
/// <typeparam name="TValue"> Type de valeur. </typeparam>
[Serializable]
public class SerializedDictionnary<TKey, TValue>
{
    /// <summary>
    /// Une liste qui contient tous les éléments du dictionnaire (clé et valeur sur un seul index).
    /// </summary>
    [SerializeField]
    private List<Element> _elements;

    /// <summary>
    /// Permet d'utiliser le dictionnaire dans les autres scripts
    /// (en utilisant les crochets pour spécifier la clé de ce que l'on recherche).
    /// </summary>
    /// <param name="key"> Clé à rechercher. </param>
    public TValue this[TKey key]
    {
        get
        {
            var elm = _elements.Find((element) => { return element.Key.Equals(key); });
            return elm.Value;
        }
    }

    /// <summary>
    /// Le struct de l'élément : (une clé et une valeur).
    /// </summary>
    [Serializable]
    private struct Element
    {
        [field: SerializeField]
        public TKey Key { get; set; }

        [field: SerializeField]
        public TValue Value { get; set; }
    }
}
