using System;
using Domain.TvSeries.Enums;

namespace Domain.TvSeries.Entities
{
    public class Series : BaseEntity
    {

        public EGenre Genre { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }

        public Series(EGenre genre, string title, string description, int year)
        {
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            string ret = "";
            ret += $"Genre: {Genre + Environment.NewLine}";
            ret += $"Title: {Title + Environment.NewLine}";
            ret += $"Description: {Description + Environment.NewLine}";
            ret += $"Year: {Year + Environment.NewLine}";

            return ret;
        }

        public void SetGenre(EGenre genre)
        {
            if (genre == EGenre.NotSpecified) return;
            Genre = genre;
        }
        public void SetTitle(string title)
        {
            if (!String.IsNullOrEmpty(title)) return;
            Title = title;
        }
        public void SetDescription(string description)
        {

            if (!String.IsNullOrEmpty(description)) return;
            Description = description;
        }
        public void SetYear(int year)
        {
            if (year <= 0) return;
            Year = year;
        }
    }
}