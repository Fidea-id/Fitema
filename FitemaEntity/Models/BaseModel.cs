﻿
namespace FitemaEntity.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
