using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class SkullObjectPool : MonoBehaviour
{
    [Header ("Pool Container")]
    [SerializeField] Transform skullPoolContainer;

    [Header("Pool Prefab")]
    [SerializeField] GameObject skullPrefab;

    [SerializeField] private float minimumAmount = 5f;

    // Creo una lista de GameObjects
    private List<GameObject> skullPool = new List<GameObject>();

    void Start()
    {
        // Creo los objetos de cada pool
        for (int i = 0; i < minimumAmount; i++)
        {
            CreateNewObjectSkull();
        }
    }

    // Funciones para instanciar cada obtáculo en cada lista de pool
    GameObject CreateNewObjectSkull()
    {
        // Instancio el prefab del cuervo y lo guardo en su respectivo objeto padre
        GameObject obj = Instantiate(skullPrefab, skullPoolContainer);

        // Añado el objeto creado a la lista
        skullPool.Add(obj);

        // Desactivo el objeto
        obj.SetActive(false);

        // Devuelvo el objeto
        return obj;
    }

    // Funciones para utilizar los objetos creados en las pools
    public GameObject GetObjectSkull()
    {
        // Busco en mi lista un objeto desactivado de la lista (Del pool)
        GameObject obj = skullPool.Find(x => x.activeSelf == false);

        // Si todos los objetos se encuentran activos y por lo tanto devolveria null
        if (obj == null)
        {
            // Creo un nuevo objeto
            CreateNewObjectSkull();
        }

        // Devuelvo el objeto
        return obj;
    }
}
