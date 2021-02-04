using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemiFX : MonoBehaviour
{
    EnemiControler eControler;

    [SerializeField] private VisualEffect attaqueFX;
    [SerializeField] private string eventAttackName;
    [SerializeField] private string eventDegatName;
    [SerializeField] private string positionSpawnDegatName;

    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();

    }

    public IEnumerator StartFxAttack(float time)
    {
        yield return new WaitForSeconds(time);
        attaqueFX.SendEvent(eventAttackName);
    }

    public void startCoroutineFxAttack(float time)
    {
        StartCoroutine(StartFxAttack(time));
    }

    public void StartFxDegat(Vector3 position)
    {
        attaqueFX.SetVector3(positionSpawnDegatName, position);
        attaqueFX.SendEvent(eventDegatName);
    }

}
