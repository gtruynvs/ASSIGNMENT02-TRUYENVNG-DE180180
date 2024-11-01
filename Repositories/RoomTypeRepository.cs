using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public IEnumerable<RoomType> GetAllRoomTypes() => RoomTypeDAO.Instance.GetAllRoomTypes();

        public void AddRoomType(RoomType roomType) => RoomTypeDAO.Instance.AddRoomType(roomType);

        public void UpdateRoomType(RoomType roomType) => RoomTypeDAO.Instance.UpdateRoomType(roomType);

        public void DeleteRoomType(RoomType roomType) => RoomTypeDAO.Instance.DeleteRoomType(roomType);

        public RoomType? GetRoomTypeById(int id) => RoomTypeDAO.Instance.GetRoomTypeById(id);
    }
}
