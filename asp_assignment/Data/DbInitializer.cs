using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_assignment.Models;


namespace asp_assignment.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {


         
            if (context.Souvenirs.Any())
            {
                return;
            }



            var suppliers = new Supplier[] {

             new Supplier(){FirstName="Li",LastName="Rock",Address="49 Queen street",EmailAddress="rockli@unitec.ac.nz",MobilePhoneNumber="0251111111"},
             new Supplier(){FirstName="Green",LastName="Jame",Address="27 Bold Avenue",EmailAddress="JameGreen@baidu.com",MobilePhoneNumber="0251111112"},

             new Supplier(){FirstName="Kate",LastName="Anny",Address="31 Mt albert",EmailAddress="AnnyK@qq.com",MobilePhoneNumber="0251111113"},
             new Supplier(){FirstName="Micheal",LastName="Jack",Address="22 Mandival Avenue",EmailAddress="JackM@sina.com",MobilePhoneNumber="0251111114"},
               new Supplier(){FirstName="Owen",LastName="Mick",Address="22 Flatbush Avenue",EmailAddress="OwenM@yahoo.com",MobilePhoneNumber="0251111115"}
            };

            foreach (var item in suppliers)
            {
                context.Suppliers.Add(item);
            }
            context.SaveChanges();





            var categories = new Category[] {

                new Category(){ Name="Maori Gift",Description="The gifts from New Zealand"},
                 new Category(){ Name="Chinese Gift",Description="The gifts from China"},
                  new Category(){ Name="Egyptian Gift",Description="The gifts from Egypt"},
                  new Category(){ Name="Indian Gift",Description="The gifts from India"},
                    new Category(){ Name="Roman Gift",Description="The gifts from Roma"},
                   new Category(){ Name="Japanese Gift",Description="The gifts from Japan"}
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();
            var souvenirs1 = new Souvenir[] {
             
                  
                  new Souvenir(){Name="Milk Wax",Description="This is a Milk Wax",Price=44,SupplierID=1,CategoryID=5,PathOfFile="/Images/SouvenirImages/L30.jpg"},
                  new Souvenir(){Name="Series Jewelries",Description="This is a Series of Jewelries",Price=2599,SupplierID=4,CategoryID=5,PathOfFile="/Images/SouvenirImages/L33.jpg"},
                    new Souvenir(){Name="Crystal",Description="This is a Crystal",Price=322,SupplierID=2,CategoryID=5,PathOfFile="/Images/SouvenirImages/L36.jpg"},
                new Souvenir(){Name="Roma Cross",Description="This is a Roma Cross",Price=288,SupplierID=2,CategoryID=5,PathOfFile="/Images/SouvenirImages/L37.jpg"},
                       new Souvenir(){Name="Cat Necklace",Description="This is a Cat Necklace",Price=248,SupplierID=4,CategoryID=3,PathOfFile="/Images/SouvenirImages/E30.jpg"},
                          new Souvenir(){Name="Qipao China",Description="This is a Qipao China",Price=98,SupplierID=1,CategoryID=2,PathOfFile="/Images/SouvenirImages/C32.jpg"}
            };
            foreach (var item in souvenirs1)
            {
                context.Souvenirs.Add(item);
            }
            context.SaveChanges();

            var souvenirs = new Souvenir[] {
                  new Souvenir(){Name="Stone Carving",Description="This is a Stone Carving",Price=399,SupplierID=3,CategoryID=5,PathOfFile="/Images/SouvenirImages/L02.jpg"},
                            new Souvenir(){Name="Jade Bowl",Description="This is a Jade Bowl",Price=588,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C16.jpg"},
                  new Souvenir(){Name="Qing Necklace",Description="This is a Qing Necklace",Price=238,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C30.jpg"},
                      new Souvenir(){Name="Indian Ring",Description="This is a Indian Ring",Price=139,SupplierID=2,CategoryID=4,PathOfFile="/Images/SouvenirImages/I30.jpg"},
                                new Souvenir(){Name="Indian Pot",Description="This is a Indian Pot",Price=399,SupplierID=3,CategoryID=4,PathOfFile="/Images/SouvenirImages/I31.jpg"},
                  new Souvenir(){Name="Flower Necklace",Description="This is a Flower Necklace",Price=38,SupplierID=2,CategoryID=5,PathOfFile="/Images/SouvenirImages/L34.jpg"},
                    new Souvenir(){Name="Landscape Fan",Description="This is a Landscape Fan",Price=78,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C13.jpg"},
                  new Souvenir(){Name="Testacean Bowl",Description="This is a Testacean Bowl",Price=49,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M09.jpg"},
                  new Souvenir(){Name="Indian Necklace",Description="This is an Indian Necklace",Price=2999,SupplierID=4,CategoryID=4,PathOfFile="/Images/SouvenirImages/I09.jpg"},
                    new Souvenir(){Name="Wooden Dragon",Description="This is a Wooden Dragon",Price=238,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C05.jpg"},
                new Souvenir(){Name="Sancai Horse",Description="This is a Sancai horse from Tang Dynasty",Price=4888,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C15.jpg"},
                       
                         new Souvenir(){Name="Bone China",Description="This is a Bone China",Price=498,SupplierID=4,CategoryID=2,PathOfFile="/Images/SouvenirImages/C17.jpg"},
                          new Souvenir(){Name="Song teapot",Description="This is a teapot from Sang Dynasty",Price=7898,SupplierID=1,CategoryID=2,PathOfFile="/Images/SouvenirImages/C18.jpg"},
                           new Souvenir(){Name="Dragon Bottle",Description="This is a Dragon Bottle",Price=2238,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C19.jpg"},
                            new Souvenir(){Name="Opera Dolls",Description="This is a pair of Opera Dolls",Price=38,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C20.jpg"},
                             new Souvenir(){Name="Monkey King",Description="This is a Monkey King doll",Price=48,SupplierID=4,CategoryID=2,PathOfFile="/Images/SouvenirImages/C21.jpg"},
                                                              new Souvenir(){Name="Dony Model",Description="This is a Dony Model",Price=79,SupplierID=5,CategoryID=6,PathOfFile="/Images/SouvenirImages/J01.jpg"},
                                  new Souvenir(){Name="Solong Model",Description="This is a Solong Model",Price=78,SupplierID=2,CategoryID=6,PathOfFile="/Images/SouvenirImages/J03.jpg"},
                               new Souvenir(){Name="Roman Building",Description="This is Roma Building model",Price=199,SupplierID=2,CategoryID=5,PathOfFile="/Images/SouvenirImages/L01.jpg"},
                                
                                 new Souvenir(){Name="Carving Women",Description="This is a Stone Carving Women",Price=99,SupplierID=4,CategoryID=5,PathOfFile="/Images/SouvenirImages/L05.jpg"},
                                  new Souvenir(){Name="Sketch",Description="This is a great painter's work which is a sketch of Audrey Hepburn",Price=30,SupplierID=2,CategoryID=5,PathOfFile="/Images/SouvenirImages/L06.jpg"},
             new Souvenir(){Name="Silver Hook",Description="This is a Silver Hooked pendant",Price=99,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M01.jpg"},
           new Souvenir(){Name="Kiwi Bird",Description="This is a Kiwi Bird pendant and a pair of earrings",Price=189,SupplierID=2,CategoryID=1,PathOfFile="/Images/SouvenirImages/M02.jpg"},
            new Souvenir(){Name="Wooden Totem",Description="This is a Maori's unique Maori wooden totem",Price=79,SupplierID=3,CategoryID=1,PathOfFile="/Images/SouvenirImages/M03.jpg"},
              new Souvenir(){Name="Wooden Face",Description="This is a Maori Wooden Face",Price=39,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M20.jpg"},
           new Souvenir(){Name="Wooden Box",Description="This is a Maori Wooden Box",Price=9,SupplierID=2,CategoryID=1,PathOfFile="/Images/SouvenirImages/M21.jpg"},
            new Souvenir(){Name="Wooden Mask",Description="This is a Maori's unique Wooden Mask",Price=19,SupplierID=3,CategoryID=1,PathOfFile="/Images/SouvenirImages/M22.jpg"},
             new Souvenir(){Name="Mask",Description="This is Maori Mask",Price=29,SupplierID=4,CategoryID=1,PathOfFile="/Images/SouvenirImages/M23.jpg"},
             new Souvenir(){Name="Wooden Totem2",Description="This is anther Maori's unique Maori wooden totem",Price=79,SupplierID=4,CategoryID=1,PathOfFile="/Images/SouvenirImages/M04.jpg"},
              new Souvenir(){Name="Wool doll",Description="There are three Wool dolls",Price=39,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M05.jpg"},
               new Souvenir(){Name="Spiral Jade",Description="This is a Spiral Jade pendant",Price=249,SupplierID=2,CategoryID=1,PathOfFile="/Images/SouvenirImages/M06.jpg"},
                new Souvenir(){Name="Spiral Ring",Description="This is a silver Spiral Ring",Price=69,SupplierID=3,CategoryID=1,PathOfFile="/Images/SouvenirImages/M07.jpg"},
                 new Souvenir(){Name="Maori Woman",Description="This is a picture of a Maori Women",Price=239,SupplierID=4,CategoryID=1,PathOfFile="/Images/SouvenirImages/M08.jpg"},
                 new Souvenir(){Name="Opera Doll",Description="This is a Opera Doll",Price=48,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C35.jpg"},
                   new Souvenir(){Name="Silver Face",Description="This is a Silver Face pendant",Price=89,SupplierID=2,CategoryID=1,PathOfFile="/Images/SouvenirImages/M10.jpg"},
                    new Souvenir(){Name="Spiral Pendant",Description="This is a colorful Spiral pendant",Price=279,SupplierID=3,CategoryID=1,PathOfFile="/Images/SouvenirImages/M11.jpg"},
                  
                      new Souvenir(){Name="Red Jade",Description="This is a Red Spiral Jade pendant",Price=99,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M13.jpg"},
                       
                     
                        new Souvenir(){Name="Paper Bridge",Description="This is a Paper Bridge",Price=58,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C02.jpg"},
                          
                        
                         
                            new Souvenir(){Name="Wooden Moer",Description="This is a Wooden Moer for smoke",Price=38,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C06.jpg"},
                             new Souvenir(){Name="Bronze Soldier",Description="There are two Bronze Soldiers",Price=498,SupplierID=4,CategoryID=2,PathOfFile="/Images/SouvenirImages/C07.jpg"},
                              new Souvenir(){Name="Blossom Fan",Description="This is a Blossom Fan",Price=68,SupplierID=1,CategoryID=2,PathOfFile="/Images/SouvenirImages/C08.jpg"},
                               new Souvenir(){Name="Porcelain Bowl",Description="This is expensive Porcelain Bowl",Price=1999,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C09.jpg"},
                                new Souvenir(){Name="Wooden Chess",Description="This is a Wooden Chess",Price=198,SupplierID=3,CategoryID=2,PathOfFile="/Images/SouvenirImages/C10.jpg"},
                                 new Souvenir(){Name="Silk Fan",Description="This is a Silk Fan",Price=98,SupplierID=4,CategoryID=2,PathOfFile="/Images/SouvenirImages/C11.jpg"},
                                  new Souvenir(){Name="Pearl Necklace",Description="This is a real Pearl Necklace",Price=298,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C12.jpg"},
                               new Souvenir(){Name="Wooden Book",Description="This is a silver wooden book",Price=49,SupplierID=4,CategoryID=1,PathOfFile="/Images/SouvenirImages/M12.jpg"},
                new Souvenir(){Name="Egyptian Cat",Description="This is a Egyptian Cat",Price=198,SupplierID=4,CategoryID=3,PathOfFile="/Images/SouvenirImages/E12.jpg"},
                                    new Souvenir(){Name="Chinese Doll",Description="This is a Chinese Doll",Price=38,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C14.jpg"},
                                        new Souvenir(){Name="Sand Bag",Description="This is a Sand Bag",Price=79,SupplierID=2,CategoryID=3,PathOfFile="/Images/SouvenirImages/E01.jpg"},
                                            new Souvenir(){Name="Bronze Pot",Description="This is a Bronze Pot",Price=69,SupplierID=3,CategoryID=3,PathOfFile="/Images/SouvenirImages/E02.jpg"},
                                                new Souvenir(){Name="Bronze Sphinx",Description="This is a Bronze Sphinx",Price=399,SupplierID=2,CategoryID=3,PathOfFile="/Images/SouvenirImages/E03.jpg"},
                                                    new Souvenir(){Name="Eye Ring",Description="This is a silver Eye Ring",Price=49,SupplierID=1,CategoryID=3,PathOfFile="/Images/SouvenirImages/E04.jpg"},
                                                        new Souvenir(){Name="Silver Azir",Description="This is a Silver Azir who is the king of sand",Price=399,SupplierID=4,CategoryID=3,PathOfFile="/Images/SouvenirImages/E05.jpg"},
                                                         new Souvenir(){Name="Wooden Jade",Description="This is a Wooden Jade pendant",Price=99,SupplierID=1,CategoryID=1,PathOfFile="/Images/SouvenirImages/M16.jpg"},
                new Souvenir(){Name="Pyramid",Description="This is a magical Pyramid",Price=1399,SupplierID=2,CategoryID=3,PathOfFile="/Images/SouvenirImages/E06.jpg"},
                                                               new Souvenir(){Name="Chopsticks",Description="There are two pairs of Chopsticks",Price=48,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C01.jpg"},
                new Souvenir(){Name="Egyptian Cat",Description="This is a pair Egyptian Cats",Price=399,SupplierID=2,CategoryID=3,PathOfFile="/Images/SouvenirImages/E07.jpg"},
                                                                new Souvenir(){Name="Bronze Elephant",Description="This is a Bronze Elephant",Price=299,SupplierID=2,CategoryID=4,PathOfFile="/Images/SouvenirImages/I01.jpg"},
                                                                new Souvenir(){Name="Bronze Tower",Description="This is a Bronze Tower",Price=199,SupplierID=1,CategoryID=4,PathOfFile="/Images/SouvenirImages/I02.jpg"},
                                                                new Souvenir(){Name="Wooden Pot",Description="This is a Wooden Pot",Price=39,SupplierID=3,CategoryID=4,PathOfFile="/Images/SouvenirImages/I03.jpg"},
                                                                new Souvenir(){Name="Dragon Jade",Description="This is a Dragon Jade pendant",Price=898,SupplierID=1,CategoryID=2,PathOfFile="/Images/SouvenirImages/C04.jpg"},
                                                                   new Souvenir(){Name="Wooden Box",Description="This is a Wooden Box",Price=89,SupplierID=4,CategoryID=4,PathOfFile="/Images/SouvenirImages/I12.jpg"},
                           new Souvenir(){Name="China Doll",Description="This is a China Doll",Price=78,SupplierID=2,CategoryID=2,PathOfFile="/Images/SouvenirImages/C34.jpg"},
                           new Souvenir(){Name="Butterfly",Description="This is a butterfly",Price=148,SupplierID=3,CategoryID=4,PathOfFile="/Images/SouvenirImages/E32.jpg"},
                         new Souvenir(){Name="Song China",Description="This is a Song China",Price=1498,SupplierID=4,CategoryID=2,PathOfFile="/Images/SouvenirImages/C33.jpg"},
                            



            new Souvenir(){Name="Roma Helmet",Description="This is a Roma Helmet",Price=79,SupplierID=3,CategoryID=5,PathOfFile="/Images/SouvenirImages/L31.jpg"},
                                 new Souvenir(){Name="Silver House",Description="This is a silver house",Price=29,SupplierID=5,CategoryID=5,PathOfFile="/Images/SouvenirImages/L32.jpg"},

                                   new Souvenir(){Name="Stone Woman",Description="This is a Stone Woman",Price=256,SupplierID=3,CategoryID=5,PathOfFile="/Images/SouvenirImages/L35.jpg"},
                                 new Souvenir(){Name="Crystal Heart",Description="This is a Crystal Heart",Price=22,SupplierID=5,CategoryID=5,PathOfFile="/Images/SouvenirImages/L38.jpg"}  };
            foreach (var item in souvenirs)
            {
                context.Souvenirs.Add(item);
            }
            context.SaveChanges();
        }

    }
}
