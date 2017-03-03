using System.Collections.Generic;
using UnityEngine;

namespace RandomFromDistributions
{
    public class CustomPDFTestScript : MonoBehaviour
    {
        public bool update = false;

        public int repetitions = 1000;
        public int width = 25;

        private GameObject graph;


        public float[] distribution;

        // Use this for initialization
        private void Start()
        {
            graph = CreateGraph();
        }

        // Update is called once per frame
        private void Update()
        {
            if (update)
            {
                Destroy(graph);
                graph = CreateGraph();
            }
        }


        private GameObject CreateGraph()
        {
            var buckets = new int[distribution.Length]; // add one, because RandomRangeNormalDistribution is inclusive.
            for (var i = 0; i < buckets.Length; ++i) buckets[i] = 0;

            for (var i = 0; i < repetitions; ++i)
            {
                var bucket = GetRandomNumber();

                buckets[Mathf.RoundToInt(bucket)]++;
            }

            // Display how many times each bucket was drawn by creating a bunch of dots in the scene. 
            var graph = new GameObject("Graph");
            graph.transform.parent = transform;
            graph.transform.localPosition = new Vector3(0, 0, 0);
            for (var i = 0; i < distribution.Length; ++i)
            {
                float height = buckets[i] + 1;
                var new_dot = GameObject.CreatePrimitive(PrimitiveType.Cube);
                new_dot.transform.parent = graph.transform;
                new_dot.transform.localPosition = new Vector3(i * width, height / 2.0f, 0);
                new_dot.transform.localScale = new Vector3(width, height, 1);
            }
            return graph;
        }

        protected float GetRandomNumber()
        {
            return RandomFromDistribution.RandomChoiceFollowingDistribution(new List<float>(distribution));
        }
    }
}