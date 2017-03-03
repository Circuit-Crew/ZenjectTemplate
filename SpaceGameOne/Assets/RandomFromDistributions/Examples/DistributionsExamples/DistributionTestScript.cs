using UnityEngine;

namespace RandomFromDistributions
{
    public abstract class DistributionTestScript : MonoBehaviour
    {
        public bool update = false;

        public int repetitions = 1000;
        public int min = -25;
        public int max = 25;

        private GameObject graph;

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
            var buckets = new int[max + 1 - min]; // add one, because RandomRangeNormalDistribution is inclusive.
            for (var i = 0; i < buckets.Length; ++i) buckets[i] = 0;

            for (var i = 0; i < repetitions; ++i)
            {
                var bucket = GetRandomNumber(min, max);

                buckets[Mathf.RoundToInt(bucket) - min]++;
            }

            // Display how many times each bucket was drawn by creating a bunch of dots in the scene. 
            var graph = new GameObject("Graph");
            graph.transform.parent = transform;
            graph.transform.localPosition = new Vector3(0, 0, 0);
            for (var i = min; i < max; ++i)
            {
                float height = buckets[i - min] + 1;
                var new_dot = GameObject.CreatePrimitive(PrimitiveType.Cube);
                new_dot.transform.parent = graph.transform;
                new_dot.transform.localPosition = new Vector3(i, height / 2.0f, 0);
                new_dot.transform.localScale = new Vector3(1, height, 1);
            }
            return graph;
        }

        public abstract float GetRandomNumber(float min, float max);
    }
}