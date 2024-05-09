using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;

public class PlantDetection : MonoBehaviour
{
    public NNModel modelAsset;
    private Model m_RuntimeModel;
    private IWorker m_Worker;

    void Start()
    {
        m_RuntimeModel = ModelLoader.Load(modelAsset);
        m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, m_RuntimeModel);


        
    }

    void Update()
    {
        Tensor input = new Tensor(1, 640, 640, 3);
        m_Worker.Execute(input);
        Tensor O = m_Worker.PeekOutput("output");
        Debug.Log(O);
        input.Dispose();
    }

}
