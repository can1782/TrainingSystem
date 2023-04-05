using System;

namespace TrainingSystem.Services.Training.Models
{
    [Dapper.Contrib.Extensions.Table("training")]
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
