using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackJack;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CardGenerator>().GetCard(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
