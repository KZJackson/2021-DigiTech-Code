using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    public Shader[] Shaders; //The list of shaders to shuffle around
    public Renderer Renderer; //The object's renderer component

    //The function to shuffle the shaders on the landscape
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
}
