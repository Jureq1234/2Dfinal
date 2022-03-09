using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    [Header("naglowek-zycie")]

    [Header("kolor change")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRend;   // referencja do koloru


    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float _damage)
    {
        StartCoroutine(Invunerability());   // zeby metoda zadziałałą mysumy wywołać to z starto curere

        // jak sie spotkają 

    }
    private IEnumerator Invunerability()
    {
       
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            print(i);
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }


}
