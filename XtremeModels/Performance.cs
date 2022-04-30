namespace XtremeModels
{
    public class Performance
    {
        public Performance(float processor, float ram, float totalRam)
        {
            Processor = processor;
            Ram = ram;
            TotalRam = totalRam;
        }

        public float Processor { get; set; }
        public float Ram { get; set; }

        public float TotalRam { get; set; }
    }
}