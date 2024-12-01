using System.Text.Json;
using FitnessProject.Entities;
using Newtonsoft.Json;

namespace FitnessStudio.Data
{
    public class DataContext
    {
        public List<GymnastEntity> GymnastList { get; set; }
        public List<TrainerEntity> TrainerList { get; set; }
        public List<CourseEntity> CourseList { get; set; }
        public List<RoomEntity>   RoomList { get; set; }
        public List<LessonEntity> LessontList { get; set; }

        public DataContext()
        {
            //string path = Path.Combine("C:\\Users\\USER\\Documents\\רחלי\\תכנות ו\\netCore\\FitnessStudio.Data\\Data\\data.json");
            //string jsonString = File.ReadAllText(path);
            //DataContext data = JsonConvert.DeserializeObject<DataContext>(jsonString);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            string jsonString = File.ReadAllText(path);
            DataStructure? data = System.Text.Json.JsonSerializer.Deserialize<DataStructure>(jsonString);

            GymnastList = data.GymnastList;
            TrainerList = data.TrainerList;
            CourseList = data.CourseList;
            RoomList = data.RoomList;
            LessontList = data.LessontList;
        }
        public void SaveChange()
        {
            //DataContext dataList = new DataContext();
            //dataList.GymnastList = GymnastList;
            //dataList.TrainerList = TrainerList;
            //dataList.CourseList = CourseList;
            //dataList.RoomList = RoomList;
            //dataList.LessontList = LessontList;
            //string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            //string jsonString = System.Text.Json.JsonSerializer.Serialize(dataList);
            //File.WriteAllText(path, jsonString);
            
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                var data = new
                {
                    BuyingsList = this.GymnastList,
                    CardsList = this.TrainerList,
                    CustomersList = this.CourseList,
                    PurchaseCentersList = this.RoomList,
                    StoresList = this.LessontList
                };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(path, jsonString);
            }
        
    }

        public class DataStructure
        {
            public List<GymnastEntity> GymnastList { get; set; }
            public List<TrainerEntity> TrainerList { get; set; }
            public List<CourseEntity> CourseList { get; set; }
            public List<RoomEntity> RoomList { get; set; }
            public List<LessonEntity> LessontList { get; set; }
        }
    }

