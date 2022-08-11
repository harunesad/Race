using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Material material;
    public static RandomColor instance;

    public Color color;
    public Renderer rend;

    int options;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        options = Random.Range(1, 3);
        switch (options)
        {
            case 1:
                color = Random.ColorHSV(0, 0.4f, 0, 1, 0, 0.5f);
                break;
            case 2:
                color = Random.ColorHSV(0.8f, 1f, 0, 1, 0, 0.5f);
                break;
            default:
                break;
        }
        material.color = color;
    }
}
