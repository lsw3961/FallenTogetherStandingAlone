using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{
    public InputReader reader;
    [SerializeField]
    GameObject obj2;
    [SerializeField]
    GameObject obj1;
    [SerializeField]
    private float number;

    // Start is called before the first frame update
    public void Start()
    {
        obj1.SetActive(true);
        obj2.SetActive(false);
    }
    void OnEnable()
    {
        reader.Swap += ScrollValue;
    }
    private void OnDisable()
    {
        reader.Swap -= ScrollValue;
    }
    public void ScrollValue(float arg)
    {
        number = arg;
        if (number < 0)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
        }
        else if (number > 0)
        {
            obj2.SetActive(true);
            obj1.SetActive(false);

        }
    }
}
