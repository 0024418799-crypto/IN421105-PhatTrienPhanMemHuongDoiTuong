namespace EduHub.Ch01.Domain;

public class Event
{
    public Guid Id { get; private set; }

    public Guid ClubId { get; private set; }

    public string Title { get; private set; }

    public DateTime Date { get; private set; }

    public int Capacity { get; private set; }

    public bool IsOnline { get; private set; }

    private Event(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        Id = Guid.NewGuid();
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        if (clubId == Guid.Empty)
        {
            throw new ArgumentException("Phải chỉ định CLB tổ chức.");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Tên sự kiện không được để trống.");
        }

        if (capacity <= 0)
        {
            throw new ArgumentException("Sức chứa phải lớn hơn 0.");
        }

        return new Event(clubId, title.Trim(), date, capacity, isOnline);
    }

    public bool HasCapacity(int registeredCount)
    {
        return registeredCount < Capacity;
    }
}