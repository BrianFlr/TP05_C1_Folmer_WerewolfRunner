using System.Collections.Generic;
using UnityEngine;

public class CoinObjectPool : MonoBehaviour
{
    [Header ("Pool Container")]
    [SerializeField] Transform coinPoolContainer;

    [Header("Pool Prefab")]
    [SerializeField] GameObject coinPrefab;

    [SerializeField] private float minimumAmount = 3f;

    // Creo una lista de GameObjects
    private List<GameObject> coinPool = new List<GameObject>();

    void Start()
    {
        // Creo los objetos de cada pool
        for (int i = 0; i < minimumAmount; i++)
        {
            CreateNewObjectCoin();
        }
    }

    // Funciones para instanciar cada obtáculo en cada lista de pool
    GameObject CreateNewObjectCoin()
    {
        // Instancio el prefab del cuervo y lo guardo en su respectivo objeto padre
        GameObject obj = Instantiate(coinPrefab, coinPoolContainer);

        // Añado el objeto creado a la lista
        coinPool.Add(obj);

        // Desactivo el objeto
        obj.SetActive(false);

        // Devuelvo el objeto
        return obj;
    }

    // Funciones para utilizar los objetos creados en las pools
    public GameObject GetObjectCoin()
    {
        // Busco en mi lista un objeto desactivado de la lista (Del pool)
        GameObject obj = coinPool.Find(x => x.activeSelf == false);

        // Si todos los objetos se encuentran activos y por lo tanto devolveria null
        if (obj == null)
        {
            // Creo un nuevo objeto
            CreateNewObjectCoin();
        }

        // Activo el objeto seleccionado de la lista (Del pool)
        obj.SetActive(true);

        // Devuelvo el objeto
        return obj;
    }
}
