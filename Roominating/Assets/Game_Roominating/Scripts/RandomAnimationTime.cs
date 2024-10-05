using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationTime : MonoBehaviour
{
    Animator animator;
    float randomOffset;
    int layer;
    public string State;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        randomOffset = Random.Range(0f, 1f);
        layer = animator.gameObject.layer;
        animator.Play(State,layer,randomOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
