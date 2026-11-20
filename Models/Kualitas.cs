namespace AGRIVA.Models
{
    /// <summary>Data master kualitas panen dan persentase penalti.</summary>
    public class Kualitas
    {
        public int IdKualitas { get; set; }
        public string NamaKualitas { get; set; }
        public double PersenPenalti { get; set; }
    }
}
