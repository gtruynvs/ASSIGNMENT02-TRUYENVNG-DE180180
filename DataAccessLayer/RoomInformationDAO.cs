using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO : SingletonBase<RoomInformationDAO>
    {
        private HotelminiDBContext _context;

        public RoomInformationDAO()
        {
            _context = new HotelminiDBContext();
        }

        public IEnumerable<RoomInformation> GetAllRoomInformation()
        {
            return _context.RoomInformations.ToList();
        }

        public void AddRoom(RoomInformation roomInformation)
        {
            _context.RoomInformations.Add(roomInformation);
            _context.SaveChanges();
        }

        public void DeleteRoom(RoomInformation roomInformation)
        {
            var existingRoom = _context.RoomInformations.Find(roomInformation.RoomID);
            if (existingRoom != null)
            {
                _context.RoomInformations.Remove(existingRoom);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Room information not found.");
            }
        }


        public void UpdateRoom(RoomInformation roomInformation)
        {
            _context.RoomInformations.Update(roomInformation);
            _context.SaveChanges();
        }

        public RoomInformation? GetRoomById(int id)
        {
            RoomInformation? room = _context.RoomInformations.FirstOrDefault(r => r.RoomID == id);
            return room;
        }
    }
}