using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour
{
    //float screenWidth;
    public float backgroundSpeed = 0.5f;
    SpriteRenderer backgroundSpriteRenderer;
    void Start()
    {
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float offset = Time.time * backgroundSpeed;
        backgroundSpriteRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
