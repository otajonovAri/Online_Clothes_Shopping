using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Core.Entities
{
    public class GroupRoom
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public Room Room { get; set; }
        public Group Group { get; set; }
    }
}
