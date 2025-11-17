using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTargetArrow : MonoBehaviour
{
    [SerializeField] private string targetTag = "Coin";
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform arrowUI;
    

    // Update is called once per frame
    void Update()
    {
        Transform near = FindTarget();
        if(near == null)
        {
            arrowUI.gameObject.SetActive(false);
            return;
        }
        arrowUI.gameObject.SetActive(true);
        ArrowTo(near);
    }

    private Transform FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        Transform near = null;
        float nearDis = Mathf.Infinity;

        foreach(GameObject target in targets)
        {
            float dis = Vector3.Distance(player.position, target.transform.position);
            if(dis < nearDis)
            {
                nearDis = dis;
                near = target.transform;
            }
        }
        return near;
    }
    private void ArrowTo(Transform target)
    {
        Vector3 dir = target.position - player.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        arrowUI.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
