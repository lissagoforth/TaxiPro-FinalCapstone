using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiPro.Models;

namespace TaxiPro.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any test types
            if (context.TestType.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Mohommad", LastName="Abdul", Address="123 Easy St", City="Antioch", State="TN", Zip="37013", Phone="615-367-0094"},
                new Student{FirstName="Abdul", LastName="Mohommad", Address="321 Lakeview Dr", City="Nashville", State="TN", Zip="37204", Phone="615-874-3498"},
                new Student{FirstName="Fatiya", LastName="Khalid", Address="8720 Hobnob Ln", City="Nashville", State="TN", Zip="37211", Phone="615-593-6340"}
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var testTypes = new TestType[]
            {
                new TestType{Description="Taxi Ordinances"},
                new TestType{Description="Maps and Culture"}
            };

            foreach (TestType t in testTypes)
            {
                context.TestType.Add(t);
            }
            context.SaveChanges();

            var eventTypes = new EventType[]
            {
                new EventType{Name="Note"},
                new EventType{Name="Course"}
            };

            foreach (EventType e in eventTypes)
            {
                context.EventType.Add(e);
            }
            context.SaveChanges();

            var videos = new Video[]
             {
                new Video
                {
                    URL = "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4",
                    Name = "Hospitality and Professional",
                    Order = 1
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Navigation and Culture 2 - Nashville triangle and finding your way.mp4",
                    Name = "Nashville triangle and finding your way",
                    Order = 2
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4",
                    Name = "Interstates and Highways",
                    Order = 3
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4",
                    Name = "Making Conversation",
                    Order = 4
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4",
                    Name = "Neighborhoods and Suburbs",
                    Order = 5
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4",
                    Name = "Permits",
                    Order = 1
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4",
                    Name = "Equipment",
                    Order = 2
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4",
                    Name ="Operation",
                    Order = 3
                },
                new Video
                {
                    URL = "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4",
                    Name = "Passengers Bill of Rights",
                    Order = 4
                }
             };

            foreach (Video v in videos)
            {
                context.Video.Add(v);
            }
            context.SaveChanges();

            var questions = new Question[]
            {
                new Question
                {
                    Content = "The rate-card should not be seen by passengers in the taxi.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Taxi drivers may not receive passengers in the middle of the road.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Failure to comply with all local, state and federal laws and regulations will NOT cause the taxi driver's permit to be cancelled.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="Current taxi drivers can not renew their taxi permits if they have more than 4 moving violations in the last 3 years or more than 2 in the last 12 months.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="The inside of the taxi cab needs to be clean, but the trunk of the taxicab does not have to be clean.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="A taxi driver operating a taxi at the time of an accident involving a death must report for drug-screening within 24 hours.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="The passengers' 'Bill of Rights' must be in full view of them.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="If your driver's license is suspended (or revoked), your taxi permit will still be considered valid for that time.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="Taxi drivers must accept all passengers, even if the taxi driver believes the passenger to be dangerous.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="A taxi driver should not leave his/her taxi for more than 10 minutes at a time (unless there is an emergency).",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content = "A taxi driver must have a car registration, valid driver's license and proof of insurance inside the taxi at all times.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Family members are allowed to drive the cab for personal use.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "A taxi driver should try to attract customers by using a loud voice.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="Taxi drivers can refuse orderly, well behaved passengers because they don't like the fare.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="It is necessary for the taxi driver to be clean while operating the taxicab.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="The manifest must be returned to the cab owner at the end of each day.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="The only medical exceptions allowed by the commission that requires taxi drivers to have a current and valid card are: a) loss of vision in one eye and b) insulin-using diabetes.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="Taxi drivers applying for a one year waiver from the nine year taxi cab age restriction, can do that before July 1st of every year.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="Taxi drivers can offer payments to persons or any other entity in exchange for getting passengers.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="It is not permitted for taxi drivers to collect tips.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content = "Participation in the 'Nashville Hospitality Program' is optional.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "It is permitted for the taxi driver to make personal telephone calls while driving passengers.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Taxi drivers can refuse to accept a passenger if that passenger has a service animal.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "A taxi passenger has the right to direct the taxi driver to the destination and the route to be taken.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 4 - Passengers Bill of Rights.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Taxi drivers are not allowed to work more than a combined 16 hours in a 24-hour period.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content = "Passenger assistance when getting in and out of the taxi, if requested or needed, is mandatory by law.",
                    VideoId = context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId = context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="A taxi driver choosing to change taxi companies must also have their 'company affiliation' changed on their permit before driving for the new company.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 1 - Permits.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },

                new Question
                {
                    Content ="A taxi passenger has the right to select a taxicab of his/her choice of any taxi cab stand.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="Bumper stickers are allowed on the taxi cab.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 2 - Equipment.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="Passengers must provide a safety seat for a child less than 4 years of age.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Ordinance 3 - Operation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Taxi Ordinances").Id
                },
                new Question
                {
                    Content ="Old Hickory Blvd. is the most efficient route from Nashville International Airport to Downtown.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="'Per mile' (metered) fees apply from Opryland to Downtown tourist attractions.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 2 - Nashville triangle and finding your way.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Interstate 24 (I-24) runs north-south, passing by the Rivergate area and through Brentwood.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Berry Hill is a city in Davidson County.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Interstate 40 (I-40) runs east-west, passing by Nashville International Airport and Downtown.",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="A passenger asks for the best place to hear live country music. A helpful suggestion would be...",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="A passenger traveling from the airport asks for a ride to Hermitage. You should...",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following statements about Nashville taxi drivers is TRUE?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Your passengers wants to see the Parthenon. You should take them to...",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is a valid reason for a passenger complaint?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following would be the WRONG thing to do?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following statements is TRUE?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following gestures is NOT polite in American culture?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 1 - Hospitality and Professional.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is TRUE?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 2 - Nashville triangle and finding your way.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is NOT a shopping destination?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Your passenger is going to Goodlettsville. He asks you to take Briley Parkway to I-65. In which direction will you travel to reach your destination?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="A passenger asks 'Where are you from? How long have you been in Nashville?'",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Nissan Stadium is...",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 2 - Nashville triangle and finding your way.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following routes WILL go from the Nashville International Airport to Downtown?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 3 - Interstates and Highways.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is NOT located Downtown?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following statements is FALSE?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is NOT an appropriate way to begin a conversation?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following statements is NOT true about American culture?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 4 -  Making Conversation.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="The line that divides north-south addresses in Nashville is...",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 2 - Nashville triangle and finding your way.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Which of the following is NOT located in Nashville?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="'K' is marked on the attached map south-west of downtown and above I-440. What is 'K'?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="'E' is marked several places on the attached map. What is 'E'?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="'H' is marked on the attached map, near Old Hickory Lake. What is 'H'?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="'F' is marked several places on the attached map. What is 'F'?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                },
                new Question
                {
                    Content ="Old Hickory Lake is the body of water near 'H' on the attached map. Which of the following is closest to Old Hickory Lake?",
                    VideoId =context.Video.SingleOrDefault(v => v.URL == "Videos/Taxi Pro online - Navigation and Culture 5-  Neighborhoods and Suburbs.mp4").Id,
                    TestTypeId =context.TestType.SingleOrDefault(t => t.Description == "Maps and Culture").Id
                }
            };

            foreach (Question q in questions)
            {
                context.Question.Add(q);
            }
            context.SaveChanges();

            var foobar = new Option[]
            {
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The rate-card should not be seen by passengers in the taxi.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The rate-card should not be seen by passengers in the taxi.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers may not receive passengers in the middle of the road.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers may not receive passengers in the middle of the road.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Failure to comply with all local, state and federal laws and regulations will NOT cause the taxi driver's permit to be cancelled.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Failure to comply with all local, state and federal laws and regulations will NOT cause the taxi driver's permit to be cancelled.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Current taxi drivers can not renew their taxi permits if they have more than 4 moving violations in the last 3 years or more than 2 in the last 12 months.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Current taxi drivers can not renew their taxi permits if they have more than 4 moving violations in the last 3 years or more than 2 in the last 12 months.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The inside of the taxi cab needs to be clean, but the trunk of the taxicab does not have to be clean.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The inside of the taxi cab needs to be clean, but the trunk of the taxicab does not have to be clean.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver operating a taxi at the time of an accident involving a death must report for drug-screening within 24 hours.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver operating a taxi at the time of an accident involving a death must report for drug-screening within 24 hours.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The passengers' 'Bill of Rights' must be in full view of them.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The passengers' 'Bill of Rights' must be in full view of them.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "If your driver's license is suspended (or revoked), your taxi permit will still be considered valid for that time.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "If your driver's license is suspended (or revoked), your taxi permit will still be considered valid for that time.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers must accept all passengers, even if the taxi driver believes the passenger to be dangerous.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers must accept all passengers, even if the taxi driver believes the passenger to be dangerous.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver should not leave his/her taxi for more than 10 minutes at a time (unless there is an emergency).").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver should not leave his/her taxi for more than 10 minutes at a time (unless there is an emergency).").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver must have a car registration, valid driver's license and proof of insurance inside the taxi at all times.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver must have a car registration, valid driver's license and proof of insurance inside the taxi at all times.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Family members are allowed to drive the cab for personal use.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Family members are allowed to drive the cab for personal use.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver should try to attract customers by using a loud voice.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver should try to attract customers by using a loud voice.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can refuse orderly, well behaved passengers because they don't like the fare.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can refuse orderly, well behaved passengers because they don't like the fare.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is necessary for the taxi driver to be clean while operating the taxicab.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is necessary for the taxi driver to be clean while operating the taxicab.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The manifest must be returned to the cab owner at the end of each day.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The manifest must be returned to the cab owner at the end of each day.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The only medical exceptions allowed by the commission that requires taxi drivers to have a current and valid card are: a) loss of vision in one eye and b) insulin-using diabetes.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The only medical exceptions allowed by the commission that requires taxi drivers to have a current and valid card are: a) loss of vision in one eye and b) insulin-using diabetes.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers applying for a one year waiver from the nine year taxi cab age restriction, can do that before July 1st of every year.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers applying for a one year waiver from the nine year taxi cab age restriction, can do that before July 1st of every year.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can offer payments to persons or any other entity in exchange for getting passengers.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can offer payments to persons or any other entity in exchange for getting passengers.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is not permitted for taxi drivers to collect tips.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is not permitted for taxi drivers to collect tips.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Participation in the 'Nashville Hospitality Program' is optional.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Participation in the 'Nashville Hospitality Program' is optional.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is permitted for the taxi driver to make personal telephone calls while driving passengers.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "It is permitted for the taxi driver to make personal telephone calls while driving passengers.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can refuse to accept a passenger if that passenger has a service animal.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers can refuse to accept a passenger if that passenger has a service animal.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi passenger has the right to direct the taxi driver to the destination and the route to be taken.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi passenger has the right to direct the taxi driver to the destination and the route to be taken.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers are not allowed to work more than a combined 16 hours in a 24-hour period.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Taxi drivers are not allowed to work more than a combined 16 hours in a 24-hour period.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Passenger assistance when getting in and out of the taxi, if requested or needed, is mandatory by law.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Passenger assistance when getting in and out of the taxi, if requested or needed, is mandatory by law.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver choosing to change taxi companies must also have their 'company affiliation' changed on their permit before driving for the new company.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi driver choosing to change taxi companies must also have their 'company affiliation' changed on their permit before driving for the new company.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi passenger has the right to select a taxicab of his/her choice of any taxi cab stand.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A taxi passenger has the right to select a taxicab of his/her choice of any taxi cab stand.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Bumper stickers are allowed on the taxi cab.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Bumper stickers are allowed on the taxi cab.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Passengers must provide a safety seat for a child less than 4 years of age.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Passengers must provide a safety seat for a child less than 4 years of age.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Blvd. is the most efficient route from Nashville International Airport to Downtown.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Blvd. is the most efficient route from Nashville International Airport to Downtown.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'Per mile' (metered) fees apply from Opryland to Downtown tourist attractions.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'Per mile' (metered) fees apply from Opryland to Downtown tourist attractions.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Interstate 24 (I-24) runs north-south, passing by the Rivergate area and through Brentwood.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Interstate 24 (I-24) runs north-south, passing by the Rivergate area and through Brentwood.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Berry Hill is a city in Davidson County.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Berry Hill is a city in Davidson County.").Id
                },
                new Option
                {
                    Content = "True",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Interstate 40 (I-40) runs east-west, passing by Nashville International Airport and Downtown.").Id
                },
                new Option
                {
                    Content = "False",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Interstate 40 (I-40) runs east-west, passing by Nashville International Airport and Downtown.").Id
                },
                new Option
                {
                    Content = "the Musicians' Hall of Fame.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks for the best place to hear live country music. A helpful suggestion would be...").Id
                },
                new Option
                {
                    Content = "Music Valley Drive.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks for the best place to hear live country music. A helpful suggestion would be...").Id
                },
                new Option
                {
                    Content = "'Honky-tonk Highway' on lower Broadway.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks for the best place to hear live country music. A helpful suggestion would be...").Id
                },
                new Option
                {
                    Content = "Music Row.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks for the best place to hear live country music. A helpful suggestion would be...").Id
                },
                new Option
                {
                    Content = "go to the city of Hermitage.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger traveling from the airport asks for a ride to Hermitage. You should...").Id
                },
                new Option
                {
                    Content = "go to the Hermitage Hotel on 6th Ave. North.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger traveling from the airport asks for a ride to Hermitage. You should...").Id
                },
                new Option
                {
                    Content = "ask your passenger to clarify which Hermitage he really wants.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger traveling from the airport asks for a ride to Hermitage. You should...").Id
                },
                new Option
                {
                    Content = "go to the Hermitage, home of President Andrew Jackson.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger traveling from the airport asks for a ride to Hermitage. You should...").Id
                },
                new Option
                {
                    Content = "Taxi drivers cannot give advice to passengers about best stores and restaurants.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements about Nashville taxi drivers is TRUE?").Id
                },
                new Option
                {
                    Content = "Taxi drivers cannot refuse service to a woman wearing immodest clothing.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements about Nashville taxi drivers is TRUE?").Id
                },
                new Option
                {
                    Content = "Taxi drivers can refuse service to a destination that they feel is unholy.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements about Nashville taxi drivers is TRUE?").Id
                },
                new Option
                {
                    Content = "Taxi drivers can get the phone number of a passenger if she is beautiful.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements about Nashville taxi drivers is TRUE?").Id
                },
                new Option
                {
                    Content = "12 South.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passengers wants to see the Parthenon. You should take them to...").Id
                },
                new Option
                {
                    Content = "Shelby Bottoms Greenway and Nature Park.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passengers wants to see the Parthenon. You should take them to...").Id
                },
                new Option
                {
                    Content = "Bicentennial Mall State Park.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passengers wants to see the Parthenon. You should take them to...").Id
                },
                new Option
                {
                    Content = "Centennial Park.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passengers wants to see the Parthenon. You should take them to...").Id
                },
                new Option
                {
                    Content = "Driving the most efficient route to a destination.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is a valid reason for a passenger complaint?").Id
                },
                new Option
                {
                    Content = "Receiving directions from your dispatcher while stopped.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is a valid reason for a passenger complaint?").Id
                },
                new Option
                {
                    Content = "Asking the customer friendly questions.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is a valid reason for a passenger complaint?").Id
                },
                new Option
                {
                    Content = "Speaking a language other than English in front of the customer.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is a valid reason for a passenger complaint?").Id
                },
                new Option
                {
                    Content = "Arguing with another taxi driver or valet in front of a customer.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following would be the WRONG thing to do?").Id
                },
                new Option
                {
                    Content = "Taking Gallatin Pike instead of I-65 North to avoid traffic.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following would be the WRONG thing to do?").Id
                },
                new Option
                {
                    Content = "Giving a ride to a passenger with a pet.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following would be the WRONG thing to do?").Id
                },
                new Option
                {
                    Content = "Refusing to give a ride to a passenger with a dangerous animal.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following would be the WRONG thing to do?").Id
                },
                new Option
                {
                    Content = "In Tennessee, we practice our religion publicly.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is TRUE?").Id
                },
                new Option
                {
                    Content = "In Tennessee, texting while driving is legal.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is TRUE?").Id
                },
                new Option
                {
                    Content = "In Tennessee, women are respected and have rights equal to those of men.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is TRUE?").Id
                },
                new Option
                {
                    Content = "In Tennessee, bribing hotel valets is OK.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is TRUE?").Id
                },
                new Option
                {
                    Content = "Indicating a thing by pointing at it with your finger.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following gestures is NOT polite in American culture?").Id
                },
                new Option
                {
                    Content = "Pointing at a person with your finger.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following gestures is NOT polite in American culture?").Id
                },
                new Option
                {
                    Content = "Giving someone the 'thumbs up' sign to show you agree with them.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following gestures is NOT polite in American culture?").Id
                },
                new Option
                {
                    Content = "Waving the hand to indicate 'come here'",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following gestures is NOT polite in American culture?").Id
                },
                new Option
                {
                    Content = "It is better to trust the GPS than your own knowledge of streets and landmarks.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is TRUE?").Id
                },
                new Option
                {
                    Content = "GPS is never accurate.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is TRUE?").Id
                },
                new Option
                {
                    Content = "It is better to know area streets and landmarks than to rely on GPS.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is TRUE?").Id
                },
                new Option
                {
                    Content = "GPS is always accurate.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is TRUE?").Id
                },
                new Option
                {
                    Content = "The Streets at Indian Lake",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT a shopping destination?").Id
                },
                new Option
                {
                    Content = "Opry Mills",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT a shopping destination?").Id
                },
                new Option
                {
                    Content = "Bicentennial Mall",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT a shopping destination?").Id
                },
                new Option
                {
                    Content = "Cool Springs Galleria",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT a shopping destination?").Id
                },
                new Option
                {
                    Content = "East",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passenger is going to Goodlettsville. He asks you to take Briley Parkway to I-65. In which direction will you travel to reach your destination?").Id
                },
                new Option
                {
                    Content = "North",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passenger is going to Goodlettsville. He asks you to take Briley Parkway to I-65. In which direction will you travel to reach your destination?").Id
                },
                new Option
                {
                    Content = "South",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passenger is going to Goodlettsville. He asks you to take Briley Parkway to I-65. In which direction will you travel to reach your destination?").Id
                },
                new Option
                {
                    Content = "West",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Your passenger is going to Goodlettsville. He asks you to take Briley Parkway to I-65. In which direction will you travel to reach your destination?").Id
                },
                new Option
                {
                    Content = "You should tell them to mind their own business.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks 'Where are you from? How long have you been in Nashville?'").Id
                },
                new Option
                {
                    Content = "They are probably just curious and being friendly.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks 'Where are you from? How long have you been in Nashville?'").Id
                },
                new Option
                {
                    Content = "You should just ignore them.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks 'Where are you from? How long have you been in Nashville?'").Id
                },
                new Option
                {
                    Content = "They work for the government.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "A passenger asks 'Where are you from? How long have you been in Nashville?'").Id
                },
                new Option
                {
                    Content = "located in Germantown.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Nissan Stadium is...").Id
                },
                new Option
                {
                    Content = "located within Downtown, on the east side of the river.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Nissan Stadium is...").Id
                },
                new Option
                {
                    Content = "located outside of Nashville.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Nissan Stadium is...").Id
                },
                new Option
                {
                    Content = "a honky-tonk.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Nissan Stadium is...").Id
                },
                new Option
                {
                    Content = "Donelson Pike south to Murfreesboro Rd, west to Briley Parkway to Thompson Lane.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following routes WILL go from the Nashville International Airport to Downtown?").Id
                },
                new Option
                {
                    Content = "I-40 west to I-65 south to Old Hickory Blvd.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following routes WILL go from the Nashville International Airport to Downtown?").Id
                },
                new Option
                {
                    Content = "I-40 west to I-65 north to Spring St. north to Gallatin Rd.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following routes WILL go from the Nashville International Airport to Downtown?").Id
                },
                new Option
                {
                    Content = "Murfreesboro Pike west to Lafayette to 8th Ave. to Broadway",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following routes WILL go from the Nashville International Airport to Downtown?").Id
                },
                new Option
                {
                    Content = "The Hermitage Hotel",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located Downtown?").Id
                },
                new Option
                {
                    Content = "Ascend Amphitheater",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located Downtown?").Id
                },
                new Option
                {
                    Content = "Adventure Science Center",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located Downtown?").Id
                },
                new Option
                {
                    Content = "Music City Center",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located Downtown?").Id
                },
                new Option
                {
                    Content = "You should contact your dispatcher and ask for directions to a location you do know.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is FALSE?").Id
                },
                new Option
                {
                    Content = "The 'Nashville Triangle' includes Opryland, Downtown Nashville, and the Nashville International Airport.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is FALSE?").Id
                },
                new Option
                {
                    Content = "Making suggestions to customers about what to do is part of being friendly and polite.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is FALSE?").Id
                },
                new Option
                {
                    Content = "You should use a large folding map to find streets you are unfamiliar with.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is FALSE?").Id
                },
                new Option
                {
                    Content = "Did you see the legs on that woman?",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT an appropriate way to begin a conversation?").Id
                },
                new Option
                {
                    Content = "Hi, how are you today?",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT an appropriate way to begin a conversation?").Id
                },
                new Option
                {
                    Content = "Are you here on business?",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT an appropriate way to begin a conversation?").Id
                },
                new Option
                {
                    Content = "So, what brings you to Nashville?",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT an appropriate way to begin a conversation?").Id
                },
                new Option
                {
                    Content = "People may ask personal questions to strangers in an effort to be nice.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is NOT true about American culture?").Id
                },
                new Option
                {
                    Content = "Being 'professional' means you can smile, laugh, and have friendly conversations about safe topics.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is NOT true about American culture?").Id
                },
                new Option
                {
                    Content = "People are friendly and polite to strangers.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is NOT true about American culture?").Id
                },
                new Option
                {
                    Content = "It is common to talk about politics and religion with strangers.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following statements is NOT true about American culture?").Id
                },
                new Option
                {
                    Content = "Korean Veterans Blvd.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The line that divides north-south addresses in Nashville is...").Id
                },
                new Option
                {
                    Content = "West End Ave./Broadway/Main St./Woodland St",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The line that divides north-south addresses in Nashville is...").Id
                },
                new Option
                {
                    Content = "Jefferson Street",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The line that divides north-south addresses in Nashville is...").Id
                },
                new Option
                {
                    Content = "Charlotte Pike/Charlotte Ave./Spring St./Gallatin Pike",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "The line that divides north-south addresses in Nashville is...").Id
                },
                new Option
                {
                    Content = "Ascend Amphitheater",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located in Nashville?").Id
                },
                new Option
                {
                    Content = "Draper James clothing store",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located in Nashville?").Id
                },
                new Option
                {
                    Content = "Graceland, home of Elvis Presley",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located in Nashville?").Id
                },
                new Option
                {
                    Content = "Nissan Stadium",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Which of the following is NOT located in Nashville?").Id
                },
                new Option
                {
                    Content = "East Nashville",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'K' is marked on the attached map south-west of downtown and above I-440. What is 'K'?").Id
                },
                new Option
                {
                    Content = "Music Row",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'K' is marked on the attached map south-west of downtown and above I-440. What is 'K'?").Id
                },
                new Option
                {
                    Content = "The 12 South neighborhood",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'K' is marked on the attached map south-west of downtown and above I-440. What is 'K'?").Id
                },
                new Option
                {
                    Content = "The Mall at Green Hills",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'K' is marked on the attached map south-west of downtown and above I-440. What is 'K'?").Id
                },
                new Option
                {
                    Content = "Briley Parkway",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'E' is marked several places on the attached map. What is 'E'?").Id
                },
                new Option
                {
                    Content = "McGavock Pike",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'E' is marked several places on the attached map. What is 'E'?").Id
                },
                new Option
                {
                    Content = "Trinity Lane",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'E' is marked several places on the attached map. What is 'E'?").Id
                },
                new Option
                {
                    Content = "Old Hickory Blvd.",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'E' is marked several places on the attached map. What is 'E'?").Id
                },
                new Option
                {
                    Content = "The city of Hendersonville",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'H' is marked on the attached map, near Old Hickory Lake. What is 'H'?").Id
                },
                new Option
                {
                    Content = "The Nashville International Airport",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'H' is marked on the attached map, near Old Hickory Lake. What is 'H'?").Id
                },
                new Option
                {
                    Content = "The suburb of Brentwood",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'H' is marked on the attached map, near Old Hickory Lake. What is 'H'?").Id
                },
                new Option
                {
                    Content = "The neighborhood of 12 South",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'H' is marked on the attached map, near Old Hickory Lake. What is 'H'?").Id
                },
                new Option
                {
                    Content = "Briley Parkway",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'F' is marked several places on the attached map. What is 'F'?").Id
                },
                new Option
                {
                    Content = "Interstate 440 (I-440)",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'F' is marked several places on the attached map. What is 'F'?").Id
                },
                new Option
                {
                    Content = "Interstate 24 (I-24)",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'F' is marked several places on the attached map. What is 'F'?").Id
                },
                new Option
                {
                    Content = "Old Hickory Blvd.",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "'F' is marked several places on the attached map. What is 'F'?").Id
                },
                new Option
                {
                    Content = "The city of Belle Meade",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Lake is the body of water near 'H' on the attached map. Which of the following is closest to Old Hickory Lake?").Id
                },
                new Option
                {
                    Content = "Opryland",
                    IsCorrect = true,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Lake is the body of water near 'H' on the attached map. Which of the following is closest to Old Hickory Lake?").Id
                },
                new Option
                {
                    Content = "Downtown Nashville",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Lake is the body of water near 'H' on the attached map. Which of the following is closest to Old Hickory Lake?").Id
                },
                new Option
                {
                    Content = "Nashville International Airport",
                    IsCorrect = false,
                    QuestionId = context.Question.SingleOrDefault(q => q.Content == "Old Hickory Lake is the body of water near 'H' on the attached map. Which of the following is closest to Old Hickory Lake?").Id
                }
            };

            foreach (Option o in foobar)
            {
                context.Option.Add(o);
            }
            context.SaveChanges();
        }
    }
}
