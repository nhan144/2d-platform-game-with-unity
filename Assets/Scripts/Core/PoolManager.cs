using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [Header("Effect")]
    [SerializeField]
    private GameObject EffectContainer;
    [SerializeField]
    private GameObject EffectPrefab;
    [SerializeField]
    private List<GameObject> effectPool;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        Generate(4, EffectPrefab);
    }

    List<GameObject> Generate(int number, GameObject effectPrefab)
    {
        for (int i = 0; i < number; i ++)
        {
            GameObject clone = Instantiate(effectPrefab);
            clone.transform.parent = EffectContainer.transform;
            clone.SetActive(false);
            effectPool.Add(clone);
        }
        return effectPool;
    }

    public GameObject SpamItems(List<GameObject> itemPool,GameObject itemToPool, GameObject containerItem)
    {
        foreach (var item in itemPool)
        {
            if (item.activeInHierarchy == false)
            {
                item.SetActive(true);
                return item;
            }
        }

        GameObject newClone = Instantiate(itemToPool);
        newClone.transform.parent = containerItem.transform;
        itemPool.Add(newClone);

        return newClone;
    }

    public GameObject SpamEffect()
    {
        return SpamItems(effectPool, EffectPrefab, EffectContainer);
    }
    //public static void Reset()
    //{
    //    this.Clear();
    //}
}
