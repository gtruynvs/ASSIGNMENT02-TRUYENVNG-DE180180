using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO : SingletonBase<RoomTypeDAO>
    {
        private HotelminiDBContext _context;

        public RoomTypeDAO()
        {
            _context = new HotelminiDBContext();
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _context.RoomTypes.ToList();
        }

        public void AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            _context.SaveChanges();
        }

        public void UpdateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            _context.SaveChanges();
        }

        public void DeleteRoomType(RoomType roomType)
        {
            _context.RoomTypes.Remove(roomType);
            _context.SaveChanges();
        }

        public RoomType? GetRoomTypeById(int id)
        {
            RoomType? roomType = _context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);
            return roomType;
        }
    }
}