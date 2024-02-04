using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Test : MonoBehaviour
{
    private CardGeneratorFromResources generator;
    // Start is called before the first frame update
    async void Start()
    {
        generator = new CardGeneratorFromResources();
        bool isDone = await generator.Load();
        if (isDone)
        {
            foreach (var keyValuePair in generator.MaterialDict)
            {
                Debug.Log($"Key:Num{keyValuePair.Key.Number} Type{keyValuePair.Key.Type}  Value:{keyValuePair.Value.name}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
