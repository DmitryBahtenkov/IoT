using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace IoT.Api.System.Models
{
    public class DataDocument
    {
        public ObjectId Id { get; set; }
        /// <summary>
        /// Температура
        /// </summary>
        public double Temp { get; set; }
        /// <summary>
        /// Влажность
        /// </summary>
        public double Humidity { get; set; }
        /// <summary>
        /// Давление
        /// </summary>
        public double Pressure { get; set; }
        /// <summary>
        /// Уровень радиации
        /// </summary>
        public double Radiation { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public int Hour { get; set; }
    }
}