﻿namespace BillB0ard_API.Domain.Entities
{
    public class MovieEntity
    {
        public MovieEntity(int id, string title, string? poster, DateTime addedDate, DateTime? seenDate)
        {
            this.Id = id;
            this.Title = title;
            this.Poster = poster;
            this.AddedDate = addedDate;
            this.SeenDate = seenDate;
        }
        public int Id { get; }
        public string Title { get; }
        public string? Poster { get; }
        public DateTime AddedDate { get; }
        public DateTime? SeenDate { get; }
        public List<RateEntity>? Rates { get; set; } = null;
        public decimal? AverageRate => Rates?.Average(r => r.Rate);
        public decimal? LowestRates => Rates?.Min(r => r.Rate);
        public decimal? TopRate => Rates?.Max(r => r.Rate);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MovieEntity toCompare = (MovieEntity)obj;
            return Id.Equals(toCompare.Id) && Title == toCompare.Title
                && Poster == toCompare.Poster && AddedDate == toCompare.AddedDate
                && SeenDate == toCompare.SeenDate && Rates == toCompare.Rates;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Title.GetHashCode() + AddedDate.GetHashCode() + SeenDate.GetHashCode();
        }
    }
}
