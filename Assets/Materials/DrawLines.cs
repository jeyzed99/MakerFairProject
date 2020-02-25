using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DrawLines : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject linePointPrefab;

    public string InputName;
    public XRNode NodeType;
    public Vector3 start;
    private Vector3 _lastFramePosition;
    public bool begin;

    private void Start()
    {
        _lastFramePosition = transform.position;
        begin = false;
    }

    private void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(NodeType);
        if(Input.GetAxis(InputName)>= 0.01f && !begin)
        {
            start = InputTracking.GetLocalPosition(NodeType);
            begin = true;
        }
        if (begin)
        {
            
            if (Input.GetAxis(InputName) >= 0.01f)
            {
              
                SpawnLineGenerator();
            }
            else
            {
                begin = false;
            }
        }

    }




    private void SpawnLineGenerator()
    {
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        Vector3 first = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 second = new Vector3(0.0f, 0.738f, 0.0f);

        lRend.SetPosition(0, start);
        lRend.SetPosition(1, transform.position);

        Destroy(newLineGen, 5);
    }


}
