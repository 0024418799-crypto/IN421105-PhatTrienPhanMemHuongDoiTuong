namespace EduHub.Ch01.Domain;

public class CheckIn
{
    public Guid Id { get; private set; }

    public Guid RegistrationId { get; private set; }

    public DateTime CheckedInAt { get; private set; }

    public CheckInMethod Method { get; private set; }

    private CheckIn(Guid registrationId, CheckInMethod method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registrationId;
        CheckedInAt = DateTime.Now;
        Method = method;
    }

    public static CheckIn Create(Registration registration, CheckInMethod method)
    {
        if (registration == null)
        {
            throw new ArgumentNullException(nameof(registration));
        }

        if (registration.Status != RegistrationStatus.Confirmed)
        {
            throw new InvalidOperationException("Chỉ phiếu đã xác nhận mới được điểm danh.");
        }

        return new CheckIn(registration.Id, method);
    }

    public string Summary()
    {
        return $"Điểm danh lúc {CheckedInAt:HH:mm:ss} bằng hình thức {Method}";
    }
}