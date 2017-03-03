namespace RandomFromDistributions
{
    public class LinearTestScript : DistributionTestScript
    {
        public float slope = 1.0f;

        public override float GetRandomNumber(float min, float max)
        {
            return RandomFromDistribution.RandomRangeLinear(min, max, slope);
        }
    }
}