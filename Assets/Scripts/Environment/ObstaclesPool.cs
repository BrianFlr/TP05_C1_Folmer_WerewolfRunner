using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [Header ("Pool Containers")]
    [SerializeField] Transform crowPoolContainer;
    [SerializeField] Transform skullPoolContainer;
    [SerializeField] Transform toadPoolContainer;

    [Header("Pool Prefabs")]
    [SerializeField] GameObject crowPrefab;
    [SerializeField] GameObject skullPrefab;
    [SerializeField] GameObject toadPrefab;

    [SerializeField] private float minimumAmount = 5f;

    // Creo una lista de GameObjects
    private List<GameObject> crowPool = new List<GameObject>();
    private List<GameObject> skullPool = new List<GameObject>();
    private List<GameObject> toadPool = new List<GameObject>();

    void Start()
    {
        // Creo los objetos de cada pool
        for (int i = 0; i < minimumAmount; i++)
        {
            CreateNewObjectCrow();
            CreateNewObjectSkull();
            CreateNewObjectToad();
        }
    }

    // Funciones para instanciar cada obtáculo en cada lista de pool
    GameObject CreateNewObjectCrow()
    {
        // Instancio el prefab del cuervo y lo guardo en su respectivo objeto padre
        GameObject obj = Instantiate(crowPrefab, crowPoolContainer);

        // Añado el objeto creado a la lista
        crowPool.Add(obj);

        // Desactivo el objeto
        obj.SetActive(false);

        // Devuelvo el objeto
        return obj;
    }

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

    public GameObject GetObjectCrow()
    {
        // Busco en mi lista un objeto desactivado de la lista (Del pool)
        GameObject obj = crowPool.Find(x => x.activeSelf == false);

        // Si todos los objetos se encuentran activos y por lo tanto devolveria null
        if (obj == null)
        {
            // Creo un nuevo objeto
            CreateNewObjectCrow();
        }

        // Devuelvo el objeto
        return obj;
    }
}
