namespace FlyWith.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlyWith.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FlyWith.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //addidng all the 
            context.Countries.AddOrUpdate(c => c.Name,

                new Country { Name = "Afghanistan" },
                new Country { Name = "Albania" },
                new Country { Name = "Algeria" },
                new Country { Name = "Andorra" },
                new Country { Name = "Angola" },
                new Country { Name = "Antigua and Barbuda" }, 
                new Country { Name = "Argentina" },
                new Country { Name = "Armenia" },
                new Country { Name = "Aruba" },
                new Country { Name = "Australia" },
                new Country { Name = "Austria" },
                new Country { Name = "Azerbaijan" },
                new Country { Name = "Bahamas" },
                new Country { Name = "Bahrain" },
                new Country { Name = "Bangladesh"},
                new Country { Name = "Barbados" },
                new Country { Name = "Belarus" },
                new Country { Name = "Belgium" },
                new Country { Name = "Belize" },
                new Country { Name = "Benin" },
                new Country { Name = "Bhutan" },
                new Country { Name = "Bolivia" },
                new Country { Name = "Bosnia and Herzegovina" },
                new Country { Name = "Botswana" },
                new Country { Name = "Brazil" },
                new Country { Name = "Brunei" },
                new Country { Name = "Bulgaria" },
                new Country { Name = "Burkina Faso" },
                new Country { Name = "Burundi" },
                new Country { Name = "Cambodia" },
                new Country { Name = "Cameroon" },
                new Country { Name = "Canada" },
                new Country { Name = "Cabo Verde" },
                new Country { Name = "Central African Republic(CAR)" },
                new Country { Name = "Chad" },
                new Country { Name = "Chile" },
                new Country { Name = "China" },
                new Country { Name = "Colombia" },
                new Country { Name = "Comoros" },
                new Country { Name = "Congo, Democratic Republic" },
                new Country { Name = "Congo, Republic" },
                new Country { Name = "Costa Rica" },
                new Country { Name = "Cote d'Ivoire" },
                new Country { Name = "Croatia" },
                new Country { Name = "Cuba" },
                new Country { Name = "Curacao" },
                new Country { Name = "Cyprus" },
                new Country { Name = "Czech Republic" },
                new Country { Name = "Denmark" },
                new Country { Name = "Djibouti" },
                new Country { Name = "Dominica" },
                new Country { Name = "Dominican Republic" },
                new Country { Name = "East Timor (see Timor-Leste)" },
                new Country { Name = "Ecuador" },
                new Country { Name = "Egypt" },
                new Country { Name = "El Salvador" },
                new Country { Name = "Equatorial Guinea" },
                new Country { Name = "Eritrea" },
                new Country { Name = "Estonia" },
                new Country { Name = "Ethiopia" },
                new Country { Name = "Fiji" },
                new Country { Name = "Finland" },
                new Country { Name = "France" },
                new Country { Name = "Gabon" },
                new Country { Name = "Gambia" },
                new Country { Name = "Georgia" },
                new Country { Name = "Germany" },
                new Country { Name = "Ghana" },
                new Country { Name = "Greece" },
                new Country { Name = "Grenada" },
                new Country { Name = "Guatemala" },
                new Country { Name = "Guinea" },
                new Country { Name = "Guinea-Bissau" },
                new Country { Name = "Guyana" },
                new Country { Name = "Haiti" },
                new Country { Name = "Honduras" },
                new Country { Name = "Hungary" },
                new Country { Name = "Iceland" },
                new Country { Name = "India" },
                new Country { Name = "Indonesia" },
                new Country { Name = "Iran" },
                new Country { Name = "Iraq" },
                new Country { Name = "Ireland" },
                new Country { Name = "Israel" },
                new Country { Name = "Italy" },
                new Country { Name = "Jamaica" },
                new Country { Name = "Japan" },
                new Country { Name = "Jordan" },
                new Country { Name = "Kazakhstan" },
                new Country { Name = "Kenya" },
                new Country { Name = "Kiribati" },
                new Country { Name = "Kosovo" },
                new Country { Name = "Kuwait" },
                new Country { Name = "Kyrgyzstan" },
                new Country { Name = "Laos" },
                new Country { Name = "Latvia" },
                new Country { Name = "Lebanon" },
                new Country { Name = "Lesotho" },
                new Country { Name = "Liberia" },
                new Country { Name = "Libya" },
                new Country { Name = "Liechtenstein" },
                new Country { Name = "Lithuania" },
                new Country { Name = "Luxembourg" }, 
                new Country { Name = "Macedonia(FYROM)" },
                new Country { Name = "Madagascar" },
                new Country { Name = "Malawi" },
                new Country { Name = "Malaysia" },
                new Country { Name = "Maldives" },
                new Country { Name = "Mali" },
                new Country { Name = "Malta" },
                new Country { Name = "Marshall Islands" },
                new Country { Name = "Mauritania" },
                new Country { Name = "Mauritius" },
                new Country { Name = "Mexico" },
                new Country { Name = "Micronesia" },
                new Country { Name = "Moldova" },
                new Country { Name = "Monaco" },
                new Country { Name = "Mongolia" },
                new Country { Name = "Montenegro" },
                new Country { Name = "Morocco" },
                new Country { Name = "Mozambique" },
                new Country { Name = "Myanmar(Burma)" },
                new Country { Name = "Namibia" },
                new Country { Name = "Nauru" },
                new Country { Name = "Nepal" },
                new Country { Name = "Netherlands" },
                new Country { Name = "New Zealand" },
                new Country { Name = "Nicaragua" },
                new Country { Name = "Niger" },
                new Country { Name = "Nigeria" },
                new Country { Name = "North Korea" },
                new Country { Name = "Norway" },
                new Country { Name = "Oman" },
                new Country { Name = "Pakistan" },
                new Country { Name = "Palau" },
                new Country { Name = "Palestinian Territories" },
                new Country { Name = "Panama" },
                new Country { Name = "Papua New Guinea" },
                new Country { Name = "Paraguay" },
                new Country { Name = "Peru" },
                new Country { Name = "Philippines" },
                new Country { Name = "Poland" },
                new Country { Name = "Portugal" },
                new Country { Name = "Qatar" },
                new Country { Name = "Romania" },
                new Country { Name = "Russia" },
                new Country { Name = "Rwanda" },
                new Country { Name = "Saint Kitts and Nevis" },
                new Country { Name = "Saint Lucia" },
                new Country { Name = "Saint Vincent and the Grenadines" },
                new Country { Name = "Samoa" },
                new Country { Name = "San Marino" },
                new Country { Name = "Sao Tome and Principe" },
                new Country { Name = "Saudi Arabia" },
                new Country { Name = "Senegal" },
                new Country { Name = "Serbia" },
                new Country { Name = "Seychelles" },
                new Country { Name = "Sierra Leone" },
                new Country { Name = "Singapore" },
                new Country { Name = "Sint Maarten" },
                new Country { Name = "Slovakia" },
                new Country { Name = "Slovenia" },
                new Country { Name = "Solomon Islands" },
                new Country { Name = "Somalia" },
                new Country { Name = "South Africa" },
                new Country { Name = "South Korea" },
                new Country { Name = "South Sudan" },
                new Country { Name = "Spain" },
                new Country { Name = "Sri Lanka" },
                new Country { Name = "Sudan" },
                new Country { Name = "Suriname" },
                new Country { Name = "Swaziland" },
                new Country { Name = "Sweden" },
                new Country { Name = "Switzerland" },
                new Country { Name = "Syria" },
                new Country { Name = "Taiwan" },
                new Country { Name = "Tajikistan" },
                new Country { Name = "Tanzania" },
                new Country { Name = "Thailand" },
                new Country { Name = "Timor-Leste" },
                new Country { Name = "Togo" },
                new Country { Name = "Tonga" },
                new Country { Name = "Trinidad and Tobago" },
                new Country { Name = "Tunisia" },
                new Country { Name = "Turkey" },
                new Country { Name = "Turkmenistan" },
                new Country { Name = "Tuvalu" },
                new Country { Name = "Uganda" },
                new Country { Name = "Ukraine" },
                new Country { Name = "United Arab Emirates(UAE)" },
                new Country { Name = "United Kingdom (UK)" },
                new Country { Name = "United States of America(USA)" }, 
                new Country { Name = "Uruguay" },
                new Country { Name = "Uzbekistan" },
                new Country { Name = "Vanuatu" },
                new Country { Name = "Venezuela" },
                new Country { Name = "Vietnam" },
                new Country { Name = "Yemen" },
                new Country { Name = "Zambia" },
                new Country { Name = "Zimbabwe" } 
          
             );
            
            context.Sexes.AddOrUpdate(
               
                new Sex { Name = "Female" },
                new Sex { Name = "Male" }
             );
           
            context.DoInFlights.AddOrUpdate(d=>d.Name,

              new DoInFlight { Name = "Business Conversation" },
              new DoInFlight { Name = "Casual Chat" },
              new DoInFlight { Name = "Dating" },
              new DoInFlight { Name = "Silence" }
            
              );
            context.InterestGroups.AddOrUpdate(i=>i.Name,
                
                new InterestGroup { Name = "Arts" },
                new InterestGroup { Name = "Performances" },
                new InterestGroup { Name = "Reading" },
                new InterestGroup { Name = "Fashion" },
                new InterestGroup { Name = "Food" },
                new InterestGroup { Name = "Games"},
                new InterestGroup { Name = "Movies" },
                new InterestGroup { Name = "Music" },
                new InterestGroup { Name = "Religion" },
                new InterestGroup { Name = "Sport" },
                new InterestGroup { Name = "Travel" },
                new InterestGroup { Name = "News" }
                
              );

            context.LanguageLevels.AddOrUpdate(l => l.Name,

                new LanguageLevel { Name = "Native" },
                new LanguageLevel { Name = "Fluent" }
                
             );

            context.Levels.AddOrUpdate(l=>l.Name,
                
                new Level { Name = "0"},
                new Level { Name = "1" }, 
                new Level { Name = "2" }, 
                new Level { Name = "3" },
                new Level { Name = "4" },
                new Level { Name = "5" },
                new Level { Name = "6" },
                new Level { Name = "7" },
                new Level { Name = "8" },
                new Level { Name = "9" },
                new Level { Name = "10" }
                
             );

            context.MealTypes.AddOrUpdate(m=>m.Name,
                
                new MealType { Name = "Kosher" },
                new MealType { Name = "Vegetarian" },
                new MealType { Name = "Vegan" },
                new MealType { Name = "Halal" },
                new MealType { Name = "Allergy" },
                new MealType { Name = "Low-cal" }
                
             );
            context.SeatingPositions.AddOrUpdate(s=>s.Name,
                
               new SeatingPosition { Name = "Aisle" },
               new SeatingPosition { Name = "Window" },
               new SeatingPosition { Name = "Center" },
               new SeatingPosition { Name = "Override" }

             );
            context.YesNoAnswers.AddOrUpdate(y=>y.Name,
                
                new YesNoAnswer { Name = "Yes" },
                new YesNoAnswer { Name = "No"}
                
              );

            context.Occupations.AddOrUpdate(o=>o.Name,

                new Occupation { Name = "Law" },
                new Occupation { Name = "Technology" },
                new Occupation { Name = "Health" },
                new Occupation { Name = "Business" },
                new Occupation { Name = "Art" },
                new Occupation { Name = "Sport" },
                new Occupation { Name = "Travel" },
                new Occupation { Name = "Education" },
                new Occupation { Name = "Government" },
                new Occupation { Name = "Food" },
                new Occupation { Name = "Fashion" },
                new Occupation { Name = "Student" },
                new Occupation { Name = "Retired" }

                );


        }
    }
}
