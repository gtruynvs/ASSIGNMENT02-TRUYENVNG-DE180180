using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public IEnumerable<RoomInformation> GetAllRoomInformation() => RoomInformationDAO.Instance.GetAllRoomInformation();

        public void AddRoom(RoomInformation roomInformation) => RoomInformationDAO.Instance.AddRoom(roomInformation);

        public void UpdateRoom(RoomInformation roomInformation) => RoomInformationDAO.Instance.UpdateRoom(roomInformation);

        public void DeleteRoom(RoomInformation roomInformation) => RoomInformationDAO.Instance.DeleteRoom(roomInformation);

        public RoomInformation? GetRoomById(int id) => RoomInformationDAO.Instance.GetRoomById(id);
    }
}
