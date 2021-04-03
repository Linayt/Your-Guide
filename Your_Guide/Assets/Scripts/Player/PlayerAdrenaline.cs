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

    [Header("Sign/Feedback")]
    [SerializeField] private SkinnedMeshRenderer hatMeshRenderer;
    
    [SerializeField] private Gradient EmissionColor;
    [SerializeField] private float maxEmissionIntensity;
    private enum adrenalineEtat { Nothing, Switch,Heal}
    private adrenalineEtat etat;

    [HideInInspector]
    public float adrenalineValue;

    // Start is called before the first frame update
    private void Awake()
    {
        adrenalineValue = adrenalineStartValue;
        pControler = transform.GetComponent<PlayerControler>();
        etat = adrenalineEtat.Nothing;
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

    public void AddAdrenalineValue(float value)
    {
        adrenalineValue += value;
        adrenalineValue = Mathf.Clamp(adrenalineValue, 0, adrenalineMaxValue);
    }

    public bool canHeal()
    {



        return false;
    }


    public void SetFeedBackColor()
    {
        bool canSwitch = pControler.pSwitch.IsInRange() && IsAdrenalineMax();
        bool canheal = canHeal();
        Material hatMateriel = hatMeshRenderer.material;

        if (canSwitch/*&&!canheal*/)
        {
            //hatMateriel.SetColor("_EmissiveColor", EmissionColor.Evaluate(0));
            hatMateriel.SetColor("_BaseColor", EmissionColor.Evaluate(0));
            Debug.Log("ColorChange");
        }
        else if (canheal)
        {

        }
        else
        {
            //hatMateriel.SetColor("_EmissiveColor", EmissionColor.Evaluate(0.5f));
            hatMateriel.SetColor("_BaseColor", EmissionColor.Evaluate(0.5f));
        }
    }
}
