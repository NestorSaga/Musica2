using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        PopulateList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopulateList()
    {
        List<string> names = new List<string> { "EASY", "MEDIUM", "HARD" };
        
    }
}
