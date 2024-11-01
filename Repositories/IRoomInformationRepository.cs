using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        IEnumerable<RoomInformation> GetAllRoomInformation();

        void AddRoom(RoomInformation roomInformation);

        void UpdateRoom(RoomInformation roomInformation);

        void DeleteRoom(RoomInformation roomInformation);

        RoomInformation? GetRoomById(int id);
    }
}