using System.Collections.Generic;
using UnityEngine;

public class ClippingUIController : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material noclipMaterial;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private List<SpriteRenderer> spriteRenderer;
    [SerializeField] private LayerMask layerMask;
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
        Material newMaterial = isSomethingBetweenObjects ? defaultMaterial : noclipMaterial;
        //Debug.Log("Swap " + newMaterial.name);
        spriteRenderer.ForEach(sr => sr.material = newMaterial);
    }
}
