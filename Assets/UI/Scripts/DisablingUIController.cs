using System.Collections.Generic;
using UnityEngine;

public class DisablingUICOntroller : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<SpriteRenderer> spriteRenderers;
    private bool _isSomethingBetweenObjects;

    
    private void Update()
    {
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.magnitude;
        Debug.DrawRay(transform.position, direction, Color.red);
        bool isSomethingBetweenObjects = Physics.Raycast(transform.position, direction, distance, layerMask);
        
        if (isSomethingBetweenObjects == _isSomethingBetweenObjects)
        {
            return;
        }

        _isSomethingBetweenObjects = isSomethingBetweenObjects;
        //Debug.Log("Swapped " + isSomethingBetweenObjects);
        spriteRenderers.ForEach(spriteRenderer => spriteRenderer.enabled = !isSomethingBetweenObjects);
    }
}
