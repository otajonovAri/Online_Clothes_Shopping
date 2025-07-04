using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public int NumberOfDesks { get; set; }
        public int NumberOfChairs { get; set; }
        public ICollection<GroupRoom> GroupRooms { get; set; }
    }
}
