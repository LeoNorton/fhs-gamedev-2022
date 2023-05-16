using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TrainScript : MonoBehaviour
{

    [SerializeField] private List<Button> trainStops;
    private int stopNumber;
    private int targetStop;
    private bool traveling;

    // Start is called before the first frame update
    void Start()
    {
        traveling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToStop(int target)
    {
        if (traveling) return;
        traveling = true;
        Sequence s = DOTween.Sequence();
        s.Append(transform.DORotate(new Vector3(0, target > stopNumber ? 0 : 180, 0), 0.5f));
        while (target != stopNumber)
        {
            if (target > stopNumber)
            {
                stopNumber++;
            }
            else
            {
                stopNumber--;
            }
            s.Append(transform.DOMove(trainStops[stopNumber].transform.position, 1f));

        }
        s.OnComplete(() => traveling = false);
    }



}
