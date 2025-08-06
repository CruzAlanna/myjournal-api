using System.Linq;
using MyJournalApi.Models;

namespace MyJournalApi.Data
{
    public static class DbSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Reflections.Any())
            {
                context.Reflections.AddRange(
                    new Reflection { Date = "August 1, 2025", Mood = "Relaxed", High = "Swimming in the pool", Low = "Mamie was cranky", Log = "Today was a good day. My baby loves the water and she's starting to want to stay on the ladder with no assistance." },
                    new Reflection { Date = "August 2, 2025", Mood = "Sadness", High = "Watched a really good movie", Low = "Struggling mentally & emotionally", Log = "Hormones are so crazy. Got my period, which sucks. Today I cried so many times lol. The sadness stems from loneliness. Elijah has been working so much lately. Everyone left so the dogs are sad, Mamie doesn't understand so she's cranky. It's a mess of a day. The movie I watched was so good, but had a French ending so- also sad lol, but 10/10 none the less." },
                    new Reflection { Date = "August 3, 2025", Mood = "Vegetable", High = "Lounging around", Low = "Feeling not so good", Log = "Today was kinda nice. I didn't really have energy today, but I got to play with Mamie the entire day and not stare at a screen for forever." },
                    new Reflection { Date = "August 4, 2025", Mood = "Sick", High = "Had a productive day", Low = "Feeling physically horrible", Log = "Today was alright. I felt really good bc I ran so many errands and cleaned the house, but I ended up feeling really horrible towards the end of the day. Not fun." },
                    new Reflection { Date = "August 5, 2025", Mood = "Busy", High = "Got so much done", Low = "Mamie watched TV all day...", Log = "As much as I want to cut back on screen time, I really needed to get on my laptop. That sacrifice kinda sucks and hurts my heart..." }
                );
                context.SaveChanges();
            }
        }
    }
}