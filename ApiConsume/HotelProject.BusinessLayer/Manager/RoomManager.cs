using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Manager
{
    public class RoomManager : IRoomService
    {
       //dependency injection
       private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TDelete(Room t)
        {
            _roomDal.Delete(t);
            
        }

        public Room TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public List<Room> TUserListWorkLocation()
        {
            return _roomDal.GetList();
        }

        public void TInsert(Room t)
        {
           _roomDal.Insert(t);
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }

        public List<Room> TGetList()
        {
            throw new NotImplementedException();
        }

        public int TRoomCount()
        {
            return _roomDal.RoomCount();
        }
    }
}
