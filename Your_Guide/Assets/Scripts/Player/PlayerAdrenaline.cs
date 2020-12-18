using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAdrenaline : MonoBehaviour
{
    private PlayerControler pControler;

    [Header("Adrenaline")]
    [SerializeField] private float adrenalineStartValue;
    [SerializeField] private float adrenalineMaxValue;

    [SerializeField] private Image jaugeFillImage;

    [HideInInspector]
    public float adrenalineValue;

    // Start is called before the first frame update
    private void Awake()
    {
        adrenalineValue = adrenalineStartValue;
        pControler = transform.GetComponent<PlayerControler>();
    }

    public void SetJaugeFillValue()
    {
        float fillAmount = adrenalineValue / adrenalineMaxValue;
        jaugeFillImage.fillAmount = fillAmount;
    }

    public bool IsAdrenalineMax()
    {
        bool isMax = adrenalineValue == adrenalineMaxValue;
        return isMax;
    }
}
