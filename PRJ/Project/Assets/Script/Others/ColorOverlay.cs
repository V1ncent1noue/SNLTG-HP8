using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOverlay : MonoBehaviour
{
    private Color damageColor = Color.red;
    private Color healColor = Color.green;
    [SerializeField] private float colorDuration = 0.1f;
    private Coroutine flashCoroutine;

    private SpriteRenderer[] spriteRenderers;
    private Material[] materials;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        getMats();
    }

    void getMats()
    {
        materials = new Material[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            materials[i] = spriteRenderers[i].material;
        }
    }

    public void ApplyFlashColor(Color color)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashColor(color));
    }
    private IEnumerator FlashColor(Color color)
    {
        //set color
        SetFlashColor(color);

        //lerp color
        float elapsedTime = 0f;
        float currentFlashAmount = 0f;
        while (elapsedTime < colorDuration)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedTime / colorDuration);
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }

    private void SetFlashColor(Color color)
    {
        foreach (Material material in materials)
        {
            material.SetColor("_FlashColor", color);
        }
    }
    private void SetFlashAmount(float amount)
    {
        foreach (Material material in materials)
        {
            material.SetFloat("_FlashAmount", amount);
        }
    }
}
