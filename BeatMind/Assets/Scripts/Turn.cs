using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{    
    int rows;
    int columns;
    GameObject[] cells;
    public GameObject cellPrefab;
    public float _distBetweenRows = 2;
    public Transform InitPos;

    private float _distance = 50f;
    private void Start()
    {
        rows = Assignations.Instance.ReturnRows();
        columns = Assignations.Instance.instrumentsNumber;

        cells = new GameObject[rows];

        float l_Dist = 0;
        //TO DO: Sistema para arrastrar la grid  
        for(int i = 0; i<cells.GetLength(0); i++)
        {            
            cells[i] = Instantiate(cellPrefab, InitPos.position + new Vector3(0, l_Dist, 0), Quaternion.identity, transform);            
            l_Dist += _distBetweenRows;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _distance))
            {                
                //Debug.DrawLine(ray.origin, hit.point);                
                Debug.Log(hit.collider.name);
                if(hit.collider.GetComponent<Cell>() != null)                
                    hit.collider.GetComponent<Cell>().ChangeState();                
            }
        }
    }

}
