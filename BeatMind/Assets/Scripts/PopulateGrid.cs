using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prefab;

    private int count = 0;

    public void Populate(int quantity)
    {
        GameObject newObj;

        for(int i = 0; i < quantity; i++)
        {
            count++;
            newObj = (GameObject)Instantiate(prefab, transform);
        }
    }

    public void clean()
    {
        foreach(Transform a in this.transform)
        {
            Destroy(a.gameObject);
        }
    }
}
