namespace FlyWith.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
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





            //creating roles for the project
            if (!context.Roles.Any(r=> r.Name=="Admin"))
            {

                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
                
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {

                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);

            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("0d64e961-1cae-4b5b-b0ec-c40374b81b70", "Admin");



            //addidng all the data to tables
            context.Countries.AddOrUpdate(c => new { c.Name, c.CountryID },


                new Country { Name = "Afghanistan", CountryID = 1 },
                new Country { Name = "Albania", CountryID = 2 },
                new Country { Name = "Algeria", CountryID = 3 },
                new Country { Name = "Andorra", CountryID = 4 },
                new Country { Name = "Angola", CountryID = 5 },
                new Country { Name = "Antigua and Barbuda", CountryID = 6 },
                new Country { Name = "Argentina", CountryID = 7 },
                new Country { Name = "Armenia", CountryID = 8 },
                new Country { Name = "Aruba", CountryID = 9 },
                new Country { Name = "Australia", CountryID = 10 },
                new Country { Name = "Austria", CountryID = 11 },
                new Country { Name = "Azerbaijan", CountryID = 12 },
                new Country { Name = "Bahamas", CountryID = 13 },
                new Country { Name = "Bahrain", CountryID = 14 },
                new Country { Name = "Bangladesh", CountryID = 15 },
                new Country { Name = "Barbados", CountryID = 16 },
                new Country { Name = "Belarus", CountryID = 17 },
                new Country { Name = "Belgium", CountryID = 18 },
                new Country { Name = "Belize", CountryID = 19 },
                new Country { Name = "Benin", CountryID = 20 },
                new Country { Name = "Bhutan", CountryID = 21 },
                new Country { Name = "Bolivia", CountryID = 22 },
                new Country { Name = "Bosnia and Herzegovina", CountryID = 23 },
                new Country { Name = "Botswana", CountryID = 24 },
                new Country { Name = "Brazil", CountryID = 25 },
                new Country { Name = "Brunei", CountryID = 26 },
                new Country { Name = "Bulgaria", CountryID = 27 },
                new Country { Name = "Burkina Faso", CountryID = 28 },
                new Country { Name = "Burundi", CountryID = 29 },
                new Country { Name = "Cambodia", CountryID = 30 },
                new Country { Name = "Cameroon", CountryID = 31 },
                new Country { Name = "Canada", CountryID = 32 },
                new Country { Name = "Cabo Verde", CountryID = 33 },
                new Country { Name = "Central African Republic(CAR)", CountryID = 34 },
                new Country { Name = "Chad", CountryID = 35 },
                new Country { Name = "Chile", CountryID = 36 },
                new Country { Name = "China", CountryID = 37 },
                new Country { Name = "Colombia", CountryID = 38 },
                new Country { Name = "Comoros", CountryID = 39 },
                new Country { Name = "Congo, Democratic Republic", CountryID = 40 },
                new Country { Name = "Congo, Republic", CountryID = 41 },
                new Country { Name = "Costa Rica", CountryID = 42 },
                new Country { Name = "Cote d'Ivoire", CountryID = 43 },
                new Country { Name = "Croatia", CountryID = 44 },
                new Country { Name = "Cuba", CountryID = 45 },
                new Country { Name = "Curacao", CountryID = 46 },
                new Country { Name = "Cyprus", CountryID = 47 },
                new Country { Name = "Czech Republic", CountryID = 48 },
                new Country { Name = "Denmark", CountryID = 49 },
                new Country { Name = "Djibouti", CountryID = 50 },
                new Country { Name = "Dominica", CountryID = 51 },
                new Country { Name = "Dominican Republic", CountryID = 52 },
                new Country { Name = "East Timor (see Timor-Leste)", CountryID = 53 },
                new Country { Name = "Ecuador", CountryID = 54 },
                new Country { Name = "Egypt", CountryID = 55 },
                new Country { Name = "El Salvador", CountryID = 56 },
                new Country { Name = "Equatorial Guinea", CountryID = 57 },
                new Country { Name = "Eritrea", CountryID = 58 },
                new Country { Name = "Estonia", CountryID = 59 },
                new Country { Name = "Ethiopia", CountryID = 60 },
                new Country { Name = "Fiji", CountryID = 61 },
                new Country { Name = "Finland", CountryID = 62 },
                new Country { Name = "France", CountryID = 63 },
                new Country { Name = "Gabon", CountryID = 64 },
                new Country { Name = "Gambia", CountryID = 65 },
                new Country { Name = "Georgia", CountryID = 66 },
                new Country { Name = "Germany", CountryID = 67 },
                new Country { Name = "Ghana", CountryID = 68 },
                new Country { Name = "Greece", CountryID = 69 },
                new Country { Name = "Grenada", CountryID = 70 },
                new Country { Name = "Guatemala", CountryID = 71 },
                new Country { Name = "Guinea", CountryID = 72 },
                new Country { Name = "Guinea-Bissau", CountryID = 73 },
                new Country { Name = "Guyana", CountryID = 74 },
                new Country { Name = "Haiti", CountryID = 75 },
                new Country { Name = "Honduras", CountryID = 76 },
                new Country { Name = "Hungary", CountryID = 77 },
                new Country { Name = "Iceland", CountryID = 78 },
                new Country { Name = "India", CountryID = 79 },
                new Country { Name = "Indonesia", CountryID = 80 },
                new Country { Name = "Iran", CountryID = 81 },
                new Country { Name = "Iraq", CountryID = 82 },
                new Country { Name = "Ireland", CountryID = 83 },
                new Country { Name = "Israel", CountryID = 84 },
                new Country { Name = "Italy", CountryID = 85 },
                new Country { Name = "Jamaica", CountryID = 86 },
                new Country { Name = "Japan", CountryID = 87 },
                new Country { Name = "Jordan", CountryID = 88 },
                new Country { Name = "Kazakhstan", CountryID = 89 },
                new Country { Name = "Kenya", CountryID = 90 },
                new Country { Name = "Kiribati", CountryID = 91 },
                new Country { Name = "Kosovo", CountryID = 92 },
                new Country { Name = "Kuwait", CountryID = 93 },
                new Country { Name = "Kyrgyzstan", CountryID = 94 },
                new Country { Name = "Laos", CountryID = 95 },
                new Country { Name = "Latvia", CountryID = 96 },
                new Country { Name = "Lebanon", CountryID = 97 },
                new Country { Name = "Lesotho", CountryID = 98 },
                new Country { Name = "Liberia", CountryID = 99 },
                new Country { Name = "Libya", CountryID = 100 },
                new Country { Name = "Liechtenstein", CountryID = 101 },
                new Country { Name = "Lithuania", CountryID = 102 },
                new Country { Name = "Luxembourg", CountryID = 103 },
                new Country { Name = "Macedonia(FYROM)", CountryID = 104 },
                new Country { Name = "Madagascar", CountryID = 105 },
                new Country { Name = "Malawi", CountryID = 106 },
                new Country { Name = "Malaysia", CountryID = 107 },
                new Country { Name = "Maldives", CountryID = 108 },
                new Country { Name = "Mali", CountryID = 109 },
                new Country { Name = "Malta", CountryID = 110 },
                new Country { Name = "Marshall Islands", CountryID = 111 },
                new Country { Name = "Mauritania", CountryID = 112 },
                new Country { Name = "Mauritius", CountryID = 113 },
                new Country { Name = "Mexico", CountryID = 114 },
                new Country { Name = "Micronesia", CountryID = 115 },
                new Country { Name = "Moldova", CountryID = 116 },
                new Country { Name = "Monaco", CountryID = 117 },
                new Country { Name = "Mongolia", CountryID = 118 },
                new Country { Name = "Montenegro", CountryID = 119 },
                new Country { Name = "Morocco", CountryID = 120 },
                new Country { Name = "Mozambique", CountryID = 121 },
                new Country { Name = "Myanmar(Burma)", CountryID = 122 },
                new Country { Name = "Namibia", CountryID = 123 },
                new Country { Name = "Nauru", CountryID = 124 },
                new Country { Name = "Nepal", CountryID = 125 },
                new Country { Name = "Netherlands", CountryID = 126 },
                new Country { Name = "New Zealand", CountryID = 127 },
                new Country { Name = "Nicaragua", CountryID = 128 },
                new Country { Name = "Niger", CountryID = 129 },
                new Country { Name = "Nigeria", CountryID = 130 },
                new Country { Name = "North Korea", CountryID = 131 },
                new Country { Name = "Norway", CountryID = 132 },
                new Country { Name = "Oman", CountryID = 133 },
                new Country { Name = "Pakistan", CountryID = 134 },
                new Country { Name = "Palau", CountryID = 135 },
                new Country { Name = "Palestinian Territories", CountryID = 136 },
                new Country { Name = "Panama", CountryID = 137 },
                new Country { Name = "Papua New Guinea", CountryID = 138 },
                new Country { Name = "Paraguay", CountryID = 139 },
                new Country { Name = "Peru", CountryID = 140 },
                new Country { Name = "Philippines", CountryID = 141 },
                new Country { Name = "Poland", CountryID = 142 },
                new Country { Name = "Portugal", CountryID = 143 },
                new Country { Name = "Qatar", CountryID = 144 },
                new Country { Name = "Romania", CountryID = 145 },
                new Country { Name = "Russia", CountryID = 146 },
                new Country { Name = "Rwanda", CountryID = 147 },
                new Country { Name = "Saint Kitts and Nevis", CountryID = 148 },
                new Country { Name = "Saint Lucia", CountryID = 149 },
                new Country { Name = "Saint Vincent and the Grenadines", CountryID = 150 },
                new Country { Name = "Samoa", CountryID = 151 },
                new Country { Name = "San Marino", CountryID = 152 },
                new Country { Name = "Sao Tome and Principe", CountryID = 153 },
                new Country { Name = "Saudi Arabia", CountryID = 154 },
                new Country { Name = "Senegal", CountryID = 155 },
                new Country { Name = "Serbia", CountryID = 156 },
                new Country { Name = "Seychelles", CountryID = 157 },
                new Country { Name = "Sierra Leone", CountryID = 158 },
                new Country { Name = "Singapore", CountryID = 159 },
                new Country { Name = "Sint Maarten", CountryID = 160 },
                new Country { Name = "Slovakia", CountryID = 161 },
                new Country { Name = "Slovenia", CountryID = 162 },
                new Country { Name = "Solomon Islands", CountryID = 163 },
                new Country { Name = "Somalia", CountryID = 164 },
                new Country { Name = "South Africa", CountryID = 165 },
                new Country { Name = "South Korea", CountryID = 166 },
                new Country { Name = "South Sudan", CountryID = 167 },
                new Country { Name = "Spain", CountryID = 168 },
                new Country { Name = "Sri Lanka", CountryID = 169 },
                new Country { Name = "Sudan", CountryID = 170 },
                new Country { Name = "Suriname", CountryID = 171 },
                new Country { Name = "Swaziland", CountryID = 172 },
                new Country { Name = "Sweden", CountryID = 173 },
                new Country { Name = "Switzerland", CountryID = 174 },
                new Country { Name = "Syria", CountryID = 175 },
                new Country { Name = "Taiwan", CountryID = 176 },
                new Country { Name = "Tajikistan", CountryID = 177 },
                new Country { Name = "Tanzania", CountryID = 178 },
                new Country { Name = "Thailand", CountryID = 179 },
                new Country { Name = "Timor-Leste", CountryID = 180 },
                new Country { Name = "Togo", CountryID = 181 },
                new Country { Name = "Tonga", CountryID = 182 },
                new Country { Name = "Trinidad and Tobago", CountryID = 183 },
                new Country { Name = "Tunisia", CountryID = 184 },
                new Country { Name = "Turkey", CountryID = 185 },
                new Country { Name = "Turkmenistan", CountryID = 186 },
                new Country { Name = "Tuvalu", CountryID = 187 },
                new Country { Name = "Uganda", CountryID = 188 },
                new Country { Name = "Ukraine", CountryID = 189 },
                new Country { Name = "United Arab Emirates(UAE)", CountryID = 190 },
                new Country { Name = "United Kingdom (UK)", CountryID = 191 },
                new Country { Name = "United States of America(USA)", CountryID = 192 },
                new Country { Name = "Uruguay", CountryID = 193 },
                new Country { Name = "Uzbekistan", CountryID = 194 },
                new Country { Name = "Vanuatu", CountryID = 195 },
                new Country { Name = "Venezuela", CountryID = 196 },
                new Country { Name = "Vietnam", CountryID = 197 },
                new Country { Name = "Yemen", CountryID = 198 },
                new Country { Name = "Zambia", CountryID = 199 },
                new Country { Name = "Zimbabwe", CountryID = 200 }

             );

            context.Sexes.AddOrUpdate(s => new { s.Name, s.SexID },

                new Sex { Name = "Female", SexID = 1 },
                new Sex { Name = "Male", SexID = 2 }
             );

            context.DoInFlights.AddOrUpdate(d => new { d.Name, d.DoInFlightID },

              new DoInFlight { Name = "Business Conversation", DoInFlightID = 1 },
              new DoInFlight { Name = "Casual Chat", DoInFlightID = 2 },
              new DoInFlight { Name = "Dating", DoInFlightID = 3 },
              new DoInFlight { Name = "Silence", DoInFlightID = 4 }

              );
            context.InterestGroups.AddOrUpdate(i => new { i.Name, i.InterestGroupID },

                new InterestGroup { InterestGroupID = 1, Name = "Arts" },
                new InterestGroup { InterestGroupID = 2, Name = "Performances" },
                new InterestGroup { InterestGroupID = 3, Name = "Reading" },
                new InterestGroup { InterestGroupID = 4, Name = "Fashion" },
                new InterestGroup { InterestGroupID = 5, Name = "Food" },
                new InterestGroup { InterestGroupID = 6, Name = "Games" },
                new InterestGroup { InterestGroupID = 7, Name = "Movies" },
                new InterestGroup { InterestGroupID = 8, Name = "Music" },
                new InterestGroup { InterestGroupID = 9, Name = "Religion" },
                new InterestGroup { InterestGroupID = 10, Name = "Sport" },
                new InterestGroup { InterestGroupID = 11, Name = "Travel" },
                new InterestGroup { InterestGroupID = 12, Name = "News" },
                new InterestGroup { InterestGroupID = 13, Name = "Science" },

                //linkedin groups
                new InterestGroup { InterestGroupID = 14, Name = "Agriculture" },
                new InterestGroup { InterestGroupID = 15, Name = "Art" },
                new InterestGroup { InterestGroupID = 16, Name = "Construction" },
                new InterestGroup { InterestGroupID = 17, Name = "Consumer goods" },
                new InterestGroup { InterestGroupID = 18, Name = "Corporate" },
                new InterestGroup { InterestGroupID = 19, Name = "Education" },
                new InterestGroup { InterestGroupID = 20, Name = "Finance" },
                new InterestGroup { InterestGroupID = 21, Name = "Government" },
                new InterestGroup { InterestGroupID = 22, Name = "Health" },
                new InterestGroup { InterestGroupID = 23, Name = "Legal" },
                new InterestGroup { InterestGroupID = 24, Name = "Manufacturing" },
                new InterestGroup { InterestGroupID = 25, Name = "Medical" },
                new InterestGroup { InterestGroupID = 26, Name = "Non-profit organization" },
                new InterestGroup { InterestGroupID = 27, Name = "Recreational" },
                new InterestGroup { InterestGroupID = 28, Name = "Services" },
                new InterestGroup { InterestGroupID = 29, Name = "Technology" },
                new InterestGroup { InterestGroupID = 30, Name = "Transportation" }

              );

            context.LanguageLevels.AddOrUpdate(l => new { l.Name, l.LanguageLevelID },

                new LanguageLevel { Name = "Native", LanguageLevelID = 1 },
                new LanguageLevel { Name = "Fluent", LanguageLevelID = 2 }

             );

            context.Levels.AddOrUpdate(l => new { l.LevelID, l.Name },
                new Level { LevelID = 0, Name = "0" },
                new Level { LevelID = 1, Name = "1" },
                new Level { LevelID = 2, Name = "2" },
                new Level { LevelID = 3, Name = "3" },
                new Level { LevelID = 4, Name = "4" },
                new Level { LevelID = 5, Name = "5" },
                new Level { LevelID = 6, Name = "6" },
                new Level { LevelID = 7, Name = "7" },
                new Level { LevelID = 8, Name = "8" },
                new Level { LevelID = 9, Name = "9" },
                new Level { LevelID = 10, Name = "10" }

             );

            context.MealTypes.AddOrUpdate(m => new { m.Name, m.MealTypeID },

                new MealType { Name = "Kosher", MealTypeID = 1 },
                new MealType { Name = "Vegetarian", MealTypeID = 2 },
                new MealType { Name = "Vegan", MealTypeID = 3 },
                new MealType { Name = "Halal", MealTypeID = 4 },
                new MealType { Name = "Allergy", MealTypeID = 5 },
                new MealType { Name = "Low-cal", MealTypeID = 6 }

             );
            context.SeatingPositions.AddOrUpdate(s => new { s.Name, s.SeatingPositionID },

               new SeatingPosition { Name = "Aisle", SeatingPositionID = 1 },
               new SeatingPosition { Name = "Window ", SeatingPositionID = 2 },
               new SeatingPosition { Name = "Center", SeatingPositionID = 3 },
               new SeatingPosition { Name = "Override", SeatingPositionID = 4 }

             );
            context.YesNoAnswers.AddOrUpdate(y => new { y.Name, y.YesNoAnswerID },

                new YesNoAnswer { Name = "Yes", YesNoAnswerID = 1 },
                new YesNoAnswer { Name = "No", YesNoAnswerID = 2 }

              );

            context.Occupations.AddOrUpdate(o => new { o.Name, o.OccupationID },

                new Occupation { Name = "Law", OccupationID = 1 },
                new Occupation { Name = "Technology", OccupationID = 2 },
                new Occupation { Name = "Health", OccupationID = 3 },
                new Occupation { Name = "Business", OccupationID = 4 },
                new Occupation { Name = "Art", OccupationID = 5 },
                new Occupation { Name = "Sport", OccupationID = 6 },
                new Occupation { Name = "Travel", OccupationID = 7 },
                new Occupation { Name = "Education", OccupationID = 8 },
                new Occupation { Name = "Government", OccupationID = 9 },
                new Occupation { Name = "Food", OccupationID = 10 },
                new Occupation { Name = "Fashion", OccupationID = 11 },
                new Occupation { Name = "Student", OccupationID = 12 },
                new Occupation { Name = "Retired", OccupationID = 13 }

                );

            context.Languages.AddOrUpdate(l => new { l.Name, l.LanguageID },

                new Language { Name = "Afrikaans", LanguageID = 1 },
                new Language { Name = "Albanian", LanguageID = 2 },
                new Language { Name = "Amharic", LanguageID = 3 },
                new Language { Name = "Arabic", LanguageID = 4 },
                new Language { Name = "Armenian", LanguageID = 5 },
                new Language { Name = "Basque", LanguageID = 6 },
                new Language { Name = "Bengali", LanguageID = 7 },
                new Language { Name = "Byelorussian", LanguageID = 8 },
                new Language { Name = "Burmese", LanguageID = 9 },
                new Language { Name = "Bulgarian", LanguageID = 10 },
                new Language { Name = "Catalan", LanguageID = 11 },
                new Language { Name = "Czech", LanguageID = 12 },
                new Language { Name = "Chinese", LanguageID = 13 },
                new Language { Name = "Croatian", LanguageID = 14 },
                new Language { Name = "Danish", LanguageID = 15 },
                new Language { Name = "Dari", LanguageID = 16 },
                new Language { Name = "Dzongkha", LanguageID = 17 },
                new Language { Name = "Dutch", LanguageID = 18 },
                new Language { Name = "English", LanguageID = 19 },
                new Language { Name = "Esperanto", LanguageID = 20 },
                new Language { Name = "Estonian", LanguageID = 21 },
                new Language { Name = "Faroese", LanguageID = 22 },
                new Language { Name = "Farsi", LanguageID = 23 },
                new Language { Name = "Finnish", LanguageID = 24 },
                new Language { Name = "French", LanguageID = 25 },
                new Language { Name = "Gaelic", LanguageID = 26 },
                new Language { Name = "Galician", LanguageID = 27 },
                new Language { Name = "German", LanguageID = 28 },
                new Language { Name = "Greek", LanguageID = 29 },
                new Language { Name = "Hebrew", LanguageID = 30 },
                new Language { Name = "Hindi", LanguageID = 31 },
                new Language { Name = "Hungarian", LanguageID = 32 },
                new Language { Name = "Icelandic", LanguageID = 33 },
                new Language { Name = "Indonesian", LanguageID = 34 },
                new Language { Name = "Inuktitut (Eskimo)", LanguageID = 35 },
                new Language { Name = "Italian", LanguageID = 36 },
                new Language { Name = "Japanese", LanguageID = 37 },
                new Language { Name = "Khmer", LanguageID = 38 },
                new Language { Name = "Korean", LanguageID = 39 },
                new Language { Name = "Kurdish", LanguageID = 40 },
                new Language { Name = "Laotian", LanguageID = 41 },
                new Language { Name = "Latvian", LanguageID = 42 },
                new Language { Name = "Lappish", LanguageID = 43 },
                new Language { Name = "Lithuanian", LanguageID = 44 },
                new Language { Name = "Macedonian", LanguageID = 45 },
                new Language { Name = "Malay", LanguageID = 46 },
                new Language { Name = "Maltese", LanguageID = 47 },
                new Language { Name = "Nepali", LanguageID = 48 },
                new Language { Name = "Norwegian", LanguageID = 49 },
                new Language { Name = "Pashto", LanguageID = 50 },
                new Language { Name = "Polish", LanguageID = 51 },
                new Language { Name = "Portuguese", LanguageID = 52 },
                new Language { Name = "Romanian", LanguageID = 53 },
                new Language { Name = "Russian", LanguageID = 54 },
                new Language { Name = "Scots", LanguageID = 55 },
                new Language { Name = "Serbian", LanguageID = 56 },
                new Language { Name = "Slovak", LanguageID = 57 },
                new Language { Name = "Slovenian", LanguageID = 58 },
                new Language { Name = "Somali", LanguageID = 59 },
                new Language { Name = "Spanish", LanguageID = 60 },
                new Language { Name = "Swedish", LanguageID = 61 },
                new Language { Name = "Swahili", LanguageID = 62 },
                new Language { Name = "Tagalog-Filipino", LanguageID = 63 },
                new Language { Name = "Tajik", LanguageID = 64 },
                new Language { Name = "Tamil", LanguageID = 65 },
                new Language { Name = "Thai", LanguageID = 66 },
                new Language { Name = "Tibetan", LanguageID = 67 },
                new Language { Name = "Tigrinya", LanguageID = 68 },
                new Language { Name = "Tongan", LanguageID = 69 },
                new Language { Name = "Turkish", LanguageID = 70 },
                new Language { Name = "Turkmen", LanguageID = 71 },
                new Language { Name = "Ucrainian", LanguageID = 72 },
                new Language { Name = "Urdu", LanguageID = 73 },
                new Language { Name = "Uzbek", LanguageID = 74 },
                new Language { Name = "Vietnamese", LanguageID = 75 },
                new Language { Name = "Welsh", LanguageID = 76 }

                );

            context.Interests.AddOrUpdate(i => new { i.Name, i.InterestGroupID, i.InterestID },

                //arts group
                new Interest { Name = "Architecture", InterestGroupID = 1, InterestID = 1 },
                new Interest { Name = "Conceptual", InterestGroupID = 1, InterestID = 2 },
                new Interest { Name = "Crafts", InterestGroupID = 1, InterestID = 3 },
                new Interest { Name = "Drawing", InterestGroupID = 1, InterestID = 4 },
                new Interest { Name = "Painting", InterestGroupID = 1, InterestID = 5 },
                new Interest { Name = "Photography", InterestGroupID = 1, InterestID = 6 },
                new Interest { Name = "Sculpture", InterestGroupID = 1, InterestID = 7 },

                //Performances group
                new Interest { Name = "Ballet", InterestGroupID = 2, InterestID = 12 },
                new Interest { Name = "Circus", InterestGroupID = 2, InterestID = 13 },
                new Interest { Name = "Concert", InterestGroupID = 2, InterestID = 14 },
                new Interest { Name = "Dance", InterestGroupID = 2, InterestID = 15 },
                new Interest { Name = "Opera", InterestGroupID = 2, InterestID = 16 },
                new Interest { Name = "Standup", InterestGroupID = 2, InterestID = 17 },
                new Interest { Name = "Theater", InterestGroupID = 2, InterestID = 18 },


                //reading group
                new Interest { Name = "Dance", InterestGroupID = 3, InterestID = 19 },
                new Interest { Name = "Drama", InterestGroupID = 3, InterestID = 20 },
                new Interest { Name = "Essays", InterestGroupID = 3, InterestID = 21 },
                new Interest { Name = "Magazines", InterestGroupID = 3, InterestID = 22 },
                new Interest { Name = "Newspapers", InterestGroupID = 3, InterestID = 23 },
                new Interest { Name = "Novels", InterestGroupID = 3, InterestID = 24 },
                new Interest { Name = "Poetry", InterestGroupID = 3, InterestID = 25 },
                new Interest { Name = "Shortstories", InterestGroupID = 3, InterestID = 26 },


                //fashion group
                new Interest { Name = "Accessories", InterestGroupID = 4, InterestID = 8 },
                new Interest { Name = "Clothing", InterestGroupID = 4, InterestID = 9 },
                new Interest { Name = "Footwear", InterestGroupID = 4, InterestID = 10 },
                new Interest { Name = "Home", InterestGroupID = 4, InterestID = 11 },


                //food group
                new Interest { Name = "Cooking", InterestGroupID = 5, InterestID = 27 },
                new Interest { Name = "Eating out", InterestGroupID = 5, InterestID = 28 },

                //games group
                new Interest { Name = "Board", InterestGroupID = 6, InterestID = 29 },
                new Interest { Name = "Electronic", InterestGroupID = 6, InterestID = 30 },
                new Interest { Name = "Outdoor", InterestGroupID = 6, InterestID = 31 },

                //movies group
                new Interest { Name = "Action", InterestGroupID = 7, InterestID = 32 },
                new Interest { Name = "Animation", InterestGroupID = 7, InterestID = 33 },
                new Interest { Name = "Comedy", InterestGroupID = 7, InterestID = 34 },
                new Interest { Name = "Documentary", InterestGroupID = 7, InterestID = 35 },
                new Interest { Name = "Drama", InterestGroupID = 7, InterestID = 36 },
                new Interest { Name = "Scifi", InterestGroupID = 7, InterestID = 37 },

                //music group
                new Interest { Name = "Blues", InterestGroupID = 8, InterestID = 38 },
                new Interest { Name = "Classical", InterestGroupID = 8, InterestID = 39 },
                new Interest { Name = "Country", InterestGroupID = 8, InterestID = 40 },
                new Interest { Name = "Dance", InterestGroupID = 8, InterestID = 41 },
                new Interest { Name = "Drama", InterestGroupID = 8, InterestID = 42 },
                new Interest { Name = "Electronic", InterestGroupID = 8, InterestID = 43 },
                new Interest { Name = "Indie", InterestGroupID = 8, InterestID = 44 },
                new Interest { Name = "Jazz", InterestGroupID = 8, InterestID = 45 },
                new Interest { Name = "Pop", InterestGroupID = 8, InterestID = 46 },
                new Interest { Name = "RnB", InterestGroupID = 8, InterestID = 47 },
                new Interest { Name = "Rock", InterestGroupID = 8, InterestID = 48 },

                //religion group
                new Interest { Name = "Services", InterestGroupID = 9, InterestID = 49 },
                new Interest { Name = "Study", InterestGroupID = 9, InterestID = 50 },

                //sport group
                new Interest { Name = "Athletics", InterestGroupID = 10, InterestID = 51 },
                new Interest { Name = "Basketball", InterestGroupID = 10, InterestID = 52 },
                new Interest { Name = "Boating", InterestGroupID = 10, InterestID = 53 },
                new Interest { Name = "Climbing", InterestGroupID = 10, InterestID = 54 },
                new Interest { Name = "Diving", InterestGroupID = 10, InterestID = 55 },
                new Interest { Name = "Extreme", InterestGroupID = 10, InterestID = 56 },
                new Interest { Name = "Football", InterestGroupID = 10, InterestID = 57 },
                new Interest { Name = "Golf", InterestGroupID = 10, InterestID = 58 },
                new Interest { Name = "Hiking", InterestGroupID = 10, InterestID = 59 },
                new Interest { Name = "Hockey", InterestGroupID = 10, InterestID = 60 },
                new Interest { Name = "Martial", InterestGroupID = 10, InterestID = 61 },
                new Interest { Name = "Rugby", InterestGroupID = 10, InterestID = 62 },
                new Interest { Name = "Running", InterestGroupID = 10, InterestID = 63 },
                new Interest { Name = "Skating", InterestGroupID = 10, InterestID = 64 },
                new Interest { Name = "Ski", InterestGroupID = 10, InterestID = 65 },
                new Interest { Name = "Surfing", InterestGroupID = 10, InterestID = 66 },
                new Interest { Name = "Swimming", InterestGroupID = 10, InterestID = 67 },
                new Interest { Name = "Volleyball", InterestGroupID = 10, InterestID = 68 },
                new Interest { Name = "Weightlifting", InterestGroupID = 10, InterestID = 69 },

                //travel group
                new Interest { Name = "Beach", InterestGroupID = 11, InterestID = 70 },
                new Interest { Name = "Cities", InterestGroupID = 11, InterestID = 71 },
                new Interest { Name = "Countryside", InterestGroupID = 11, InterestID = 72 },
                new Interest { Name = "Cruise", InterestGroupID = 11, InterestID = 73 },
                new Interest { Name = "Hiking", InterestGroupID = 11, InterestID = 74 },
                new Interest { Name = "Monuments", InterestGroupID = 11, InterestID = 75 },
                new Interest { Name = "Mountain", InterestGroupID = 11, InterestID = 76 },
                new Interest { Name = "Museums", InterestGroupID = 11, InterestID = 77 },

                //news group
                new Interest { Name = "Economy", InterestGroupID = 12, InterestID = 78 },
                new Interest { Name = "Health", InterestGroupID = 12, InterestID = 79 },
                new Interest { Name = "Hi-tech", InterestGroupID = 12, InterestID = 80 },
                new Interest { Name = "International", InterestGroupID = 12, InterestID = 81 },
                new Interest { Name = "Politics", InterestGroupID = 12, InterestID = 82 },
                new Interest { Name = "Social Networks", InterestGroupID = 12, InterestID = 83 },

                //Science group
                new Interest { Name = "Astronomy", InterestGroupID = 13, InterestID = 84 },
                new Interest { Name = "Biology", InterestGroupID = 13, InterestID = 85 },
                new Interest { Name = "Chemistry", InterestGroupID = 13, InterestID = 86 },
                new Interest { Name = "Computer", InterestGroupID = 13, InterestID = 87 },
                new Interest { Name = "Math", InterestGroupID = 13, InterestID = 88 },
                new Interest { Name = "Medicine", InterestGroupID = 13, InterestID = 89 },
                new Interest { Name = "Physics", InterestGroupID = 13, InterestID = 90 },

                //linkedin interests with 1 category
                new Interest { Name = "Alternative Medicine", InterestGroupID = 22, InterestID = 91 },
                new Interest { Name = "Apparel & Fashion", InterestGroupID = 17, InterestID = 92 },
                new Interest { Name = "Architecture & Planning", InterestGroupID = 16, InterestID = 93 },
                new Interest { Name = "Automotive", InterestGroupID = 24, InterestID = 94 },
                new Interest { Name = "Banking", InterestGroupID = 20, InterestID = 95 },
                new Interest { Name = "Building Materials", InterestGroupID = 16, InterestID = 96 },
                new Interest { Name = "Capital Markets", InterestGroupID = 20, InterestID = 97 },
                new Interest { Name = "Chemicals", InterestGroupID = 24, InterestID = 98 },
                new Interest { Name = "Computer & Network Security", InterestGroupID = 29, InterestID = 99 },
                new Interest { Name = "Computer Hardware", InterestGroupID = 29, InterestID = 100 },
                new Interest { Name = "Computer Networking", InterestGroupID = 29, InterestID = 101 },
                new Interest { Name = "Computer Software", InterestGroupID = 29, InterestID = 102 },
                new Interest { Name = "Construction", InterestGroupID = 16, InterestID = 103 },
                new Interest { Name = "Cosmetics", InterestGroupID = 17, InterestID = 104 },
                new Interest { Name = "Dairy", InterestGroupID = 14, InterestID = 105 },
                new Interest { Name = "Education Management", InterestGroupID = 19, InterestID = 106 },
                new Interest { Name = "Executive Office", InterestGroupID = 21, InterestID = 107 },
                new Interest { Name = "Farming", InterestGroupID = 14, InterestID = 108 },
                new Interest { Name = "Financial Services", InterestGroupID = 20, InterestID = 109 },
                new Interest { Name = "Fishery", InterestGroupID = 14, InterestID = 110 },
                new Interest { Name = "Fund-Raising", InterestGroupID = 26, InterestID = 111 },
                new Interest { Name = "Gambling & Casinos", InterestGroupID = 27, InterestID = 112 },
                new Interest { Name = "Government Administration", InterestGroupID = 21, InterestID = 113 },
                new Interest { Name = "Government Relations", InterestGroupID = 21, InterestID = 114 },
                new Interest { Name = "Higher Education", InterestGroupID = 19, InterestID = 115 },
                new Interest { Name = "Hospital & Health Care", InterestGroupID = 22, InterestID = 116 },
                new Interest { Name = "Human Resources", InterestGroupID = 18, InterestID = 117 },
                new Interest { Name = "Information Technology and Services", InterestGroupID = 29, InterestID = 118 },
                new Interest { Name = "Insurance", InterestGroupID = 20, InterestID = 119 },
                new Interest { Name = "International Affairs", InterestGroupID = 21, InterestID = 119 },
                new Interest { Name = "Internet", InterestGroupID = 29, InterestID = 120 },
                new Interest { Name = "Investment Banking", InterestGroupID = 20, InterestID = 121 },
                new Interest { Name = "Investment Management", InterestGroupID = 20, InterestID = 122 },
                new Interest { Name = "Law Practice", InterestGroupID = 23, InterestID = 123 },
                new Interest { Name = "Legal Services", InterestGroupID = 23, InterestID = 124 },
                new Interest { Name = "Luxury Goods & Jewelry", InterestGroupID = 29, InterestID = 125 },
                new Interest { Name = "Machinery", InterestGroupID = 24, InterestID = 126 },
                new Interest { Name = "Management Consulting", InterestGroupID = 18, InterestID = 127 },
                new Interest { Name = "Maritime", InterestGroupID = 30, InterestID = 128 },
                new Interest { Name = "Market Research", InterestGroupID = 18, InterestID = 129 },
                new Interest { Name = "Medical Devices", InterestGroupID = 22, InterestID = 130 },
                new Interest { Name = "Medical Practice", InterestGroupID = 22, InterestID = 131 },
                new Interest { Name = "Mental Health Care", InterestGroupID = 22, InterestID = 132 },
                new Interest { Name = "Military", InterestGroupID = 21, InterestID = 133 },
                new Interest { Name = "Mining & Metals", InterestGroupID = 24, InterestID = 134 },
                new Interest { Name = "Non-Profit Organization Management", InterestGroupID = 26, InterestID = 135 },
                new Interest { Name = "Oil & Energy", InterestGroupID = 24, InterestID = 136 },
                new Interest { Name = "Online Media", InterestGroupID = 25, InterestID = 137 },
                new Interest { Name = "Outsourcing/Offshoring", InterestGroupID = 18, InterestID = 138 },
                new Interest { Name = "Paper & Forest Products", InterestGroupID = 24, InterestID = 139 },
                new Interest { Name = "Philanthropy", InterestGroupID = 26, InterestID = 140 },
                new Interest { Name = "Plastics", InterestGroupID = 24, InterestID = 141 },
                new Interest { Name = "Primary/Secondary Education", InterestGroupID = 19, InterestID = 142 },
                new Interest { Name = "Professional Training & Coaching", InterestGroupID = 18, InterestID = 143 },
                new Interest { Name = "Public Policy", InterestGroupID = 21, InterestID = 144 },
                new Interest { Name = "Public Relations and Communications", InterestGroupID = 18, InterestID = 145 },
                new Interest { Name = "Public Safety", InterestGroupID = 21, InterestID = 146 },
                new Interest { Name = "Railroad Manufacture", InterestGroupID = 24, InterestID = 147 },
                new Interest { Name = "Ranching", InterestGroupID = 14, InterestID = 148 },
                new Interest { Name = "Semiconductors", InterestGroupID = 29, InterestID = 149 },
                new Interest { Name = "Shipbuilding", InterestGroupID = 24, InterestID = 150 },
                new Interest { Name = "Sports", InterestGroupID = 27, InterestID = 151 },
                new Interest { Name = "Staffing and Recruiting", InterestGroupID = 18, InterestID = 152 },
                new Interest { Name = "Supermarkets", InterestGroupID = 17, InterestID = 153 },
                new Interest { Name = "Textiles", InterestGroupID = 24, InterestID = 154 },
                new Interest { Name = "Tobacco", InterestGroupID = 17, InterestID = 155 },
                new Interest { Name = "Transportation/Trucking/Railroad", InterestGroupID = 30, InterestID = 156 },
                new Interest { Name = "Utilities", InterestGroupID = 24, InterestID = 157 },
                new Interest { Name = "Veterinary", InterestGroupID = 22, InterestID = 158 },
                new Interest { Name = "Warehousing", InterestGroupID = 30, InterestID = 159 },
                new Interest { Name = "Wholesale", InterestGroupID = 17, InterestID = 160 },
                new Interest { Name = "Wireless", InterestGroupID = 29, InterestID = 161 },

                //Interests with more then 1 category           
                new Interest { Name = "Accounting", InterestGroupID = 18, InterestID = 162 },
                new Interest { Name = "Accounting", InterestGroupID = 20, InterestID = 163 },

                new Interest { Name = "Airlines/Aviation", InterestGroupID = 24, InterestID = 164 },
                new Interest { Name = "Airlines/Aviation", InterestGroupID = 29, InterestID = 165 },
                new Interest { Name = "Airlines/Aviation", InterestGroupID = 30, InterestID = 166 },

                new Interest { Name = "Alternative Dispute Resolution", InterestGroupID = 23, InterestID = 167 },
                new Interest { Name = "Alternative Dispute Resolution", InterestGroupID = 26, InterestID = 168 },

                new Interest { Name = "Animation", InterestGroupID = 15, InterestID = 169 },
                new Interest { Name = "Animation", InterestGroupID = 25, InterestID = 170 },

                new Interest { Name = "Arts and Crafts", InterestGroupID = 15, InterestID = 171 },
                new Interest { Name = "Arts and Crafts", InterestGroupID = 25, InterestID = 172 },
                new Interest { Name = "Arts and Crafts", InterestGroupID = 27, InterestID = 173 },

                new Interest { Name = "Aviation & Aerospace", InterestGroupID = 21, InterestID = 174 },
                new Interest { Name = "Aviation & Aerospace", InterestGroupID = 24, InterestID = 175 },

                new Interest { Name = "Biotechnology", InterestGroupID = 21, InterestID = 176 },
                new Interest { Name = "Biotechnology", InterestGroupID = 22, InterestID = 177 },
                new Interest { Name = "Biotechnology", InterestGroupID = 29, InterestID = 178 },

                new Interest { Name = "Broadcast Media", InterestGroupID = 25, InterestID = 179 },
                new Interest { Name = "Broadcast Media", InterestGroupID = 27, InterestID = 180 },

                new Interest { Name = "Business Supplies and Equipment", InterestGroupID = 18, InterestID = 181 },
                new Interest { Name = "Business Supplies and Equipment", InterestGroupID = 24, InterestID = 182 },

                new Interest { Name = "Civic & Social Organization", InterestGroupID = 26, InterestID = 183 },
                new Interest { Name = "Civic & Social Organization", InterestGroupID = 28, InterestID = 184 },

                new Interest { Name = "Civil Engineering", InterestGroupID = 16, InterestID = 185 },
                new Interest { Name = "Civil Engineering", InterestGroupID = 21, InterestID = 186 },

                new Interest { Name = "Commercial Real Estate", InterestGroupID = 16, InterestID = 187 },
                new Interest { Name = "Commercial Real Estate", InterestGroupID = 18, InterestID = 188 },
                new Interest { Name = "Commercial Real Estate", InterestGroupID = 20, InterestID = 189 },

                new Interest { Name = "Computer Games", InterestGroupID = 25, InterestID = 190 },
                new Interest { Name = "Computer Games", InterestGroupID = 27, InterestID = 191 },

                new Interest { Name = "Consumer Electronics", InterestGroupID = 17, InterestID = 192 },
                new Interest { Name = "Consumer Electronics", InterestGroupID = 24, InterestID = 193 },

                new Interest { Name = "Consumer Goods", InterestGroupID = 17, InterestID = 194 },
                new Interest { Name = "Consumer Goods", InterestGroupID = 24, InterestID = 195 },

                new Interest { Name = "Consumer Services", InterestGroupID = 26, InterestID = 196 },
                new Interest { Name = "Consumer Services", InterestGroupID = 28, InterestID = 197 },

                new Interest { Name = "Defense & Space", InterestGroupID = 21, InterestID = 198 },
                new Interest { Name = "Defense & Space", InterestGroupID = 29, InterestID = 199 },

                new Interest { Name = "Design", InterestGroupID = 15, InterestID = 200 },
                new Interest { Name = "Design", InterestGroupID = 25, InterestID = 201 },

                new Interest { Name = "E-Learning", InterestGroupID = 19, InterestID = 202 },
                new Interest { Name = "E-Learning", InterestGroupID = 26, InterestID = 203 },

                new Interest { Name = "Electrical/Electronic Manufacturing", InterestGroupID = 17, InterestID = 204 },
                new Interest { Name = "Electrical/Electronic Manufacturing", InterestGroupID = 24, InterestID = 205 },

                new Interest { Name = "Entertainment", InterestGroupID = 25, InterestID = 206 },
                new Interest { Name = "Entertainment", InterestGroupID = 27, InterestID = 207 },

                new Interest { Name = "Environmental Services", InterestGroupID = 26, InterestID = 208 },
                new Interest { Name = "Environmental Services", InterestGroupID = 28, InterestID = 209 },

                new Interest { Name = "Events Services", InterestGroupID = 18, InterestID = 210 },
                new Interest { Name = "Events Services", InterestGroupID = 27, InterestID = 211 },
                new Interest { Name = "Events Services", InterestGroupID = 28, InterestID = 212 },

                new Interest { Name = "Facilities Services", InterestGroupID = 18, InterestID = 213 },
                new Interest { Name = "Facilities Services", InterestGroupID = 28, InterestID = 214 },

                new Interest { Name = "Fine Art", InterestGroupID = 15, InterestID = 215 },
                new Interest { Name = "Fine Art", InterestGroupID = 25, InterestID = 216 },
                new Interest { Name = "Fine Art", InterestGroupID = 27, InterestID = 217 },

                new Interest { Name = "Food & Beverages", InterestGroupID = 27, InterestID = 218 },
                new Interest { Name = "Food & Beverages", InterestGroupID = 28, InterestID = 219 },

                new Interest { Name = "Food Production", InterestGroupID = 17, InterestID = 220 },
                new Interest { Name = "Food Production", InterestGroupID = 24, InterestID = 221 },
                new Interest { Name = "Food Production", InterestGroupID = 28, InterestID = 222 },

                new Interest { Name = "Furniture", InterestGroupID = 17, InterestID = 223 },
                new Interest { Name = "Furniture", InterestGroupID = 24, InterestID = 224 },

                new Interest { Name = "Glass, Ceramics & Concrete", InterestGroupID = 16, InterestID = 225 },
                new Interest { Name = "Glass, Ceramics & Concrete", InterestGroupID = 24, InterestID = 226 },

                new Interest { Name = "Graphic Design", InterestGroupID = 15, InterestID = 227 },
                new Interest { Name = "Graphic Design", InterestGroupID = 25, InterestID = 228 },

                new Interest { Name = "Health, Wellness and Fitness", InterestGroupID = 22, InterestID = 229 },
                new Interest { Name = "Health, Wellness and Fitness", InterestGroupID = 27, InterestID = 230 },

                new Interest { Name = "Hospitality", InterestGroupID = 27, InterestID = 231 },
                new Interest { Name = "Hospitality", InterestGroupID = 28, InterestID = 232 },
                new Interest { Name = "Hospitality", InterestGroupID = 30, InterestID = 233 },

                new Interest { Name = "Import and Export", InterestGroupID = 18, InterestID = 234 },
                new Interest { Name = "Import and Export", InterestGroupID = 17, InterestID = 235 },
                new Interest { Name = "Import and Export", InterestGroupID = 30, InterestID = 236 },

                new Interest { Name = "Individual & Family Services", InterestGroupID = 26, InterestID = 237 },
                new Interest { Name = "Individual & Family Services", InterestGroupID = 28, InterestID = 238 },

                new Interest { Name = "Industrial Automation", InterestGroupID = 16, InterestID = 239 },
                new Interest { Name = "Industrial Automation", InterestGroupID = 24, InterestID = 240 },

                new Interest { Name = "Information Services", InterestGroupID = 25, InterestID = 241 },
                new Interest { Name = "Information Services", InterestGroupID = 28, InterestID = 242 },

                new Interest { Name = "International Trade and Development", InterestGroupID = 21, InterestID = 243 },
                new Interest { Name = "International Trade and Development", InterestGroupID = 26, InterestID = 244 },
                new Interest { Name = "International Trade and Development", InterestGroupID = 30, InterestID = 245 },

                new Interest { Name = "Judiciary", InterestGroupID = 21, InterestID = 246 },
                new Interest { Name = "Judiciary", InterestGroupID = 23, InterestID = 247 },

                new Interest { Name = "Law Enforcement", InterestGroupID = 21, InterestID = 248 },
                new Interest { Name = "Law Enforcement", InterestGroupID = 23, InterestID = 249 },

                new Interest { Name = "Legislative Office", InterestGroupID = 21, InterestID = 250 },
                new Interest { Name = "Legislative Office", InterestGroupID = 23, InterestID = 251 },

                new Interest { Name = "Leisure, Travel & Tourism", InterestGroupID = 27, InterestID = 252 },
                new Interest { Name = "Leisure, Travel & Tourism", InterestGroupID = 28, InterestID = 253 },
                new Interest { Name = "Leisure, Travel & Tourism", InterestGroupID = 30, InterestID = 254 },

                new Interest { Name = "Libraries", InterestGroupID = 22, InterestID = 255 },
                new Interest { Name = "Libraries", InterestGroupID = 22, InterestID = 256 },
                new Interest { Name = "Libraries", InterestGroupID = 22, InterestID = 257 },

                new Interest { Name = "Logistics and Supply Chain", InterestGroupID = 18, InterestID = 258 },
                new Interest { Name = "Logistics and Supply Chain", InterestGroupID = 30, InterestID = 259 },

                new Interest { Name = "Marketing and Advertising", InterestGroupID = 18, InterestID = 260 },
                new Interest { Name = "Marketing and Advertising", InterestGroupID = 25, InterestID = 261 },

                new Interest { Name = "Mechanical or Industrial Engineering", InterestGroupID = 16, InterestID = 262 },
                new Interest { Name = "Mechanical or Industrial Engineering", InterestGroupID = 21, InterestID = 263 },
                new Interest { Name = "Mechanical or Industrial Engineering", InterestGroupID = 24, InterestID = 264 },

                new Interest { Name = "Media Production", InterestGroupID = 25, InterestID = 265 },
                new Interest { Name = "Media Production", InterestGroupID = 27, InterestID = 266 },

                new Interest { Name = "Motion Pictures and Film", InterestGroupID = 15, InterestID = 267 },
                new Interest { Name = "Motion Pictures and Film", InterestGroupID = 25, InterestID = 268 },
                new Interest { Name = "Motion Pictures and Film", InterestGroupID = 27, InterestID = 269 },

                new Interest { Name = "Museums and Institutions", InterestGroupID = 15, InterestID = 270 },
                new Interest { Name = "Museums and Institutions", InterestGroupID = 25, InterestID = 271 },
                new Interest { Name = "Museums and Institutions", InterestGroupID = 27, InterestID = 272 },

                new Interest { Name = "Music", InterestGroupID = 15, InterestID = 273 },
                new Interest { Name = "Music", InterestGroupID = 27, InterestID = 274 },

                new Interest { Name = "Nanotechnology", InterestGroupID = 21, InterestID = 275 },
                new Interest { Name = "Nanotechnology", InterestGroupID = 24, InterestID = 276 },
                new Interest { Name = "Nanotechnology", InterestGroupID = 29, InterestID = 277 },

                new Interest { Name = "Newspapers", InterestGroupID = 25, InterestID = 278 },
                new Interest { Name = "Newspapers", InterestGroupID = 27, InterestID = 279 },

                new Interest { Name = "Package/Freight Delivery", InterestGroupID = 28, InterestID = 280 },
                new Interest { Name = "Package/Freight Delivery", InterestGroupID = 30, InterestID = 281 },

                new Interest { Name = "Packaging and Containers", InterestGroupID = 17, InterestID = 282 },
                new Interest { Name = "Packaging and Containers", InterestGroupID = 24, InterestID = 283 },

                new Interest { Name = "Performing Arts", InterestGroupID = 15, InterestID = 284 },
                new Interest { Name = "Performing Arts", InterestGroupID = 25, InterestID = 285 },
                new Interest { Name = "Performing Arts", InterestGroupID = 27, InterestID = 286 },

                new Interest { Name = "Pharmaceuticals", InterestGroupID = 22, InterestID = 287 },
                new Interest { Name = "Pharmaceuticals", InterestGroupID = 29, InterestID = 288 },

                new Interest { Name = "Photography", InterestGroupID = 15, InterestID = 289 },
                new Interest { Name = "Photography", InterestGroupID = 25, InterestID = 290 },
                new Interest { Name = "Photography", InterestGroupID = 27, InterestID = 291 },

                new Interest { Name = "Political Organization", InterestGroupID = 21, InterestID = 292 },
                new Interest { Name = "Political Organization", InterestGroupID = 26, InterestID = 293 },

                new Interest { Name = "Printing", InterestGroupID = 25, InterestID = 294 },
                new Interest { Name = "Printing", InterestGroupID = 27, InterestID = 295 },

                new Interest { Name = "Program Development", InterestGroupID = 18, InterestID = 296 },
                new Interest { Name = "Program Development", InterestGroupID = 26, InterestID = 297 },

                new Interest { Name = "Publishing", InterestGroupID = 25, InterestID = 298 },
                new Interest { Name = "Publishing", InterestGroupID = 27, InterestID = 299 },

                new Interest { Name = "Real Estate", InterestGroupID = 16, InterestID = 300 },
                new Interest { Name = "Real Estate", InterestGroupID = 20, InterestID = 301 },
                new Interest { Name = "Real Estate", InterestGroupID = 17, InterestID = 302 },

                new Interest { Name = "Recreational Facilities and Services", InterestGroupID = 27, InterestID = 303 },
                new Interest { Name = "Recreational Facilities and Services", InterestGroupID = 28, InterestID = 304 },

                new Interest { Name = "Religious Institutions", InterestGroupID = 26, InterestID = 305 },
                new Interest { Name = "Religious Institutions", InterestGroupID = 28, InterestID = 306 },

                new Interest { Name = "Renewables & Environment", InterestGroupID = 21, InterestID = 307 },
                new Interest { Name = "Renewables & Environment", InterestGroupID = 24, InterestID = 308 },
                new Interest { Name = "Renewables & Environment", InterestGroupID = 26, InterestID = 309 },

                new Interest { Name = "Research", InterestGroupID = 19, InterestID = 310 },
                new Interest { Name = "Research", InterestGroupID = 21, InterestID = 311 },

                new Interest { Name = "Restaurants", InterestGroupID = 27, InterestID = 312 },
                new Interest { Name = "Restaurants", InterestGroupID = 28, InterestID = 313 },

                new Interest { Name = "Retail", InterestGroupID = 17, InterestID = 314 },
                new Interest { Name = "Retail", InterestGroupID = 24, InterestID = 315 },

                new Interest { Name = "Security and Investigations", InterestGroupID = 18, InterestID = 316 },
                new Interest { Name = "Security and Investigations", InterestGroupID = 26, InterestID = 317 },
                new Interest { Name = "Security and Investigations", InterestGroupID = 28, InterestID = 318 },

                new Interest { Name = "Sporting Goods", InterestGroupID = 17, InterestID = 319 },
                new Interest { Name = "Sporting Goods", InterestGroupID = 27, InterestID = 320 },

                new Interest { Name = "Telecommunications", InterestGroupID = 21, InterestID = 321 },
                new Interest { Name = "Telecommunications", InterestGroupID = 29, InterestID = 322 },

                new Interest { Name = "Think Tanks", InterestGroupID = 21, InterestID = 323 },
                new Interest { Name = "Think Tanks", InterestGroupID = 26, InterestID = 324 },

                new Interest { Name = "Translation and Localization", InterestGroupID = 18, InterestID = 325 },
                new Interest { Name = "Translation and Localization", InterestGroupID = 21, InterestID = 326 },
                new Interest { Name = "Translation and Localization", InterestGroupID = 28, InterestID = 327 },

                new Interest { Name = "Venture Capital & Private Equity", InterestGroupID = 20, InterestID = 328 },
                new Interest { Name = "Venture Capital & Private Equity", InterestGroupID = 29, InterestID = 329 },

                new Interest { Name = "Wine and Spirits", InterestGroupID = 17, InterestID = 330 },
                new Interest { Name = "Wine and Spirits", InterestGroupID = 24, InterestID = 331 },
                new Interest { Name = "Wine and Spirits", InterestGroupID = 27, InterestID = 332 },

                new Interest { Name = "Writing and Editing", InterestGroupID = 15, InterestID = 333 },
                new Interest { Name = "Writing and Editing", InterestGroupID = 25, InterestID = 334 },
                new Interest { Name = "Writing and Editing", InterestGroupID = 27, InterestID = 335 }

                );
        }
    }
}
