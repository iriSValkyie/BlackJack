using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CardGeneratorFromResources generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = new CardGeneratorFromResources();
        generator.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
