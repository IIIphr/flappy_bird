using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava_animation : MonoBehaviour
{

    [SerializeField] private float animation_speed = 0.01f;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(
            (renderer.material.mainTextureOffset.x - animation_speed) % 1,
            0);
    }
}
