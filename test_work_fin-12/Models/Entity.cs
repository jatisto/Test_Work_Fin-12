using System;
namespace test_work_fin_12.Models
{
    public class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}