using System.Collections.Generic;
using UnityEngine;

public class ReelBottom : MonoBehaviour
{
    [Header("Settings")]
    public Transform rowTransform;
    public Vector3 startPos;
    public List<GameObject> rowItems;
    public GameObject topItem;
    public float spaceBetweenItems = 1.7f;

    void Start()
    {
        startPos = rowTransform.position;

        if(rowItems.Count > 0)
        {
            AssignTopElement();
        }
    }

    void AssignTopElement()
    {
        GameObject temp = null;
        float highestY = float.MinValue;

        foreach (GameObject item in rowItems)
        {
            if (item.transform.position.y > highestY)
            {
                highestY = item.transform.position.y;
                temp = item;
            }
        }

        topItem = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
#if UNITY_EDITOR
        Debug.Log("Clicked");
#endif

        collision.gameObject.transform.position = 
            new Vector3(
            transform.position.x,
            topItem.transform.position.y + 1.7f,
            transform.position.z
            );

        topItem = collision.gameObject;
    }
}
