using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomTypeRepository
    {
        IEnumerable<RoomType> GetAllRoomTypes();

        void AddRoomType(RoomType roomType);

        void UpdateRoomType(RoomType roomType);

        void DeleteRoomType(RoomType roomType);

        RoomType? GetRoomTypeById(int id);
    }
}