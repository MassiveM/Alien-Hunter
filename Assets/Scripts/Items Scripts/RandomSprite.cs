using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RandomSprite : MonoBehaviour
{
    private Sprite[] _sprites;

    [SerializeField]
    private string resourceName;

    [SerializeField]
    private int currentSprite = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (resourceName != "")
        {
            _sprites = Resources.LoadAll<Sprite>(resourceName);
            if (currentSprite == -1)
            {
                currentSprite = Random.Range(0, _sprites.Length);
            } 
            else if (currentSprite >= _sprites.Length)
            {
                currentSprite = _sprites.Length - 1;
            }
            
            GetComponent<SpriteRenderer>().sprite = _sprites[currentSprite];
        }
    }
}
