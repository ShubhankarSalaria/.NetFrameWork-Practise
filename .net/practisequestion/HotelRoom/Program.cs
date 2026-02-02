public class Room
{
    public int RoomNumber {get; set;}
    public string RoomType{get; set;}
    public double PricePerNight{get; set;}
    public bool IsAvailable {get; set;}
}

public class HotelManager
{
    private List<Room> _rooms = new List<Room>();

    public void AddRoom(int roomNumber , string type , double price)
    {
        foreach(var room in _rooms)
        {
            if(room.RoomNumber == roomNumber)
            {
                Console.WriteLine("Room already exists.");
                return;
            }
        }

        Room newRoom = new Room()
        {
          RoomNumber=roomNumber,
          RoomType=type,
          PricePerNight=price,
          IsAvailable=true  
        };
        _rooms.Add(newRoom);
    }
    public  Dictionary<string , List<Room>> GroupRoomsByType()
    {
        Dictionary <string , List<Room>>RoomType = new Dictionary<string, List<Room>>();
        foreach(var room in _rooms)
        {
            if(!room.IsAvailable)
                continue;
            
            if (!RoomType.ContainsKey(room.RoomType))
            {
                RoomType[room.RoomType] = new List<Room>(); 
            }
            RoomType[room.RoomType].Add(room);
        }
        return RoomType;
    }
    public bool BookRoom(int roomNumber, int nights)
    {

        foreach(var room in _rooms)
        {
            if (room.RoomNumber == roomNumber)
            {
                if (!room.IsAvailable)
                {
                    Console.WriteLine("Room is already booked.");
                    return false;
                }
                double totalCost = room.PricePerNight * nights;
                room.IsAvailable = false;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Room booked successfully. Total Cost = {totalCost}");
                return true;
            }
        }
        Console.WriteLine("Room not found.");
        return false;
    }
    public List<Room> GetAvailableRoomsByPriceRange(double min , double max)
    {
        List<Room>AvailRoom = new List<Room>();
        foreach(var room in _rooms)
        {
            if(room.IsAvailable &&room.PricePerNight>=min && room.PricePerNight <= max)
            {
                AvailRoom.Add(room);
            }
        }
        return AvailRoom;
    }
}

class Program
{
    static void Main()
    {
        HotelManager manager = new HotelManager();

        manager.AddRoom(101, "Single", 2000);
        manager.AddRoom(102, "Double", 3500);
        manager.AddRoom(103, "Suite", 6000);

        manager.BookRoom(101, 2);

        var grouped = manager.GroupRoomsByType();

        foreach (var type in grouped)
        {
            Console.WriteLine(type.Key);

            foreach (var room in type.Value)
            {
                Console.WriteLine($"Room: {room.RoomNumber}");
            }
        }
    }
}