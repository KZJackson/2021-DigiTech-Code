using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    public Shader[] Shaders;
    public Renderer Renderer;


    public IEnumerator ChangeShader()
    {
        yield return new WaitForSeconds(5);
        Renderer.material.shader = Shaders[Random.Range(0,6)];
        StartCoroutine(ChangeShader());
    }
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material.shader = Shaders[Random.Range(0,6)];
        StartCoroutine(ChangeShader());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
