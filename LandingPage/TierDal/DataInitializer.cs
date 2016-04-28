using System.Collections.Generic;
using LandingPage.Models;

namespace LandingPage.TierDal
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LpContext>
    {
        protected override void Seed(LpContext context)
        {
            var owners = new List<Owner>
            {
                new Owner {Email = "simonbor@gmail.com", FullName = "Simon Borsky"},
                new Owner {Email = "freakachoo.corp@gmail.com", FullName = "Eugene Leibovich"}
            };
            owners.ForEach(o=>context.Owners.Add(o));
            context.SaveChanges();

            var cultures = new List<Culture>
            {
                new Culture() {CultureId = 1, CultureName = "en-us", CultureTitle = "English"},
                new Culture() {CultureId = 2, CultureName = "il-he", CultureTitle = "Hebrew"},
                new Culture() {CultureId = 3, CultureName = "ru-ru", CultureTitle = "Russian"},
                new Culture() {CultureId = 4, CultureName = "de-de", CultureTitle = "German (Germany)"},
                new Culture() {CultureId = 5, CultureName = "zh-CN", CultureTitle = "Chinese (PRC)"},
                new Culture() {CultureId = 6, CultureName = "ja-JP", CultureTitle = "Japanese (Japan)"},
            };

            cultures.ForEach(culture=>context.Cultures.Add(culture));
            context.SaveChanges();

            var contents = new List<Content>
            {
                new Content() {CultureId = 1, Key = "PageTitle", Value = "The Title"},
                new Content() {CultureId = 1, Key = "PageDescription", Value = "The Slogan Motivator"},
                new Content() {CultureId = 1, Key = "CeoTitle", Value = ""},
                new Content() {CultureId = 1, Key = "CeoDescription", Value = ""},
                new Content() {CultureId = 1, Key = "CeoKeywords", Value = ""},
                new Content() {CultureId = 1, Key = "Motivator", Value = "Allow the buyer see the real item price by simple barcode scanning"},
                new Content() {CultureId = 1, Key = "Motivator", Value = "Automatically add all wanted items to the list calculating total price"},
                new Content() {CultureId = 1, Key = "Motivator", Value = "See current actions by specific shop"},
                new Content() {CultureId = 1, Key = "Motivator", Value = "Compare prices between other shops"},
                new Content() {CultureId = 1, Key = "Motivator", Value = "Allow set notifications for favorite items when price changes"},
                new Content() {CultureId = 1, Key = "SubmitMail", Value = "Send"},
                new Content() {CultureId = 1, Key = "ThanksMsg", Value = "Your email was sent. Thanks!"},
                new Content() {CultureId = 2, Key = "PageTitle", Value = "כותרת ראשית"},
                new Content() {CultureId = 3, Key = "PageTitle", Value = "Заголовок"},
            };

            contents.ForEach(content=>context.Contents.Add(content));
            context.SaveChanges();
        }
    }
}