using System;
using TvSeries.Domain.Enums;

namespace TvSeries.Domain.Entities
{
    public class Series : BaseEntity
    {

        public EGender Gender { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }

        public Series(EGender gender, string title, string description, int year)
        {
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            string ret = "";
            ret += $"Gender: {Gender + Environment.NewLine}";
            ret += $"Title: {Title + Environment.NewLine}";
            ret += $"Description: {Description + Environment.NewLine}";
            ret += $"Year: {Year + Environment.NewLine}";

            return ret;
        }

        public void SetGender(EGender gender)
        {
            if (gender == EGender.NotSpecified) return;
            Gender = gender;
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