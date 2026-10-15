namespace EduHub.Ch01.Domain;

public class Registration
{
    public Guid Id { get; private set; }

    public Guid MemberId { get; private set; }

    public Guid EventId { get; private set; }

    public DateTime RegisteredAt { get; private set; }

    public RegistrationStatus Status { get; private set; }

    private Registration(Guid memberId, Guid eventId)
    {
        Id = Guid.NewGuid();
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = DateTime.Now;
        Status = RegistrationStatus.Pending; 
    }

    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
        {
            throw new ArgumentException("Phải chỉ định thành viên.");
        }

        if (eventId == Guid.Empty)
        {
            throw new ArgumentException("Phải chỉ định sự kiện.");
        }

        return new Registration(memberId, eventId);
    }

    public void Confirm()
    {
        if (Status == RegistrationStatus.Cancelled)
        {
            throw new InvalidOperationException("Không thể xác nhận phiếu đã huỷ.");
        }

        Status = RegistrationStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
        {
            throw new InvalidOperationException("Phiếu này đã được huỷ trước đó.");
        }

        Status = RegistrationStatus.Cancelled;
    }
}