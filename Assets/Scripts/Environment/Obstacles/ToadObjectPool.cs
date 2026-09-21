using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ToadObjectPool : MonoBehaviour
{
    [Header ("Pool Container")]
    [SerializeField] Transform toadPoolContainer;

    [Header("Pool Prefab")]
    [SerializeField] GameObject toadPrefab;

    [SerializeField] private float minimumAmount = 5f;

    // Creo una lista de GameObjects
    private List<GameObject> toadPool = new List<GameObject>();

    void Start()
    {
        // Creo los objetos de cada pool
        for (int i = 0; i < minimumAmount; i++)
        {
            CreateNewObjectToad();
        }
    }

    // Funciones para instanciar cada obtáculo en cada lista de pool
    GameObject CreateNewObjectToad()
    {
        // Instancio el prefab del cuervo y lo guardo en su respectivo objeto padre
        GameObject obj = Instantiate(toadPrefab, toadPoolContainer);

        // Añado el objeto creado a la lista
        toadPool.Add(obj);

        // Desactivo el objeto
        obj.SetActive(false);

        // Devuelvo el objeto
        return obj;
    }

    // Funciones para utilizar los objetos creados en las pools
    public GameObject GetObjectToad()
    {
        // Busco en mi lista un objeto desactivado de la lista (Del pool)
        GameObject obj = toadPool.Find(x => x.activeSelf == false);

        // Si todos los objetos se encuentran activos y por lo tanto devolveria null
        if (obj == null)
        {
            // Creo un nuevo objeto
            CreateNewObjectToad();
        }

        // Devuelvo el objeto
        return obj;
    }
}
